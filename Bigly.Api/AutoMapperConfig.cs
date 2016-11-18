using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Bigly.Api.ViewModels;
using Bigly.Domain.Models;
using Bigly.GUI.ViewModels;

namespace Bigly.Api
{
    internal static class AutoMapperConfig
    {
        internal static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<SalaryProfile>();
                cfg.AddProfile<EmployeeProfile>();
             });
        }
    }

    internal class EmployeeProfile:Profile {
        protected override void Configure()
        {
            CreateMap<Employee, EmployeeViewModel>()
                .ForMember(dest=>dest.Position, opt=>opt.MapFrom(src=>src.Rate.EmployeePosition));
            CreateMap<EmployeeViewModel, Employee>()
                ;
        }
    }

    internal class SalaryProfile : Profile
    {


        protected override void Configure()
        {
            CreateMap<SalaryViewModel, Salary>()
                .ForMember(dest=>dest.Period, opt=>opt.ResolveUsing(src=> new  PaymentPeriod(src.Since,src.Till)))
                ;
                
            CreateMap<Salary, SalaryViewModel>()
                    .ForMember(m => m.Since, opt => opt.MapFrom(x => x.Period.Since))
                    .ForMember(m => m.Till, opt => opt.MapFrom(x => x.Period.Till))
                    .ForMember(m => m.FirstName, opt => opt.MapFrom(x => x.Employee.FirstName))
                    .ForMember(m => m.LastName, opt => opt.MapFrom(x => x.Employee.LastName))

                    ;
        }
    }

}