using Microsoft.EntityFrameworkCore;
using Optica.Core.Entites;
using Optica.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optica.Data.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(DataContext dataContext) : base(dataContext)
        {

        }

        public List<Order> GetFull()
        {
            return _dbSet.Include(o => o.Discount).ToList();
        }

    }
}
