using System.Data.Entity.Migrations;
using Bigly.DAL.Contexts;

namespace Bigly.DAL.Migrations.Trip
{
    internal sealed class TripConfiguration : DbMigrationsConfiguration<SalaryContext>
    {
        public TripConfiguration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\Salary";
        }

        protected override void Seed(SalaryContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
