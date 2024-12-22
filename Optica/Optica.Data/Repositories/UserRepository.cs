using Optica.Core.Entites;
using Optica.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optica.Data.Repositories
{
    public class UserRepository:IRepository<User>
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context)
        {
            _context = context;
        }
        public List<User> GetAll()
        {
            return _context.LoadUsers();
        }

        public User GetById(string userId)
        {
            return _context.LoadUsers().FirstOrDefault<User>((u) => u.UserId == userId);
        }

        public bool Update(string userId, User user)
        {
            List<User> users = _context.LoadUsers();
            User updateUser = users.Find((u) => u.UserId == userId);
            if (updateUser == null) return false;
            updateUser.Address = user.Address;
            updateUser.Age = user.Age;
            updateUser.BirthDay = user.BirthDay;
            updateUser.City = user.City;
            updateUser.ESickFund = user.ESickFund;
            updateUser.EStatus = user.EStatus;
            updateUser.Name = user.Name;
            updateUser.Mail = user.Mail;
            updateUser.Phone = user.Phone;
            return (_context.SaveUsers(users));
        }

        public bool Delete(string userId)
        {
            List<User> users = _context.LoadUsers();
            User user = users.FirstOrDefault<User>(u => u.UserId == userId);
            if (user == null) return false;
            users.Remove(user);
            return _context.SaveUsers(users);
        }

        public bool Add(User user)
        {
            List<User> users = _context.LoadUsers();
            User user1 = users.FirstOrDefault<User>(u => u.UserId == user.UserId);
            if (user != null) return true;
            users.Add(user);
            return (_context.SaveUsers(users));
        }
    }
}