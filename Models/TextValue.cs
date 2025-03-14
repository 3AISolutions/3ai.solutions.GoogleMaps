using System.Text.Json.Serialization;

namespace _3ai.solutions.GoogleMaps.Models;

public record TextValue
{
    [JsonPropertyName("text")]
    public string Text { get; init; } = string.Empty;
    [JsonPropertyName("value")]
    public int Value { get; init; }
}


public record AddressComponent
{
    [JsonPropertyName("long_name")]
    public string LongName { get; set; } = string.Empty;

    [JsonPropertyName("short_name")]
    public string ShortName { get; set; } = string.Empty;

    [JsonPropertyName("types")]
    public List<string> Types { get; set; } = new List<string>();
}

public record Geometry
{
    [JsonPropertyName("location")]
    public Location? Location { get; set; }

    [JsonPropertyName("location_type")]
    public string LocationType { get; set; } = string.Empty;

    [JsonPropertyName("viewport")]
    public Viewport? Viewport { get; set; }
}

public record Location
{
    [JsonPropertyName("lat")]
    public double? Lat { get; set; }

    [JsonPropertyName("lng")]
    public double? Lng { get; set; }

    [JsonPropertyName("latitude")]
    public double? Latitude { get; set; }

    [JsonPropertyName("longitude")]
    public double? Longitude { get; set; }
}

public record NavigationPoint
{
    [JsonPropertyName("location")]
    public Location? Location { get; set; }
}

public record Northeast
{
    [JsonPropertyName("lat")]
    public double? Lat { get; set; }

    [JsonPropertyName("lng")]
    public double? Lng { get; set; }
}

public record PlusCode
{
    [JsonPropertyName("compound_code")]
    public string CompoundCode { get; set; } = string.Empty;

    [JsonPropertyName("global_code")]
    public string GlobalCode { get; set; } = string.Empty;
}

public record Result
{
    [JsonPropertyName("address_components")]
    public List<AddressComponent> AddressComponents { get; set; } =  new List<AddressComponent>();

    [JsonPropertyName("formatted_address")]
    public string FormattedAddress { get; set; } = string.Empty;

    [JsonPropertyName("geometry")]
    public Geometry? Geometry { get; set; }

    [JsonPropertyName("navigation_points")]
    public List<NavigationPoint> NavigationPoints { get; set; } = new List<NavigationPoint>();

    [JsonPropertyName("place_id")]
    public string PlaceId { get; set; } = string.Empty;

    [JsonPropertyName("plus_code")]
    public PlusCode? PlusCode { get; set; }

    [JsonPropertyName("types")]
    public List<string> Types { get; set; } = new List<string>();
}

public record AddressResponse
{
    [JsonPropertyName("results")]
    public List<Result> Results { get; set; } = new List<Result>();

    [JsonPropertyName("status")]
    public string Status { get; set; } = string.Empty;
}

public record Southwest
{
    [JsonPropertyName("lat")]
    public double? Lat { get; set; }

    [JsonPropertyName("lng")]
    public double? Lng { get; set; }
}

public record Viewport
{
    [JsonPropertyName("northeast")]
    public Northeast? Northeast { get; set; }

    [JsonPropertyName("southwest")]
    public Southwest? Southwest { get; set; }
}

