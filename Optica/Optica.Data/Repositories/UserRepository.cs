using Optica.Core.Entites;
using Optica.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optica.Data.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context)
        {
            _context = context;
        }
        public List<User> GetAll()
        {
            return _context.users.ToList();
        }

        public User GetById(string userId)
        {
            return _context.users.FirstOrDefault<User>((u) => u.UserId == userId);
        }

        public bool Update(string userId, User user)
        {
            User updateUser = _context.users.ToList().Find((u) => u.UserId == userId);
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
            _context.SaveChanges();
            return true;
        }

        public bool Delete(string userId)
        {
            User user = _context.users.ToList().FirstOrDefault<User>(u => u.UserId == userId);
            if (user == null) return false;
            _context.users.Remove(user);
            _context.SaveChanges();
            return true;
        }

        public bool Add(User user)
        {
            User user1 = _context.users.ToList().FirstOrDefault<User>(u => u.UserId == user.UserId);
            if (user != null) return true;
            _context.users.Add(user);
            _context.SaveChanges();
            return true;
        }
    }
}