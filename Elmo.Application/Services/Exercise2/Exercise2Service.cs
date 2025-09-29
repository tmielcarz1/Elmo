using AutoMapper;
using AutoMapper.QueryableExtensions;
using Elmo.Application.Models.Exercise2;
using Elmo.Infrastructure.Common.Models;
using Elmo.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elmo.Application.Services.Exercise2
{
    public class Exercise2Service : IExercise2Service
    {
        private readonly ElmoDbContext _context;
        private readonly IMapper _mapper;

        public Exercise2Service(ElmoDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<State<GetEmployeesWithVacationIn2019Response>> GetEmployeesWithVacationIn2019()
        {
            var state = new State<GetEmployeesWithVacationIn2019Response>();

            try
            {
                var employees = await _context.Employees
                    .Include(a => a.Vacations)
                    .Where(a => a.Team != null &&
                        a.Team.Name == ".NET" &&
                        a.Vacations.Any(v => v.DateSince.Year == 2019 || v.DateUntil.Year == 2019))
                    .ToListAsync();

                if (employees.Count == 0)
                {
                    state.AddError($"Nie znaleziono");
                    state.StatusCode = StatusCode.NotFound;
                    return state;
                }

                state.StateObject = new GetEmployeesWithVacationIn2019Response
                {
                    Employees = _mapper.Map<List<GetEmployeesWithVacationIn2019Employee>>(employees)
                };
            }
            catch (Exception ex)
            {
                state.AddError($"Błąd {ex.Message}");
                state.StatusCode = StatusCode.BadRequest;
            }
            return state;
        }

        public async Task<State<GetEmployeesWithGrantedDaysThisYearResponse>> GetEmployeesWithGrantedDaysThisYear()
        {
            var state = new State<GetEmployeesWithGrantedDaysThisYearResponse>();

            try
            {
                var employees = await _context.Employees
                    .Include(a => a.Vacations)
                    .Where(e => e.Vacations.Any(v => v.DateUntil.Year == DateTime.Now.Year && v.DateUntil < DateTime.Now))
                    .Select(a => new GetEmployeesWithGrantedDaysThisYearEmployee
                    {
                        Id = a.Id,
                        Name = a.Name,
                        UsedDays = a.Vacations
                            .Where(b => b.DateUntil.Year == DateTime.Now.Year && b.DateUntil < DateTime.Now)
                            .Sum(b => ((int?)EF.Functions.DateDiffDay(b.DateSince, b.DateUntil)) + 1) ?? 0
                    })
                    .ToListAsync();

                if (employees.Count == 0)
                {
                    state.AddError($"Nie znaleziono");
                    state.StatusCode = StatusCode.NotFound;
                    return state;
                }

                state.StateObject = new GetEmployeesWithGrantedDaysThisYearResponse() { Employees = employees };
            }
            catch (Exception ex)
            {
                state.AddError($"Błąd {ex.Message}");
                state.StatusCode = StatusCode.BadRequest;
            }
            return state;
        }

        public async Task<State<GetTeamsWithoutVacationIn2019Response>> GetTeamsWithoutVataionIn2019()
        {
            var state = new State<GetTeamsWithoutVacationIn2019Response>();

            try
            {
                var teams = await _context.Teams
                    .Where(t => !t.Employees.Any(e => e.Vacations.Any(v => v.DateSince.Year == 2019 || v.DateUntil.Year == 2019)))
                    .ToListAsync();

                if (teams.Count == 0)
                {
                    state.AddError($"Nie znaleziono");
                    state.StatusCode = StatusCode.NotFound;
                    return state;
                }

                state.StateObject = new GetTeamsWithoutVacationIn2019Response
                {
                    Teams = _mapper.Map<List<GetTeamsWithoutVacationIn2019Team>>(teams)
                };
            }
            catch(Exception ex)
            {
                state.AddError($"Błąd {ex.Message}");
                state.StatusCode = StatusCode.BadRequest;
            }
            return state;
        }


    }
}
