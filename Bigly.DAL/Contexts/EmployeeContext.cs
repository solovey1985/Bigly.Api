using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using Bigly.Domain.Models;

namespace Bigly.DAL.Contexts
{
    public class EmployeeContext:BaseDbContext<EmployeeContext>
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Rate> Rates { get; set; }
        public DbSet<Salary> Salaries { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Employee>().Property(e => e.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity); ;
            modelBuilder.Entity<Employee>().Ignore(t => t.State);
            modelBuilder.Entity<Employee>().HasRequired(e => e.Rate)
                .WithMany(r => r.Employees).HasForeignKey(e => e.RateId);
            modelBuilder.Entity<Employee>().HasOptional(e => e.Salaries);
            modelBuilder.Entity<Employee>().HasMany<Salary>(p => p.Salaries);
            

            modelBuilder.Entity<Rate>().HasKey(r => r.Id);
            modelBuilder.Entity<Rate>().Ignore(p => p.State);

            modelBuilder.Entity<Salary>()
                .Property(s => s.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Salary>()
                .HasRequired(s => s.Employee)
                .WithMany(e => e.Salaries)
                .HasForeignKey(e => e.EmployeeId);
            modelBuilder.Entity<Salary>().Ignore(p=>p.State);
            

            base.OnModelCreating(modelBuilder);
            
        }
    }
}
