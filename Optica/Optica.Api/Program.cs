using Optica.Core.Entites;
using Optica.Core.IRepositories;
using Optica.Core.IServices;
using Optica.Data;
using Optica.Data.Repositories;
using Optica.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IService<User>,UserService>();
builder.Services.AddScoped<IRepository<User>, UserRepository>();
builder.Services.AddScoped<IService<Order>,OrderService>();
builder.Services.AddScoped<IRepository<Order>, OrderRepository>();
builder.Services.AddScoped<IService<Model>,ModelService>();
builder.Services.AddScoped<IRepository<Model>, ModelRepository>();
builder.Services.AddScoped<IService<Discount>,DiscountService>();
builder.Services.AddScoped<IRepository<Discount>, DiscountRepository>();
builder.Services.AddScoped<IService<Check>,CheckService>();
builder.Services.AddScoped<IRepository<Check>, CheckRepository>();
builder.Services.AddSingleton<DataContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
