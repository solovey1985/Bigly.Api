using System;
using System.Collections.Generic;
using Bigly.DAL.Repositories;
using Bigly.Domain.Models;
using Driveme.Domain.Services.Factories;

namespace Bigly.Api.Services
{
    public class EmployeeService:BaseApiService<Employee>
    {
        EmployeeFactory employeeFactory;
        public EmployeeService(BaseFactory<Employee> factory) : base(factory, new EmployeeRepository())
        {
            employeeFactory = new EmployeeFactory();
        }

        public IEnumerable<Employee> GetAll()
        {
            return repository.GetAll();
        }

        public Employee GetById(int id)
        {
            return repository.GetById(id);
        }

        public int Create(Employee employee)
        {
            employee = factory.Create(employee);
            repository.Insert(employee);
            return employee.Id;

        }

        public int Update(Employee employee)
        {
            repository.Update(employee);
            return employee.Id;
        }

        public void DeleteById(int id)
        {
            repository.DeleteById(id);
        }

        public void DeleteRoute(Guid id)
        {
            throw new NotImplementedException();
        }

        public void UpdateSalary(int EmployeeId, Salary salary)
        {
            throw new NotImplementedException();
        }

     
    }
}
