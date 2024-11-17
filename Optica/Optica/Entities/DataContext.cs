using System.Text.Json;

namespace Optica.Entities
{
    public class DataContext:IDataContext
    {
        public List<Checks> ChecksList { get; set; } = new List<Checks>();
        public List<Discount> Discounts { get; set; } = new List<Discount>();
        public List<Model> Models { get; set; } = new List<Model>();
        public List<Order> Orders { get; set; } = new List<Order>();
        //public List<User> Users { get; set; } = new List<User>();

        public List<User> LoadUsers()
        {
            string path = Path.Combine(AppContext.BaseDirectory, "Data", "UserData.json");
            string usersJson=File.ReadAllText(path);
            return JsonSerializer.Deserialize<List<User>>(usersJson);
        }

        public bool SaveUsers(List<User> users)
        {
            try
            {
                string path = Path.Combine(AppContext.BaseDirectory, "Data", "UserData.json");
                string userJson=JsonSerializer.Serialize(users);
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                File.WriteAllText(path,userJson);
                return true;
            }
            catch { return false; }
        }
    }
}
