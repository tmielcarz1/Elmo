using Elmo.Application.Models.Exercise3;
using Elmo.Domain.Entities;
using Elmo.Infrastructure.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elmo.Application.Services.Exercise4
{
    public interface IExercise4Service
    {
        Task<State<bool>> IsEmployeeCanRequestVacation(int employeeId);
    }
}
