using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optica.Core.IRepositories
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        T GetById(string id);
        bool Update(string id, T obj);
        bool Delete(string id);
        bool Add(T obj);
    }
}
