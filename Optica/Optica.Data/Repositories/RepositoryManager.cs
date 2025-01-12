using Optica.Core.Entites;
using Optica.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optica.Data.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly DataContext _context;
        public IUserRepository _users { get; }

        public ICheckRepository _checks { get; }

        public IDiscountRepository _discounts { get; }

        public IModelRepository _models { get; }

        public IOrderRepository _orders { get; }

        public RepositoryManager(DataContext context, IUserRepository uRepository, IOrderRepository oRepository, ICheckRepository cRepository, IModelRepository mRepository, IDiscountRepository dRepository)
        {
            _context = context;
            _users = uRepository;
            _checks = cRepository;
            _discounts = dRepository;
            _models = mRepository;
            _orders = oRepository;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}