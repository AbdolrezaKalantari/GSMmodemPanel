using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GsmPanel
{
    public interface IComboBoxPresetService
    {
        IReadOnlyList<string> GetAll();
        bool TryAdd(string value);
        void ResetToDefaults(); 
    }
}
