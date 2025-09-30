using System.Text.Json.Serialization;

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
