using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GsmPanel
{
    public interface IRepository<T>
    {
        Task<List<T>> GetAllAsync();
        Task SaveAllAsync(List<T> items);
    }
}
