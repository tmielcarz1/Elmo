using Elmo.Application.Models.Exercise2;
using Elmo.Infrastructure.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elmo.Application.Services.Exercise2
{
    public interface IExercise2Service
    {
        Task<State<GetEmployeesWithVacationIn2019Response>> GetEmployeesWithVacationIn2019();
        Task<State<GetEmployeesWithGrantedDaysThisYearResponse>> GetEmployeesWithGrantedDaysThisYear();
        Task<State<GetTeamsWithoutVacationIn2019Response>> GetTeamsWithoutVataionIn2019();

    }
}
