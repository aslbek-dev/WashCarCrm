using WashCarCrm.Infrastructure.Context;
using WashCarCrm.Application.Foundations.WashCompanies;
using WashCarCrm.Application.Foundations.Orders;
using WashCarCrm.Application.Foundations.Services;
using WashCarCrm.Application.Foundations.Users;
using WashCarCrm.Application.Foundations.Washers;
using WashCarCrm.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
string connectionString = builder.Configuration.GetConnectionString("SqlServerConnectionString");

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(option=>
option.UseSqlServer(connectionString));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

builder.Services.AddTransient<IWashCompanyService, WashCompanyService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IServiceService, ServiceService>();
builder.Services.AddTransient<IWasherService, WasherService>();

builder.Services.AddTransient<IWashCompanyRepository, WashCompanyRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IWasherRepository, WasherRepository>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<IServiceService, ServiceService>();
