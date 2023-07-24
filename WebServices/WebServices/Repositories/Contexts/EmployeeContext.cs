using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using BOL;
using Microsoft.Extensions.Logging;

namespace Repositories.Contexts
{
    public class EmployeeContext : DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string? _conString;

        public EmployeeContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _conString = this._configuration.GetConnectionString("DefaultConnection")
                ?? throw new ArgumentNullException(nameof(configuration));
        }

        //Table Mapped DBSet Entities
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(
                _conString ?? throw new InvalidOperationException("Connection string is null")
                ) ;
            optionsBuilder.LogTo(Console.WriteLine,LogLevel.Information) ;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>(entity =>
            {
                // empId | name  | email  | password | location    | joinDate   | salary
                entity.HasKey(e => e.EmpId);
                entity.Property(e => e.Name);
                entity.Property(e => e.Email);
                entity.Property(e => e.Password);
                entity.Property(e => e.Location);
                entity.Property(e => e.JoinDate);
                entity.Property(e => e.Salary);
                modelBuilder.Entity<Employee>().ToTable("employees");
            });
        }
    }
}
