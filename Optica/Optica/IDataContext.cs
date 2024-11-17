using Optica.Entities;

namespace Optica
{
    public interface IDataContext
    {
        public List<User> LoadUsers();
        public bool SaveUsers(List<User> users);
    }
}
