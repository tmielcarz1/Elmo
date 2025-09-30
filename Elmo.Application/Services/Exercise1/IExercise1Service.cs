using Elmo.Infrastructure.Common.Models;

namespace Elmo.Application.Services.Exercise1
{
    public interface IExercise1Service
    {
        State<int?> GetSuperiorRowOfEmployee(int employeeId, int superiorId);

    }
}
