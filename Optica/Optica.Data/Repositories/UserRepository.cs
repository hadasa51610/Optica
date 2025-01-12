using Optica.Core.Entites;
using Optica.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optica.Data.Repositories
{
    public class UserRepository : Repository<User>,IUserRepository
    {
        public UserRepository(DataContext context):base(context)
        {
           
        }
        
        public List<User> GetFull()
        {
            return _dbSet.ToList();
        }
    }
}