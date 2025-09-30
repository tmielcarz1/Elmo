using Elmo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elmo.Infrastructure.Repositories.Exercise4
{
    public interface IExercise4Repository
    {
        Task<Employee?> GetEmployeeById(int employeeId);
    }
}
