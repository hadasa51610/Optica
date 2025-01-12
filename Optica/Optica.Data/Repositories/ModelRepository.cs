using Optica.Core.Entites;
using Optica.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optica.Data.Repositories
{
    public class ModelRepository : Repository<Model>, IModelRepository
    {
        public ModelRepository(DataContext dataContext) : base(dataContext)
        {

        }

        public List<Model> GetFull()
        {
            return _dbSet.ToList();
        }
    }
}