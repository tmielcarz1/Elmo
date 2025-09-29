using AutoMapper;
using Elmo.Application.Models.Exercise2;
using Elmo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elmo.Application.Mapper
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<Team, GetTeamsWithoutVacationIn2019Team>();
            CreateMap<Employee, GetEmployeesWithGrantedDaysThisYearEmployee>();
            CreateMap<Employee, GetEmployeesWithVacationIn2019Employee>();

        }

    }
}
