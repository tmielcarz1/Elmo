using Elmo.Application.Models.Exercise1;
using Elmo.Infrastructure.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Elmo.Application.Services.Exercise1
{
    public class Exercise1Service : IExercise1Service
    {

        private readonly Dictionary<(int, int), int> employeesDictionary = new Dictionary<(int, int), int>();
        private static List<Employee> employees = new List<Employee>()
        {
            new Employee { Id = 1, Name = "Jan Kowalski", SuperiorId = null },
            new Employee { Id = 2, Name = "Kamil Nowak", SuperiorId = 1 },
            new Employee { Id = 3, Name = "Anna Mariacka", SuperiorId = 1 },
            new Employee { Id = 4, Name = "Andrzej Abacki", SuperiorId = 2 },
        };

        public Exercise1Service()
        {
            employeesDictionary = FillEmployeesStructure(employees);
        }

        private static Dictionary<(int, int), int> FillEmployeesStructure(List<Employee> employeeList)
        {
            var result = new Dictionary<(int, int), int>();
            var employeesById = employeeList.ToDictionary(e => e.Id);

            foreach (var item in employeeList)
            {
                int row = 1;
                var superiorId = item.SuperiorId;

                while (superiorId.HasValue)
                {
                    result[(item.Id, superiorId.Value)] = row;
                    var superior = employeesById[superiorId.Value];
                    superiorId = superior.SuperiorId;
                    row++;
                }
            }
            return result;
        }

        public State<int?> GetSuperiorRowOfEmployee(int employeeId, int superiorId)
        {
            var state = new State<int?>();

            try
            {
                int? rows = employeesDictionary.TryGetValue((employeeId, superiorId), out var row) ? row : null;
                if (!rows.HasValue)
                {
                    state.AddError($"Nie znaleziono poziomów przełożonego dla employeeId {employeeId} i superiorId {superiorId}.");
                    state.StatusCode = StatusCode.NotFound;
                    return state;
                }

                state.StateObject = rows;
            }
            catch (Exception ex)
            {
                state.AddError($"Błąd {ex.Message}");
                state.StatusCode = StatusCode.BadRequest;
            }
            return state;
        }
    }
}
