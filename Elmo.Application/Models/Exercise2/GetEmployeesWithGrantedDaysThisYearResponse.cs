using System.Text.Json.Serialization;

namespace Elmo.Application.Models.Exercise2
{
    public class GetEmployeesWithGrantedDaysThisYearResponse
    {
        [JsonPropertyName("employees")]
        public List<GetEmployeesWithGrantedDaysThisYearEmployee>? Employees { get; set; }

    }

    public class GetEmployeesWithGrantedDaysThisYearEmployee
    {
        [JsonPropertyName("employeeId")]
        public int Id { get; set; }

        [JsonPropertyName("employeeName")]
        public string? Name { get; set; }

        [JsonPropertyName("usedDays")]
        public int? UsedDays { get; set; }
    }


}
