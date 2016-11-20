#region Using

using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using Bigly.Domain.Models;

#endregion

namespace Bigly.DAL.Contexts
{
    public class SalaryContext : BaseDbContext<SalaryContext>
    {
        public DbSet<Salary> Salaries { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Rate> Rates { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Salary>()
                .Property(s => s.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Salary>().Ignore(u => u.State);

            modelBuilder.Entity<Employee>().Ignore(e => e.State);

            modelBuilder.Entity<Rate>()
                .Property(r=>r.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Rate>().Ignore(r => r.State);

            modelBuilder.Entity<Employee>()
                .HasRequired(e => e.Rate)
                .WithMany(x=>x.Employees)
                .HasForeignKey(e=>e.RateId);
        }
    }
}
