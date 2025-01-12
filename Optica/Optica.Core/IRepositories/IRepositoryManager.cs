using Optica.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optica.Core.IRepositories
{
    public interface IRepositoryManager
    {
        ICheckRepository _checks { get; }
        IDiscountRepository _discounts { get; }
        IModelRepository _models { get; }
        IOrderRepository _orders { get; }
        IUserRepository _users { get; }
        void Save();
    }
}