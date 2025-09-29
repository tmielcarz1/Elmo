using AutoMapper;
using Elmo.Application.Models.Exercise3;
using Elmo.Domain.Entities;
using Elmo.Infrastructure.Common.Models;
using Elmo.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elmo.Application.Services.Exercise3
{
    public class Exercise3Service : IExercise3Service
    {

        private readonly ElmoDbContext _context;
        private readonly IMapper _mapper;

        public Exercise3Service(ElmoDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<State<GetEmployeeRemainingVacationThisYearResponse>> GetEmployeeRemainingVacationThisYearResponse(int employeeId)
        {
            var state = new State<GetEmployeeRemainingVacationThisYearResponse>();
            
            try
            {
                var employee = new Employee();
                var vacationPackage = new VacationPackage();
                employee = await _context.Employees
                    .Include(e => e.VacationPackage)
                    .Include(e => e.Vacations)
                    .FirstOrDefaultAsync(e => e.Id == employeeId);

                if (employee == null)
                {
                    state.AddError($"Nie znaleziono pracownika");
                    state.StatusCode = StatusCode.NotFound;
                    return state;
                }
                else if (employee.VacationPackage == null)
                {
                    state.AddError($"Pracownik nie ma puli dni wolnych w tym roku");
                    state.StatusCode = StatusCode.BadRequest;
                    return state;
                }

                vacationPackage = employee.VacationPackage;

                var vacationsCurrentYear = employee.Vacations
                    .Where(v => v.DateSince.Year == DateTime.Now.Year)
                    .ToList();

                if (vacationsCurrentYear == null)
                {
                    state.AddError($"Pracownik nie zużytych dni wolnych w tym roku");
                    state.StatusCode = StatusCode.BadRequest;
                    return state;
                }

                int freeDays = CountFreeDaysForEmployee(employee, vacationsCurrentYear, vacationPackage);

                state.StateObject = new GetEmployeeRemainingVacationThisYearResponse()
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    FreeDays = freeDays,
                };
            }
            catch (Exception ex)
            {
                state.AddError($"Błąd {ex.Message}");
                state.StatusCode = StatusCode.BadRequest;
            }

            return state;
        }

        public int CountFreeDaysForEmployee(Employee employee, List<Vacation> vacations, VacationPackage vacationPackage)
        {
            double usedDays = 0;

            foreach (var vacation in vacations)
            {
                if (!vacation.IsPartialVacation)
                    usedDays += (vacation.DateUntil.Date - vacation.DateSince.Date).TotalDays + 1;
                else
                    usedDays += vacation.NumberOfHours / 8.0;
            }
            double freeDays = vacationPackage.GrantedDays - usedDays;

            return freeDays > 0 ? (int)Math.Floor(freeDays) : 0;
        }


    }
}
