using System.Text.Json.Serialization;

namespace _3ai.solutions.GoogleMaps.Models
{
    public record Route
    {
        [JsonPropertyName("bounds")]
        public Bounds Bounds { get; init; } = new();
        [JsonPropertyName("copyrights")]
        public string Copyrights { get; init; } = string.Empty;
        [JsonPropertyName("legs")]
        public Leg[] Legs { get; init; } = Array.Empty<Leg>();
        [JsonPropertyName("overview_polyline")]
        public Polyline OverviewPolyline { get; init; } = new();
        [JsonPropertyName("summary")]
        public string Summary { get; init; } = string.Empty;
        //public object[] warnings { get; init; }
        [JsonPropertyName("waypoint_order")]
        public int[] WaypointOrder { get; init; } = Array.Empty<int>();
    }
}