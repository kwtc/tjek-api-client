![.NET build and test](https://github.com/kwtc/tjek-client-dotnet/actions/workflows/ci.yml/badge.svg)

# Tjek.com .NET API client
As the heading states this is a .NET API client for tjek.com

> **Warning**
> This is work in progress
> 
> Minor and patch version bumps may have breaking changes until version 1.0.0 is released and endpoint response deserialization may not be fully tested 

## Supported endpoint status
- [x] /v2/offers/search
- [x] /v2/offers
- [x] /v2/offers/{offerId}
- [x] /v2/catalogs
- [x] /v2/catalogs/{catalogId}
- [x] /v2/catalogs/{catalogId}/pages
- [x] /v2/catalogs/{catalogId}/hotspots
- [x] /v2/catalogs/{catalogId}/page_decorations

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
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly TjekClientConfig _tjekClientConfig;

    public MyService(IHttpClientFactory httpClientFactory, IOptions<TjekClientConfig> tjekClientConfig)
    {
        _httpClientFactory = httpClientFactory;
        _tjekClientConfig = tjekClientConfig.Value;
    }
    
    public void MyMethod()
    {
        var client = _httpClientFactory.CreateClient(Constants.HttpClientName);
    }
}
```
