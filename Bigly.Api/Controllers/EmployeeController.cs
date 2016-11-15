using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bigly.Api.Services.Interfaces;
using Bigly.Api.ViewModels;

namespace Bigly.Api.Controllers
{
    public class EmployeeController : ApiController
    {
        private IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public IEnumerable<EmployeeViewModel> Get()
        {
            List<EmployeeViewModel> employees = _employeeService.GetAll().ToList();

            return employees;
        } 
    }

}
