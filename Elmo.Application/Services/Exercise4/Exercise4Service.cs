using AutoMapper;
using Elmo.Domain.Entities;
using Elmo.Infrastructure.Common.Models;
using Elmo.Infrastructure.Context;
using Elmo.Infrastructure.Repositories.Exercise4;
using Microsoft.EntityFrameworkCore;

namespace Elmo.Application.Services.Exercise4
{
    public class Exercise4Service : IExercise4Service
    {

        private readonly IExercise4Repository _repository;
        private readonly IMapper _mapper;

        public Exercise4Service(IExercise4Repository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public async Task<State<bool>> IsEmployeeCanRequestVacation(int employeeId)
        {
            var state = new State<bool>();
            
            try
            {
                var vacationPackage = new VacationPackage();
                var vacations = new List<Vacation>();
                var employee = await _repository.GetEmployeeById(employeeId);

                if (employee == null)
                {
                    state.AddError($"Nie znaleziono pracownika");
                    state.StatusCode = StatusCode.NotFound;
                    return state;
                }
                else if (employee.VacationPackage?.Year != DateTime.Now.Year || employee.VacationPackage is null)
                {
                    state.StateObject = false;
                    return state;
                }

                vacationPackage = employee.VacationPackage;

                if (employee.Vacations is not null)
                    vacations = employee.Vacations
                    .Where(v => v.DateUntil >= new DateTime(DateTime.Now.Year, 1, 1) && v.DateSince <= new DateTime(DateTime.Now.Year, 12, 31))
                    .ToList();

                state.StateObject = IfEmployeeCanRequestVacation(employee, vacations, vacationPackage);
            }
            catch (Exception ex)
            {
                state.AddError($"Błąd {ex.Message}");
                state.StatusCode = StatusCode.BadRequest;
            }

            return state;
        }

        public bool IfEmployeeCanRequestVacation(Employee employee, List<Vacation> vacations, VacationPackage vacationPackage)
        {
            double usedDays = 0;

            foreach (var vacation in vacations)
            {
                var start = vacation.DateSince < new DateTime(DateTime.Now.Year, 1, 1) ? new DateTime(DateTime.Now.Year, 1, 1) : vacation.DateSince;
                var end = vacation.DateUntil > new DateTime(DateTime.Now.Year, 12, 31) ? new DateTime(DateTime.Now.Year, 12, 31) : vacation.DateUntil;

                if (!vacation.IsPartialVacation)
                    usedDays += (end.Date - start.Date).TotalDays + 1;
                else
                    usedDays += vacation.NumberOfHours / 8.0;
            }
            double freeDays = vacationPackage.GrantedDays - usedDays;

            return freeDays > 0 ? true : false;
        }


    }
}
