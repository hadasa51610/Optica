using Optica.Entities;

namespace Optica.Services
{
    public class UserService
    {
        static List<User> Users { get; }
        public UserService() { }
        static UserService() { 
            Users = new List<User>();
        }
        public List<User> GetAll()
        {
            return Users;
        }
        public User GetByUserId(string id)
        {
            foreach (var user in Users)
            {
                if(user.UserId==id)
                    return user;
            }
            return null;
        }
        public void PostUser(User user)
        {
            Users.Add(user);
        }
        public void PutUser(string id,User user)
        {
            for (int i = 0; i < Users.Count; i++)
            {
                if (Users[i].UserId==id)
                    Users[i] = user;
            }
        }
        public void DeleteUser(string id)
        {
            foreach (var user in Users)
            {
                if (user.UserId == id)
                {
                    Users.Remove(user);
                    return;
                }
            }
        }
    }
}
