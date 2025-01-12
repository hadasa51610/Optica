using Optica.Core.Entites;
using Optica.Core.IRepositories;
using Optica.Core.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optica.Service
{
    public class UserService : IService<User>
    {
        private readonly IRepositoryManager _managerRepository;
        public UserService(IRepositoryManager userRepository)
        {
            _managerRepository = userRepository;
        }
        public IEnumerable<User> GetAll() => _managerRepository._users.GetFull();

        public User GetById(string userId) => _managerRepository._users.GetById(userId);

        public User Update(string userId, User user)
        {
            User u = _managerRepository._users.Update(userId, user);
            if (u != null) _managerRepository.Save();
            return u;
        }

        public bool Delete(string userId)
        {
            bool deleted = _managerRepository._users.Delete(userId);
            if (deleted) _managerRepository.Save();
            return deleted;
        }

        public User Add(User user)
        {
            User u = _managerRepository._users.Add(user);
            if (u != null) _managerRepository.Save();
            return u;
        }
    }
}
