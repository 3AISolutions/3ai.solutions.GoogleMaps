namespace _3ai.solutions.GoogleMaps
{
    public record Options
    {
        public string ApiKey { get; init; } = string.Empty;
        public string BaseUrl { get; init; } = "https://maps.googleapis.com";
    }
}