using Microsoft.EntityFrameworkCore;
using Optica.Core.Entites;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Optica.Data
{
    public class DataContext:DbContext
    {
        public DbSet<User> users { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<Model> models { get; set; } 
        public DbSet<Discount> discounts { get; set; }
        public DbSet<Check> checks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Data Source=DESKTOP-OP3HLHL;Initial Catalog=optica;Integrated Security=True", b => b.MigrationsAssembly("Optica.Api"));
            builder.LogTo(message => Debug.WriteLine(message));
        }
        #region json
        //    public string JsonPath(string sort)
        //    {
        //        return Path.Combine("G:\\Optica- new\\Optica.Data", "Json", sort);
        //    }

        //    public List<User> LoadUsers()
        //    {
        //        string usersJson = File.ReadAllText(JsonPath("userJson.json"));
        //        return JsonSerializer.Deserialize<List<User>>(usersJson);
        //    }

        //    public bool SaveUsers(List<User> users)
        //    {
        //        try
        //        {
        //            string path = JsonPath("userJson.json");
        //            string userJson = JsonSerializer.Serialize(users);
        //            if (File.Exists(path))
        //            {
        //                File.Delete(path);
        //            }
        //            File.WriteAllText(path, userJson);
        //            return true;
        //        }
        //        catch { return false; }
        //    }
        //    public List<Order> LoadOrder()
        //    {
        //        string ordersJson = File.ReadAllText(JsonPath("orderJson.json"));
        //        return JsonSerializer.Deserialize<List<Order>>(ordersJson);
        //    }

        //    public bool SaveOrders(List<Order> orders)
        //    {
        //        try
        //        {
        //            string path = JsonPath("orderJson.json");
        //            string orderJson = JsonSerializer.Serialize(orders);
        //            if (File.Exists(path))
        //            {
        //                File.Delete(path);
        //            }
        //            File.WriteAllText(path, orderJson);
        //            return true;
        //        }
        //        catch { return false; }
        //    }
        //    public List<Model> LoadModel()
        //    {
        //        string modelsJson = File.ReadAllText(JsonPath("modelJson.json"));
        //        return JsonSerializer.Deserialize<List<Model>>(modelsJson);
        //    }

        //    public bool SaveModel(List<Model> models)
        //    {
        //        try
        //        {
        //            string path = JsonPath("modelJson.json");
        //            string modelJson = JsonSerializer.Serialize(models);
        //            if (File.Exists(path))
        //            {
        //                File.Delete(path);
        //            }
        //            File.WriteAllText(path, modelJson);
        //            return true;
        //        }
        //        catch { return false; }
        //    }
        //    public List<Discount> LoadDiscount()
        //    {
        //        string discountsJson = File.ReadAllText(JsonPath("discountJson.json"));
        //        return JsonSerializer.Deserialize<List<Discount>>(discountsJson);
        //    }

        //    public bool SaveDiscount(List<Discount> discounts)
        //    {
        //        try {
        //            string path = JsonPath("discountJson.json");
        //            string discountsJson = JsonSerializer.Serialize(discounts);
        //            if (File.Exists(path))
        //            {
        //                File.Delete(path);
        //            }
        //            File.WriteAllText(path, discountsJson);
        //            return true;
        //        }
        //        catch { return false; }
        //    }
        //    public List<Check> LoadCheck()
        //    {
        //        string checksJson = File.ReadAllText(JsonPath("checkJson.json"));
        //        return JsonSerializer.Deserialize<List<Check>>(checksJson);
        //    }

        //    public bool SaveCheck(List<Check> checks)
        //    {
        //        try {
        //            string path = JsonPath("checkJson.json");
        //            string checkJson = JsonSerializer.Serialize(checks);
        //            if (File.Exists(path))
        //            {
        //                File.Delete(path);
        //            }
        //            File.WriteAllText(path, checkJson);
        //            return true;
        //        }
        //        catch { return false; }
        //    }
        #endregion
    }
}