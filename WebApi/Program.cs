using System.Text;
using Application;
using Application.Abouts;
using Application.Categories;
using Application.Contacts;
using Application.Customers;
using Application.PaymentLogs;
using Application.ShopSettings;
using Application.Transactions;
using Data;
using Data.Aboutes;
using Data.Categories;
using Data.Contacts;
using Data.Customers;
using Data.PaymentLogs;
using Data.Repositories;
using Data.Repositorys;
using Data.Services;
using Data.Services.JwtToken;
using Data.ShopSettings;
using Data.Transactions;
using Infrastructure.Extensions.Services;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add controllers
builder.Services.AddControllers();

// Configure PostgreSQL DbContext
builder.Services.AddDbContext<DataContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Default")));

// Dependency Injection registrations
builder.Services.AddTransient<IAboutApplication, AboutApplication>();
builder.Services.AddTransient<IAboutRepository, AboutRepository>();
builder.Services.AddTransient<ICustomerApplication, CustomerApplication>();
builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
builder.Services.AddTransient<IPaymentLogRepository, PaymentLogRepository>();
builder.Services.AddTransient<IPaymentLogApplication, PaymentLogApplication>();
builder.Services.AddTransient<IShopSettingRepository, ShopSettingRepository>();
builder.Services.AddTransient<IShopSettingApplication, ShopSettingApplication>();
builder.Services.AddTransient<ITransactionRepository, TransactionRepository>();
builder.Services.AddTransient<ITransactionApplication, TransactionApplication>();
builder.Services.AddTransient<IFileService, FileService>();
builder.Services.AddTransient<IEmailService, EmailService>();
builder.Services.AddTransient<IAuthService, AuthService>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IOtpRepository, OtpRepository>();
builder.Services.AddTransient<IJwtService, JwtService>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<ICategoryApplication, CategoryApplication>();
builder.Services.AddTransient<IContactRepository, ContactRepository>();
builder.Services.AddTransient<IContactApplication, ContactApplication>();


// Swagger & API Explorer
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Web API",
        Version = "v1"
    });

    // JWT Bearer setup for Swagger UI (lock icon)
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: 'Bearer {token}'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
});

// JWT Authentication
var secretKey = builder.Configuration["JwtSettings:SecretKey"] ?? "SuperSecretKey123!";
var keyBytes = Encoding.UTF8.GetBytes(secretKey);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(keyBytes)
        };
    });

builder.Services.AddAuthorization();

var app = builder.Build();

// Swagger UI (development only)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Web API v1");
    });
}

// HTTPS redirection
app.UseHttpsRedirection();

// Ensure wwwroot/uploads exists
var webRoot = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
if (!Directory.Exists(webRoot))
{
    Directory.CreateDirectory(webRoot);
}
app.UseStaticFiles();

// Authentication & Authorization
app.UseAuthentication();
app.UseAuthorization();

// Map controllers
app.MapControllers();

// Run the app
app.Run();