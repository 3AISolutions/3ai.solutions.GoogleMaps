using System.Text.Json.Serialization;

namespace _3ai.solutions.GoogleMaps.Models
{
    public record DestinationResponse
    {
        [JsonPropertyName("geocodedWaypoints")]
        public GeocodedWaypoint[] GeocodedWaypoints { get; init; } = Array.Empty<GeocodedWaypoint>();
        [JsonPropertyName("routes")]
        public Route[] Routes { get; init; } = Array.Empty<Route>();
        [JsonPropertyName("status")]
        public string Status { get; init; } = string.Empty;
    }
}