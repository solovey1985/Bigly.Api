using System.Data.Entity;
using Bigly.Domain.Models;

namespace Bigly.DAL.Contexts
{
    public class SalaryContext:BaseDbContext<SalaryContext>
    {
        public DbSet<Salary> Salaries { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Entity<Salary>().Ignore(u => u.State);


        }
    }
}
