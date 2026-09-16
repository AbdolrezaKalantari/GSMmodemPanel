using System;
using System.IO.Ports;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GsmPanel
{
    public class GsmModemService : IGsmModemService
    {
        private SerialPort? _serialPort;
        private readonly SemaphoreSlim _commandLock = new(1, 1);

        public event Action<string>? DataReceived;
        public event Action<Exception>? ErrorOccurred;

        public bool IsConnected => _serialPort?.IsOpen ?? false;

        public void Connect(string portName, int baudRate, Parity parity, int dataBits, StopBits stopBits, int readTimeout, int writeTimeout)
        {
            if (IsConnected)
            {
                Disconnect();
            }

            try
            {
                _serialPort = new SerialPort(portName, baudRate, parity, dataBits, stopBits)
                {
                    DtrEnable = true,
                    RtsEnable = true,
                    ReadTimeout = readTimeout,
                    WriteTimeout = writeTimeout
                };

                _serialPort.DataReceived += OnDataReceived;
                _serialPort.ErrorReceived += OnErrorReceived;
                _serialPort.Open();
            }
            catch (Exception ex)
            {
                Disconnect();
                ErrorOccurred?.Invoke(ex);
            }
        }

        public void Disconnect()
        {
            if (_serialPort == null) return;

            try
            {
                if (_serialPort.IsOpen)
                {
                    _serialPort.DataReceived -= OnDataReceived;
                    _serialPort.ErrorReceived -= OnErrorReceived;
                    _serialPort.Close();
                }
            }
            catch (Exception ex)
            {
                ErrorOccurred?.Invoke(ex);
            }
            finally
            {
                _serialPort.Dispose();
                _serialPort = null;
            }
        }

        public void Dispose()
        {
            Disconnect();
        }

        public async Task SendCommandAsync(string command)
        {
            if (string.IsNullOrWhiteSpace(command))
                return;

            await _commandLock.WaitAsync().ConfigureAwait(false);
            try
            {
                await WriteCommandAsync(command).ConfigureAwait(false);
            }
            finally
            {
                _commandLock.Release();
            }
        }

        private async Task WriteCommandAsync(string command)
        {
            var port = _serialPort;
            if (port == null || !port.IsOpen)
            {
                var exception = new InvalidOperationException("Port is not open.");
                ErrorOccurred?.Invoke(exception);
                throw exception;
            }

            try
            {
                var bytes = Encoding.ASCII.GetBytes(command.TrimEnd('\r', '\n') + "\r");
                await port.BaseStream.WriteAsync(bytes, 0, bytes.Length).ConfigureAwait(false);
                await port.BaseStream.FlushAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                ErrorOccurred?.Invoke(ex);
                throw;
            }
        }

        private void OnDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                var port = _serialPort;
                if (port == null || !port.IsOpen) return;

                string data = port.ReadExisting();
                DataReceived?.Invoke(data);
            }
            catch (Exception ex)
            {
                ErrorOccurred?.Invoke(ex);
            }
        }

        private void OnErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            ErrorOccurred?.Invoke(new Exception($"Serial port error: {e.EventType}"));
        }

        public async Task<string> SendCommandWithResponseAsync(string command, int timeoutMs = 2000)
        {
            if (string.IsNullOrWhiteSpace(command))
                return string.Empty;

            await _commandLock.WaitAsync().ConfigureAwait(false);
            try
            {
                return await SendAndWaitCoreAsync(
                    Encoding.ASCII.GetBytes(command.TrimEnd('\r', '\n') + "\r"),
                    IsFinalResponse,
                    timeoutMs).ConfigureAwait(false);
            }
            finally
            {
                _commandLock.Release();
            }
        }

        public async Task SendSmsAsync(string phoneNumber, string message, int timeoutMs = 60000)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
                throw new ArgumentException("شماره گیرنده الزامی است.", nameof(phoneNumber));
            if (string.IsNullOrWhiteSpace(message))
                throw new ArgumentException("متن پیامک الزامی است.", nameof(message));

            string normalizedPhone = Regex.Replace(phoneNumber.Trim(), @"[^0-9+]", string.Empty);
            if (normalizedPhone.StartsWith("+", StringComparison.Ordinal))
                normalizedPhone = "00" + normalizedPhone[1..];
            if (normalizedPhone.Length < 8 || !normalizedPhone.All(char.IsDigit))
                throw new ArgumentException("شماره گیرنده معتبر نیست.", nameof(phoneNumber));

            await _commandLock.WaitAsync().ConfigureAwait(false);
            try
            {
                var modeResponse = await SendAndWaitCoreAsync(
                    Encoding.ASCII.GetBytes("AT+CMGF=1\r"), IsFinalResponse, 5000).ConfigureAwait(false);
                EnsureSuccess(modeResponse, "تنظیم حالت ارسال پیامک انجام نشد.");

                var charsetResponse = await SendAndWaitCoreAsync(
                    Encoding.ASCII.GetBytes("AT+CSCS=\"UCS2\"\r"), IsFinalResponse, 5000).ConfigureAwait(false);
                EnsureSuccess(charsetResponse, "تنظیم کدگذاری پیامک انجام نشد.");

                string recipient = ToUcs2(normalizedPhone);
                var promptResponse = await SendAndWaitCoreAsync(
                    Encoding.ASCII.GetBytes($"AT+CMGS=\"{recipient}\"\r"),
                    response => response.Contains(">", StringComparison.Ordinal) || IsFinalResponse(response),
                    10000).ConfigureAwait(false);

                if (!promptResponse.Contains(">", StringComparison.Ordinal))
                    EnsureSuccess(promptResponse, "مودم برای دریافت متن پیامک آماده نشد.");

                var result = await SendAndWaitCoreAsync(
                    Encoding.ASCII.GetBytes(ToUcs2(message) + char.ConvertFromUtf32(26)),
                    IsFinalResponse,
                    Math.Max(10000, timeoutMs)).ConfigureAwait(false);
                EnsureSuccess(result, "ارسال پیامک ناموفق بود.");
            }
            finally
            {
                _commandLock.Release();
            }
        }

        private async Task<string> SendAndWaitCoreAsync(byte[] bytes, Func<string, bool> isComplete, int timeoutMs)
        {
            var tcs = new TaskCompletionSource<string>(TaskCreationOptions.RunContinuationsAsynchronously);
            var responseBuilder = new StringBuilder();
            Action<string> temporaryHandler = data =>
            {
                responseBuilder.Append(data);
                var response = responseBuilder.ToString();
                if (isComplete(response)) tcs.TrySetResult(response);
            };

            try
            {
                DataReceived += temporaryHandler;
                await WriteBytesAsync(bytes).ConfigureAwait(false);
                var completed = await Task.WhenAny(tcs.Task, Task.Delay(Math.Max(100, timeoutMs))).ConfigureAwait(false);
                return completed == tcs.Task ? await tcs.Task.ConfigureAwait(false) : responseBuilder.ToString();
            }
            finally
            {
                DataReceived -= temporaryHandler;
            }
        }

        private async Task WriteBytesAsync(byte[] bytes)
        {
            var port = _serialPort;
            if (port == null || !port.IsOpen)
                throw new InvalidOperationException("Port is not open.");
            await port.BaseStream.WriteAsync(bytes, 0, bytes.Length).ConfigureAwait(false);
            await port.BaseStream.FlushAsync().ConfigureAwait(false);
        }

        private static bool IsFinalResponse(string response) =>
            response.Contains("\r\nOK\r\n", StringComparison.OrdinalIgnoreCase) ||
            response.Contains("\r\nERROR\r\n", StringComparison.OrdinalIgnoreCase) ||
            response.TrimEnd().EndsWith("OK", StringComparison.OrdinalIgnoreCase) ||
            response.TrimEnd().EndsWith("ERROR", StringComparison.OrdinalIgnoreCase);

        private static string ToUcs2(string value) =>
            string.Concat(value.Select(c => ((int)c).ToString("X4")));

        private static void EnsureSuccess(string response, string message)
        {
            if (string.IsNullOrWhiteSpace(response) || response.Contains("ERROR", StringComparison.OrdinalIgnoreCase))
                throw new InvalidOperationException(message);
        }
    }
}
