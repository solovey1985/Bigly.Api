using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Bigly.Api.Services;
using Bigly.DAL.Repositories;
using Bigly.Domain.Models;
using Bigly.Api.ViewModels;

namespace Bigly.Api.Services
{
    public class SalaryService :BaseApiService<Salary>, ISalaryService, IDisposable
    {
        private ISalaryRepository _salaryRepository;

        public SalaryService(ISalaryRepository salaryRepository)
        {
            _salaryRepository = salaryRepository;
        }

        public void BatchUpdate(List<SalaryViewModel> salariesToUpdate)
        {
            if (salariesToUpdate != null && salariesToUpdate.Any())
                _salaryRepository.BatchUpdate(salariesToUpdate.Select(vm => Mapper.Map<Salary>(vm)).ToList());


        }

        public IEnumerable<SalaryViewModel> BatchInsert(List<SalaryViewModel> salariesToUpdate)
        {
            if (salariesToUpdate != null && salariesToUpdate.Any())
                _salaryRepository.BatchInsert(salariesToUpdate.Select(vm => Mapper.Map<Salary>(vm)).ToList());

            return salariesToUpdate;
        }

        public IEnumerable<SalaryViewModel> GetAllWithEmployees()
        {
            List<Salary> domainModels = _salaryRepository.GetAllWithEmployees().ToList();

            return domainModels.Select(Mapper.Map<SalaryViewModel>).ToList();
        } 
        public IEnumerable<SalaryViewModel> GetPerMonthByEmloyeeId(int employeeId)
        {
            List<Salary> domainModels = _salaryRepository.GetAll().ToList();
            List<SalaryViewModel> viewModels = new List<SalaryViewModel>(domainModels.Count());

            viewModels.AddRange(domainModels.Select(Mapper.Map<SalaryViewModel>));

            return viewModels;
        }

        public void Update(SalaryViewModel salaryToUpdate)
        {
            
        }

        public IEnumerable<SalaryViewModel> GetPerMonth()
        {
            List<SalaryViewModel> salaries = _salaryRepository.GetAll().Select(Mapper.Map<SalaryViewModel>).ToList();
            return salaries;
        }
        #region DISPOSE


        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _salaryRepository.Dispose();
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}