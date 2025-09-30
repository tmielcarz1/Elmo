using Elmo.Domain.Entities;

namespace Elmo.Infrastructure.Repositories.Exercise4
{
    public interface IExercise4Repository
    {
        Task<Employee?> GetEmployeeById(int employeeId);
    }
}
