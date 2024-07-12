![.NET build and test](https://github.com/kwtc/tjek-client-dotnet/actions/workflows/ci.yml/badge.svg)

# Tjek.com .NET API client
As the heading states this is a .NET API client for tjek.com

> **Warning**
> This is work in progress
> 
> Minor and patch version bumps may break your code until version 1.0.0 is released 

## Supported endpoint status
- [x] /v2/offers/search
- [ ] /v2/offers
- [ ] /v2/offers/{offerId}

## How to use
Add configuration to appsettings.json

```json
{
  "TjekClientConfig": {
    "ApiKey": "<API_KEY>"
  }
}
```
An API key can be requested here: https://etilbudsavis.dk/developers

The client project includes an extension method that makes registering the client and services in the DI container easy.

```csharp
builder.Services.AddTjekClientServices(builder.Configuration);
```

After registering the services you can inject the client and configuration.

```csharp
public class MyService
{
    private readonly ITjekClient _tjekClient;
    private readonly TjekClientConfig _tjekClientConfig;

    public MyService(ITjekClient tjekClient, IOptions<TjekClientConfig> tjekClientConfig)
    {
        _tjekClient = tjekClient;
        _tjekClientConfig = tjekClientConfig.Value;
    }
}
```
