using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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
