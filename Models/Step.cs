using System.Text.Json.Serialization;

namespace _3ai.solutions.GoogleMaps.Models
{
    public record Step
    {
        [JsonPropertyName("distance")]
        public TextValue Distance { get; init; } = new();
        [JsonPropertyName("duration")]
        public TextValue Duration { get; init; } = new();
        [JsonPropertyName("end_location")]
        public Coords EndLocation { get; init; } = new();
        [JsonPropertyName("html_instructions")]
        public string HtmlInstructions { get; init; } = string.Empty;
        [JsonPropertyName("polyline")]
        public Polyline Polyline { get; init; } = new();
        [JsonPropertyName("start_location")]
        public Coords StartLocation { get; init; } = new();
        [JsonPropertyName("travel_mode")]
        public string TravelMode { get; init; } = string.Empty;
        [JsonPropertyName("maneuver")]
        public string Maneuver { get; init; } = string.Empty;
    }
}