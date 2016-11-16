using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using Bigly.DAL.Contexts;
using Bigly.Domain.Models;

namespace Bigly.DAL.Migrations.User
{
    internal sealed class EmployeeConfiguration : DbMigrationsConfiguration<EmployeeContext>
    {
        public EmployeeConfiguration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\Employee";
        }
        

        protected override void Seed(EmployeeContext context)
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
            string[] firstNames = new[] {"John", "Jack", "Sally"};
            string[] lastNames = new[] {"Smith", "Black", "Lee"};
            for (int i = 0; i < 3; i++)
            {
                Employee e = new Employee();
                e.FirstName = firstNames[i];
                e.LastName = lastNames[i];
                e.Id = i + 1;
                e.Rate = GetRandomRate(e.Id);
                e.RateId = e.Rate.Id;
                e.Salaries = GetRandomSalariesForEmployee(e.Id);
                context.Employees.Add(e);
            }
            context.SaveChanges();
            //
        }

        private List<Salary> GetRandomSalariesForEmployee(int employeeId)
        {
            List<Salary> salaries = new List<Salary>();
            for (int i = 0; i < 3; i++)
            {
                DateTime since = DateTime.Now.AddMonths(-i-1);
                DateTime till = DateTime.Now.AddMonths(-i);
                Salary s = new Salary() {EmployeeId = employeeId,
                    Id = employeeId*(i+2),
                    Period = new PaymentPeriod() {Since = since, Till = till},
                    PaidAmount =  employeeId*12000
                };
                salaries.Add(s);
            }
           return salaries;
        }

        private Rate GetRandomRate(int employeeId)
        {
           return new Rate() {AmountPerHour = employeeId*12, EmployeePosition = "Manager Level " + employeeId, Id = employeeId*2 };
        }
    }
}
