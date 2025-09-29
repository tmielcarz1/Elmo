using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Elmo.Application.Models.Exercise2
{
    public class GetEmployeesWithVacationIn2019Response
    {
        [JsonPropertyName("employees")]
        public List<GetEmployeesWithVacationIn2019Employee>? Employees { get; set; }

    }

    public class GetEmployeesWithVacationIn2019Employee//
    {
        [JsonPropertyName("employeeId")]
        public int Id { get; set; }

        [JsonPropertyName("employeeName")]
        public string? Name { get; set; }
    }
}
