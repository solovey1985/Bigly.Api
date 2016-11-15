using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Bigly.Api.Services;
using Bigly.Domain.Models;
using Bigly.GUI.ViewModels;

namespace Bigly.Api.Controllers
{

    public class SalaryController:ApiController
    {
        private ISalaryService _salaryService;

       
        public SalaryController(ISalaryService salaryService)
        {
            _salaryService = salaryService;
        }

        public IEnumerable<SalaryViewModel> Get()
        {
            List<SalaryViewModel> allSalaries = _salaryService.GetAllWithEmployees().ToList();
            return allSalaries;
        }

        public IEnumerable<SalaryViewModel> Get(int employeeId)
        {
            List<SalaryViewModel> salriesPerMonth = _salaryService.GetPerMonthByEmloyeeId(employeeId).ToList();
            return salriesPerMonth;
        }

        public List<SalaryViewModel> Put([FromBody] List<SalaryViewModel> models)
        {
            _salaryService.BatchUpdate(models.ToList());
            return models.ToList();
        }

        public IEnumerable<SalaryViewModel> Post([FromBody] List<SalaryViewModel> salariesToCreate)
        {
            _salaryService.BatchUpdate(salariesToCreate);
            return salariesToCreate;
        }  
    }
}