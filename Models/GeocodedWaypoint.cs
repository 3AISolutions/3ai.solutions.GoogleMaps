using System.Text.Json.Serialization;

namespace _3ai.solutions.GoogleMaps.Models
{
    public record GeocodedWaypoint
    {
        [JsonPropertyName("geocoder_status")]
        public string GeocoderStatus { get; init; } = string.Empty;
        [JsonPropertyName("place_id")]
        public string PlaceId { get; init; } = string.Empty;
        [JsonPropertyName("types")]
        public string[] Types { get; init; } = Array.Empty<string>();
    }
}