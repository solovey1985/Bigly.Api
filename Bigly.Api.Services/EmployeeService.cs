using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Bigly.Api.Services.Interfaces;
using Bigly.Api.ViewModels;
using Bigly.DAL.Repositories;
using Bigly.Domain.Models;
using Bigly.Domain.Services.Factories;

namespace Bigly.Api.Services
{
    public class EmployeeService:BaseApiService<Employee>, IEmployeeService
    {
        IEmpoyeeFactory _factory;
        private IEmployeeRepository _repository;
        public EmployeeService(IEmpoyeeFactory factory, IEmployeeRepository repository) : base(factory, repository)
        {
            _factory = factory;
            _repository = repository;
        }

        public IEnumerable<EmployeeViewModel> GetAll()
        {
            return _repository.GetAll().Select(Mapper.Map<EmployeeViewModel>).ToArray();
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
