using Elmo.Domain.Entities;
using Elmo.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elmo.Infrastructure.Repositories.Exercise4
{
    public class Exercise4Repository : IExercise4Repository
    {
        private readonly ElmoDbContext _context;

        public Exercise4Repository(ElmoDbContext context)
        {
            _context = context;
        }

        public async Task<Employee?> GetEmployeeById(int employeeId)
        {
            return await _context.Employees
                    .Include(e => e.VacationPackage)
                    .Include(e => e.Vacations)
                    .FirstOrDefaultAsync(e => e.Id == employeeId);
        }
    }
}
