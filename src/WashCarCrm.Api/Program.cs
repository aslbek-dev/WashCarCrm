using WashCarCrm.Infrastructure.Context;
using WashCarCrm.Application.Foundations.WashCompanies;
using WashCarCrm.Application.Foundations.Orders;
using WashCarCrm.Application.Foundations.Services;
using WashCarCrm.Application.Foundations.Users;
using WashCarCrm.Application.Foundations.Washers;
using WashCarCrm.Application.Services.Foundations.Securities;
using WashCarCrm.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using WashCarCrm.Application.Services.Orchestrations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WashCarCrm.Application.Services.Processings;

var builder = WebApplication.CreateBuilder(args);
string connectionString = builder.Configuration.GetConnectionString("SqlServerConnectionString");

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(option=>
option.UseInMemoryDatabase("AutoDb"));

// Sql serverni ishlatmoqchi bo'lsangiz pastdagi 2 ta qatorni commentdan chiqaring
// va yuqoridagi 2 ta qatorni commentga oling

// builder.Services.AddDbContext<AppDbContext>(option =>
// option.UseSqlServer(connectionString));

builder.Services.AddScoped<IWashCompanyRepository, WashCompanyRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IWasherRepository, WasherRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<IImageRepository, ImageRepository>();
builder.Services.AddScoped<ITokenRepository, TokenRepository>();

builder.Services.AddScoped<IWashCompanyService, WashCompanyService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IServiceService, ServiceService>();
builder.Services.AddScoped<IWasherService, WasherService>();
builder.Services.AddTransient<ISecurityService, SecurityService>();
builder.Services.AddTransient<IUserSecurityOrchestrationService, UserSecurityOrchestrationsService>();
builder.Services.AddTransient<IUserProcessingService, UserProcessingService>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});
    

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => 
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger v1");
        c.RoutePrefix = String.Empty;
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

