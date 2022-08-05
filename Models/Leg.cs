using System.Text.Json.Serialization;

namespace _3ai.solutions.GoogleMaps.Models
{
    public record Leg
    {
        [JsonPropertyName("distance")]
        public TextValue Distance { get; init; } = new();
        [JsonPropertyName("duration")]
        public TextValue Duration { get; init; } = new();
        [JsonPropertyName("end_address")]
        public string EndAddress { get; init; } = string.Empty;
        [JsonPropertyName("end_location")]
        public Coords EndLocation { get; init; } = new();
        [JsonPropertyName("start_address")]
        public string StartAddress { get; init; } = string.Empty;
        [JsonPropertyName("start_location")]
        public Coords StartLocation { get; init; } = new();
        [JsonPropertyName("steps")]
        public Step[] Steps { get; init; } = Array.Empty<Step>();
        //public object[] traffic_speed_entry { get; init; }
        //public object[] via_waypoint { get; init; }
    }
}