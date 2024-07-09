using Kwtc.Tjek.Client.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kwtc.Tjek.Client;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddTjekClientServices(this IServiceCollection services, ConfigurationManager configuration)
    {
        var clientConfig = configuration.GetSection(ClientConfig.SectionName).Get<ClientConfig>();
        if (clientConfig is null)
        {
            throw new InvalidOperationException("Client configuration is missing");
        }

        services.Configure<ClientConfig>(configuration.GetSection(ClientConfig.SectionName));

        services.AddHttpClient(Constants.HttpClientName, client =>
        {
            client.BaseAddress = new Uri(Constants.BaseUrl);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("X-Api-Key", clientConfig.ApiKey);
        });

        services.AddTransient<IClient, Client>();

        return services;
    }
}
