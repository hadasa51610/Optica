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
    public class UserService:IService<User>
    {
        private readonly IRepository<User> _userRepository;
        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }
        public List<User> GetAll()
        {
            return _userRepository.GetAll();
        }
        public User GetById(string userId)
        {
            return _userRepository.GetById(userId);
        }

        public bool Update(string userId, User user)
        {
            return _userRepository.Update(userId, user);
        }

        public bool Delete(string userId)
        {
            return _userRepository.Delete(userId);
        }

        public bool Add(User user)
        {
            return _userRepository.Add(user);
        }
    }
}
