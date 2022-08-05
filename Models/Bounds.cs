using System.Text.Json.Serialization;

namespace _3ai.solutions.GoogleMaps.Models
{
    public record Bounds
    {
        [JsonPropertyName("northeast")]
        public Coords Northeast { get; init; } = new();
        [JsonPropertyName("southwest")]
        public Coords Southwest { get; init; } = new();
    }
}