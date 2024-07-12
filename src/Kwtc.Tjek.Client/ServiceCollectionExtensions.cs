using Kwtc.Tjek.Client.Abstractions;
using Kwtc.Tjek.Client.Abstractions.Config;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kwtc.Tjek.Client;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddTjekClientServices(this IServiceCollection services, ConfigurationManager configuration)
    {
        var clientConfig = configuration.GetSection(TjekClientConfig.SectionName).Get<TjekClientConfig>();
        if (clientConfig is null)
        {
            throw new InvalidOperationException("Client configuration is missing");
        }

        services.Configure<TjekClientConfig>(configuration.GetSection(TjekClientConfig.SectionName));

        services.AddHttpClient(Constants.HttpClientName, client =>
        {
            client.BaseAddress = new Uri(Constants.BaseUrl);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("X-Api-Key", clientConfig.ApiKey);
        });

        services.AddTransient<ITjekClient, TjekClient>();

        return services;
    }
}
