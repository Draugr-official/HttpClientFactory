# HttpClientFactory
This component is an extension to IHttpClientFactory. This allows you to use HttpClientFactory outside of dependency injection.\
Through named HttpClients, you can re-use clients across your app. Learn more about why you should use HttpClientFactory [here](https://learn.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests)

> NOTE: HttpClientFactory is under `System.Net.Http` after installing this package.

## Usage
Using HttpClientFactory is simple. There are three ways to generate HttpClients.
### Anonymous HttpClient
```cs
HttpClient httpClient = HttpClientFactory.CreateClient();
```

### Named HttpClient
```cs
HttpClient namedHttpClient = HttpClientFactory.CreateClient("test");
```

### Named HttpClient with SocketsHttpHandler
```cs
HttpClient namedHttpClient = HttpClientFactory.CreateClient("test", new SocketsHttpHandler
{
    // Properties
});
```