using System.Text.Json.Serialization;

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
