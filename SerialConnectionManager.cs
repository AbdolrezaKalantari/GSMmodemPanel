using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GsmPanel
{
    public static class SerialConnectionManager
    {
        private static SerialPort? _sharedPort;
        public static SerialPort Instance
        {
            get
            {
                if (_sharedPort == null)
                {
                    _sharedPort = new SerialPort();
                }
                return _sharedPort;
            }
        }
    }
}
