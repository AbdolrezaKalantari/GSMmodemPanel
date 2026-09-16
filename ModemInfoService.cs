using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GsmPanel
{
    public class ModemInfoService
    {
        private readonly SerialPort _serialPort;
        public ModemInfoService(SerialPort serialPort)
        {
            _serialPort = serialPort;
        }
        private async Task<string> SendCommandAsync(string command, int timeoutMs = 2000)
        {
            if (!_serialPort.IsOpen) return string.Empty;

            _serialPort.DiscardInBuffer();
            _serialPort.WriteLine(command + "\r");

            string response = string.Empty;
            int delay = 50;
            int elapsed = 0;

            while (elapsed < timeoutMs)
            {
                await Task.Delay(delay);
                elapsed += delay;
                response += _serialPort.ReadExisting();

                if (response.Contains("OK\r\n") || response.Contains("ERROR\r\n"))
                    break;
            }

            return response;
        }
       
        public async Task<string> GetSimStatusAsync()
        {
            string response = await SendCommandAsync("AT+CPIN?");
            if (response.Contains("+CPIN: READY"))
                return "آماده (Ready)";
            if (response.Contains("SIM PIN"))
                return "نیازمند پین‌کد";
            if (response.Contains("SIM NOT INSERTED") || response.Contains("ERROR"))
                return "عدم شناسایی سیم‌کارت";

            return "نامشخص";
        }

       
        public async Task<int> GetSignalQualityPercentageAsync()
        {
            string response = await SendCommandAsync("AT+CSQ");

          
            Match match = Regex.Match(response, @"\+CSQ:\s*(\d+),");
            if (match.Success)
            {
                int signalRaw = int.Parse(match.Groups[1].Value);
                if (signalRaw == 99) return 0; 

             
                int percentage = (int)Math.Round((signalRaw / 31.0) * 100);
                return percentage;
            }

            return 0; 
        }

       
        public async Task<string> GetNetworkStatusAsync()
        {
            string response = await SendCommandAsync("AT+CREG?");

           
            Match match = Regex.Match(response, @"\+CREG:\s*\d+,(\d+)");
            if (match.Success)
            {
                int status = int.Parse(match.Groups[1].Value);
                return status switch
                {
                    1 => "متصل (Home Network)",
                    5 => "متصل (Roaming)",
                    2 => "در حال جستجوی شبکه...",
                    3 => "ثبت شبکه رد شد",
                    _ => "قطع ارتباط"
                };
            }

            return "نامشخص";
        }

    }
}
