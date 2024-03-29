using ABC.studentManagement.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ABC.studentManagement.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<StaffMember> StaffMembers { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed two admin staff members
            modelBuilder.Entity<StaffMember>().HasData(
                new StaffMember
                {
                    Id = Guid.NewGuid(),
                    FullName = "Admin 1",
                    Email = "admin1@example.com",
                    Phone = "1234567890",
                    Password = new PasswordHasher<StaffMember>().HashPassword(null, "admin1password")
                },
                new StaffMember
                {
                    Id = Guid.NewGuid(),
                    FullName = "Admin 2",
                    Email = "admin2@example.com",
                    Phone = "0987654321",
                    Password = new PasswordHasher<StaffMember>().HashPassword(null, "admin2password")
                }
            );
        }
    }
}
