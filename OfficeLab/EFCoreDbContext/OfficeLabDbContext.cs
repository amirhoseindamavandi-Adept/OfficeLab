using Microsoft.EntityFrameworkCore;
using OfficeLab.Models;

namespace OfficeLab.EFCoreDbContext
{
    public class OfficeLabDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasKey(q => q.EmployeeId);
            modelBuilder.Entity<Employee>().Property(q => q.EmployeeName).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Employee>().Property(q => q.EmployeeFamily).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Employee>().Property(q => q.EmployeeBirthday).IsRequired();
            modelBuilder.Entity<Employee>().Property(q => q.IsDeleted);
            modelBuilder.Entity<Employee>().Property(q => q.NationalCode).IsRequired().HasMaxLength(10);
            modelBuilder.Entity<Employee>().Property(q => q.PhoneNumber).IsRequired().HasMaxLength(11);
            modelBuilder.Entity<Employee>().Property(q => q.StartWork).IsRequired();
        }
        public OfficeLabDbContext(DbContextOptions<OfficeLabDbContext> options) : base(options) { }

    }

}
