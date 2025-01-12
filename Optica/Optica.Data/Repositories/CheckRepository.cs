using Optica.Core.Entites;
using Optica.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optica.Data.Repositories
{
    public class CheckRepository : Repository<Check>, ICheckRepository
    {
        public CheckRepository(DataContext dataContext) : base(dataContext)
        {

        }

        public List<Check> GetFull()
        {
            return _dbSet.ToList();
        }
    }
}