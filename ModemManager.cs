using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GsmPanel
{
    public static class ModemManager
    {
        private static IGsmModemService? _instance;
        public static IGsmModemService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GsmModemService();
                }
                return _instance;
            }
        }
    }
}
