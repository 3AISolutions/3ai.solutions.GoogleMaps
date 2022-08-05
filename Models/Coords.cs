using System.Text.Json.Serialization;

namespace _3ai.solutions.GoogleMaps.Models
{
    public record Coords
    {
        [JsonPropertyName("lat")]
        public float Lat { get; init; }
        [JsonPropertyName("lng")]
        public float Lng { get; init; }
    }
}