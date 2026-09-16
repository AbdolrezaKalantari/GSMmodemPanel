using System.IO.Ports;

namespace GsmPanel
{
    public interface IGsmModemService : IDisposable
    {
        event Action<String> DataReceived;
        event Action<Exception> ErrorOccurred;
        bool IsConnected { get; }

        void Connect(string portName, int baudRate, Parity parity, int dataBits, StopBits stopBits, int readTimeout, int writeTimeout);
        void Disconnect();
        Task SendCommandAsync(string command);
        Task<string> SendCommandWithResponseAsync(string command, int timeoutMs = 2000);
        Task SendSmsAsync(string phoneNumber, string message, int timeoutMs = 60000);

    }
}
