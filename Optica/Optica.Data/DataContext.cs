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
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Model> Models { get; set; } 
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Check> Checks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Data Source=DESKTOP-OP3HLHL;Initial Catalog=optica;Integrated Security=True", b => b.MigrationsAssembly("Optica.Data"));
        }
    }
}