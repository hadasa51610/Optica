using Optica.Core.Entites;
using Optica.Core.IRepositories;
using Optica.Core.IServices;
using Optica.Data;
using Optica.Data.Repositories;
using Optica.Service;

namespace Optica.Api
{
    public static class ExtensionDependency
    {
        public static void addDependency(this IServiceCollection services)
        {
            services.AddScoped<IService<User>, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IService<Order>, OrderService>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            services.AddScoped<IService<Model>, ModelService>();
            services.AddScoped<IModelRepository, ModelRepository>();

            services.AddScoped<IService<Discount>, DiscountService>();
            services.AddScoped<IDiscountRepository, DiscountRepository>();

            services.AddScoped<IService<Check>, CheckService>();
            services.AddScoped<ICheckRepository, CheckRepository>();

            services.AddScoped<IRepositoryManager, RepositoryManager>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddDbContext<DataContext>();
            // services.AddSingleton<DataContext>();
            services.AddControllers();
        }
    }
}