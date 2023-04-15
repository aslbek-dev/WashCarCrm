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

builder.Services.AddScoped<IWashCompanyRepository, WashCompanyRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IWasherRepository, WasherRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<IImageRepository, ImageRepository>();



builder.Services.AddScoped<IWashCompanyService, WashCompanyService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IServiceService, ServiceService>();
builder.Services.AddScoped<IWasherService, WasherService>();


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

// builder.Services.AddScoped<IWashCompanyService, WashCompanyService>();
// builder.Services.AddScoped<IUserService, UserService>();
// builder.Services.AddScoped<IOrderService, OrderService>();
// builder.Services.AddScoped<IServiceService, ServiceService>();
// builder.Services.AddScoped<IWasherService, WasherService>();

// builder.Services.AddScoped<IWashCompanyRepository, WashCompanyRepository>();
// builder.Services.AddScoped<IUserRepository, UserRepository>();
// builder.Services.AddScoped<IWasherRepository, WasherRepository>();
// builder.Services.AddScoped<IOrderRepository, OrderRepository>();
// builder.Services.AddScoped<IServiceService, ServiceService>();
