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
       // public IRepositories<> Users { get; }

        //public RepositoryManager(DataContext context, IUserRepository userRepository)
        //{
        //    _context = context;
        //    Users = userRepository;
        //}

        //public void Save()
        //{
        //    _context.SaveChanges();
        //}
    }
}