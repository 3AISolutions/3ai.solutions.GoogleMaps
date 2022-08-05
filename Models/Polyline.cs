using System.Text.Json.Serialization;

namespace _3ai.solutions.GoogleMaps.Models
{
    public record Polyline
    {
        [JsonPropertyName("points")]
        public string Points { get; init; } = string.Empty;
    }
}