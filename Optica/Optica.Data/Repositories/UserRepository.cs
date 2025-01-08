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
        public IEnumerable<User> GetAll() => _context.users.ToList();

        public User GetById(string id) => _context.users.FirstOrDefault(u => u.UserId == id);

        public bool Update(string userId, User user)
        {
            User updateUser = GetById(userId);
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
            User user = GetById(userId);
            if (user == null) return false;
            _context.users.Remove(user);
            _context.SaveChanges();
            return true;
        }

        public bool Add(User user)
        {
            if (GetById(user.UserId) != null) return true;
            _context.users.Add(user);
            _context.SaveChanges();
            return true;
        }
    }
}