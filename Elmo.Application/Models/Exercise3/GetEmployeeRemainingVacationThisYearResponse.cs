using System.Text.Json.Serialization;

namespace Elmo.Application.Models.Exercise3
{
    public class GetEmployeeRemainingVacationThisYearResponse
    {
        [JsonPropertyName("employeeId")]
        public int Id { get; set; }

        [JsonPropertyName("employeeName")]
        public string? Name { get; set; }

        [JsonPropertyName("freeDays")]
        public double? FreeDays { get; set; }

    }

}
