using ABC.studentManagement.API.Data;
using ABC.studentManagement.API.IRepositories;
using ABC.studentManagement.API.IServices;
using ABC.studentManagement.API.Models;
using ABC.studentManagement.API.Repositories;
using ABC.studentManagement.API.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(
    option => option.UseMySQL(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        mySqlOptions =>
        {
            mySqlOptions.EnableRetryOnFailure(
                maxRetryCount: 5,  // Adjust the maximum number of retry attempts as needed
                maxRetryDelay: TimeSpan.FromSeconds(30),  // Adjust the maximum delay between retries as needed
                errorNumbersToAdd: null);
        }));

builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddScoped<IPasswordHasher<StaffMember>, PasswordHasher<StaffMember>>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
