using Optica.Core.Entites;
using Optica.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optica.Data.Repositories
{
    public class DiscountRepository : Repository<Discount>, IDiscountRepository
    {
        public DiscountRepository(DataContext dataContext) : base(dataContext)
        {

        }

        public List<Discount> GetFull()
        {
            return _dbSet.ToList();
        }
    }
}