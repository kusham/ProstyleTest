using ABC.studentManagement.API.Models;
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
                    Id = 1,
                    FullName = "Admin 1",
                    Department = "Administration",
                    Email = "admin1@example.com",
                    Phone = "1234567890"
                },
                new StaffMember
                {
                    Id = 2,
                    FullName = "Admin 2",
                    Department = "Administration",
                    Email = "admin2@example.com",
                    Phone = "0987654321"
                }
            );
        }
    }
}
