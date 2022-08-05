using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Net;

namespace _3ai.solutions.GoogleMaps
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddGoogleMapsClient(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<Options>(configuration.GetSection("GoogleMapsOptions"));
            services.AddHttpClient<Client>(
                o =>
                {
                    o.BaseAddress = new("https://maps.googleapis.com");
                })
                .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
                {
                    AutomaticDecompression = DecompressionMethods.All,
                });
            return services;
        }
    }
}