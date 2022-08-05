using System.Text.Json.Serialization;

namespace _3ai.solutions.GoogleMaps.Models
{
    public record TextValue
    {
        [JsonPropertyName("text")]
        public string Text { get; init; } = string.Empty;
        [JsonPropertyName("value")]
        public int Value { get; init; }
    }
}