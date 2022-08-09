using Microsoft.Extensions.DependencyInjection;

namespace _3ai.solutions.GoogleMaps
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddGoogleMapsClient(this IServiceCollection services, string googleMapsApiKey)
        {
            services.AddSingleton(x => new GoogleMapsClient(googleMapsApiKey));
            return services;
        }
    }
}