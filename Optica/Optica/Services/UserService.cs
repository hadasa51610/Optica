using Optica.Entities;

namespace Optica.Services
{
    public class UserService
    {
        readonly IDataContext _context;
        public UserService(IDataContext context) => _context = context;

        public List<User> GetAll() => _context.LoadUsers();

        public User GetByUserId(string id) => _context.LoadUsers().FirstOrDefault<User>((u) => u.UserId == id);

        public bool PostUser(User user)
        {
            if (GetByUserId(user.UserId) != null) return true;
            List<User> users = _context.LoadUsers();
            users.Add(user);
            return (_context.SaveUsers(users));
        }

        public bool PutUser(string id, User user)
        {
            List<User> users = _context.LoadUsers();
            User updateUser = users.Find((u) => u.UserId == id);
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
            users.Add(updateUser);
            return (_context.SaveUsers(users));
        }
        public bool DeleteUser(string id)
        {
            List<User> users= _context.LoadUsers();
            User user = users.Find((u) => u.UserId==id);
            if(user == null) return false;
            users.Remove(user);
            return _context.SaveUsers(users);
        }
    }
}
