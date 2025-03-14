using Microsoft.AspNetCore.WebUtilities;
using _3ai.solutions.GoogleMaps.Models;
using System.Net.Http.Json;

namespace _3ai.solutions.GoogleMaps
{
    public class GoogleMapsClient
    {
        private readonly string _apiKey;
        private readonly string _baseUrl;
        private readonly string _apiUrl;

        public GoogleMapsClient(string apiKey)
        {
            _apiKey = apiKey;
            _baseUrl = "https://www.google.com/";
            _apiUrl = "https://maps.googleapis.com/";
        }

        public async Task<byte[]> GetStaticMapAsync(int width, int height, List<string> paths, CancellationToken token = default)
        {
            return await StaticMapAsync(width, height, string.Join("|", paths), token);
        }

        public async Task<byte[]> GetStaticMapAsync(int width, int height, string path, CancellationToken token = default)
        {
            return await StaticMapAsync(width, height, $"enc:{path}", token);
        }

        private async Task<byte[]> StaticMapAsync(int width, int height, string path, CancellationToken token = default)
        {
            Dictionary<string, string?> query = new()
            {
                ["size"] = $"{width}x{height}",
                ["path"] = $"weight:5|geodesic:false|{path}",
                ["key"] = _apiKey
            };

            var uri = QueryHelpers.AddQueryString($"{_apiUrl}maps/api/distancematrix/json", query);

            return await GetByteArrayAsync(uri, token);
        }

        public async Task<string> GetDistanceMatrixAsync(
            List<string> origins, List<string> destinations, TravelMode? mode = null, string? language = null,
            Avoid? avoid = null, Units? units = null, DateTime? departure_time = null,
            TransitRoutingPreference? transit_routing_preference = null, TrafficModel? traffic_model = null,
            DateTime? arrival_time = null, List<TransitMode>? transit_mode = null, string? region = null,
            CancellationToken token = default)
        {
            Dictionary<string, string?> query = new()
            {
                ["origins"] = string.Join("|", origins),
                ["destinations"] = string.Join("|", destinations),
                ["key"] = _apiKey
            };

            if (mode is not null)
                query.Add("mode", mode.ToString());

            if (language is not null)
                query.Add("language", language);

            if (avoid is not null)
                query.Add("avoid", avoid.ToString());

            if (units is not null)
                query.Add("units", units.ToString());

            if (departure_time is not null)
                query.Add("departure_time", departure_time.ToString());

            if (arrival_time is not null)
            {
                if (departure_time is not null) throw new Exception("Should not specify both departure_time and arrival_time.");
                query.Add("arrival_time", arrival_time.ToString());
            }

            if (transit_mode is not null)
                query.Add("transit_mode", string.Join("|", transit_mode));

            if (transit_routing_preference is not null)
                query.Add("transit_routing_preference", transit_routing_preference.ToString());

            if (traffic_model is not null)
                query.Add("traffic_model", traffic_model.ToString());

            //https://en.wikipedia.org/wiki/Country_code_top-level_domain
            if (region is not null)
                query.Add("region", region);

            var uri = QueryHelpers.AddQueryString($"{_apiUrl}maps/api/distancematrix/json", query);

            return await GetAsync<string>(uri, token) ?? "";
        }

        public string GetDirectionsUrl(string origin, string destination, TravelMode travelmode, List<string>? waypoints = null)
        {
            Dictionary<string, string?> query = new()
            {
                ["origin"] = origin,
                ["destination"] = destination,
                ["api"] = "1",
                ["travelmode"] = travelmode.ToString(),
            };

            if (waypoints?.Count > 0)
                query.Add("waypoints", string.Join("|", waypoints));

            return QueryHelpers.AddQueryString($"{_baseUrl}maps/dir/", query);
        }

        public string GetEmbededDirectionsUrl(string origin, string destination, List<string>? waypoints = null)
        {
            Dictionary<string, string?> query = new()
            {
                ["origin"] = origin,
                ["destination"] = destination,
                ["key"] = _apiKey
            };

            if (waypoints?.Count > 0)
                query.Add("waypoints", string.Join("|", waypoints));

            return QueryHelpers.AddQueryString($"{_baseUrl}/maps/embed/v1/directions", query);
        }

        public async Task<DestinationResponse> GetDirectionsAsync(
            string origin, string destination, TravelMode? mode = null, List<string>? waypoints = null,
            bool alternatives = false, string? language = null, bool optimize_waypoints = false,
            Avoid? avoid = null, Units? units = null, DateTime? departure_time = null,
            TransitRoutingPreference? transit_routing_preference = null, TrafficModel? traffic_model = null,
            DateTime? arrival_time = null, List<TransitMode>? transit_mode = null, string? region = null,
            CancellationToken token = default)
        {
            Dictionary<string, string?> query = new()
            {
                ["origin"] = origin,
                ["destination"] = destination,
                ["key"] = _apiKey
            };

            if (mode is not null)
                query.Add("mode", mode.ToString());

            if (language is not null)
                query.Add("language", language);

            if (alternatives)
                query.Add("alternatives", "True");

            if (waypoints is not null)
            {
                if (optimize_waypoints)
                    waypoints.Insert(0, "optimize:true");

                query.Add("waypoints", string.Join("|", waypoints));
            }

            if (avoid is not null)
                query.Add("avoid", avoid.ToString());

            if (units is not null)
                query.Add("units", units.ToString());

            if (departure_time is not null)
                query.Add("departure_time", departure_time.ToString());

            if (arrival_time is not null)
            {
                if (departure_time is not null) throw new Exception("Should not specify both departure_time and arrival_time.");
                query.Add("arrival_time", arrival_time.ToString());
            }

            if (transit_mode is not null)
                query.Add("transit_mode", string.Join("|", transit_mode));

            if (transit_routing_preference is not null)
                query.Add("transit_routing_preference", transit_routing_preference.ToString());

            if (traffic_model is not null)
                query.Add("traffic_model", traffic_model.ToString());

            //https://en.wikipedia.org/wiki/Country_code_top-level_domain
            if (region is not null)
                query.Add("region", region);

            var uri = QueryHelpers.AddQueryString($"{_apiUrl}/maps/api/directions/json", query);

            return await GetAsync<DestinationResponse>(uri, token) ?? new();
        }

        public async Task<AddressResponse> GetAddressAsync(string address, CancellationToken token = default)
        {
            Dictionary<string, string?> query = new()
            {
                ["address"] = address,
                ["key"] = _apiKey
            };

            var uri = QueryHelpers.AddQueryString($"{_apiUrl}/maps/api/geocode/json", query);

            return await GetAsync<AddressResponse>(uri, token) ?? new();
        }

        private static async Task<T?> GetAsync<T>(string uri, CancellationToken token)
        {
            using HttpClient httpClient = new();
            var resp = await httpClient.GetAsync(uri, token);
            return await resp.Content.ReadFromJsonAsync<T>(cancellationToken: token);
        }

        //private async Task<string> GetStringAsync(string uri, CancellationToken token)
        //{
        //    var resp = await _httpClient.GetAsync(uri, token);
        //    return await resp.Content.ReadAsStringAsync(token);
        //}

        private static async Task<byte[]> GetByteArrayAsync(string uri, CancellationToken token)
        {
            using HttpClient httpClient = new();
            //"
            var resp = await httpClient.GetAsync(uri, token);
            return await resp.Content.ReadAsByteArrayAsync(token);
        }
    }
}