using Elmo.Application.Models.Exercise1;
using Elmo.Infrastructure.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elmo.Application.Services.Exercise1
{
    public interface IExercise1Service
    {
        State<int?> GetSuperiorRowOfEmployee(int employeeId, int superiorId);
       
    }
}
