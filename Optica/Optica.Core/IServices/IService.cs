using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optica.Core.IServices
{
    public interface IService<T>
    {
        IEnumerable<T> GetAll();
        T GetById(string id);
        T Update(string id, T obj);
        bool Delete(string id);
        T Add(T obj);
    }
}
