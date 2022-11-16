using RestSharp;
using RestSharp.Authenticators;

namespace Ntmng.Web.Common;

public class ApiNtmng
{
    public static string Url { get; set; }
    public static int Timeout { get; set; } = 5000;

    private RestClient GetRestClient(string? authenticator = null)
    {
        var options = new RestClientOptions($"{Url}")
        {
            ThrowOnAnyError = true,
            MaxTimeout = Timeout
        };

        var client = new RestClient(options);

        if (authenticator != null)
            client.Authenticator = new JwtAuthenticator(authenticator);

        return client;
    }

    public T? RestRequest<T>(string resource, Method method, object? body = null, string? authenticator = null)
    {
        var client = GetRestClient(authenticator);
        var request = new RestRequest(resource, method)
        {
            RequestFormat = DataFormat.Json
        };

        if (body != null)
            request.AddBody(body);

        return client.Execute<T>(request).Data;
    }

    public async Task<T?> RestRequestAsync<T>(string resource, Method method, object? body = null, string? authenticator = null)
    {
        var client = GetRestClient(authenticator);
        var request = new RestRequest(resource, method)
        {
            RequestFormat = DataFormat.Json
        };

        if (body != null)
            request.AddBody(body);

        var result = await client.ExecuteAsync<T>(request);

        return result.Data;
    }
}