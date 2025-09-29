using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Elmo.Application.Models.Exercise2
{
    public class GetTeamsWithoutVacationIn2019Response
    {
        [JsonPropertyName("teams")]
        public List<GetTeamsWithoutVacationIn2019Team>? Teams { get; set; }

    }

    public class GetTeamsWithoutVacationIn2019Team
    {
        [JsonPropertyName("teamId")]
        public int Id { get; set; }

        [JsonPropertyName("teamName")]
        public string? Name { get; set; }
    }
}
