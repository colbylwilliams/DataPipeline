using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.Rest;

public class TextAnalyticsCredentials : ServiceClientCredentials
{
    private readonly string apiKey;

    public TextAnalyticsCredentials(string apiKey)
    {
        this.apiKey = apiKey;
    }

    public override Task ProcessHttpRequestAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new ArgumentNullException("request");
        }
        request.Headers.Add("Ocp-Apim-Subscription-Key", this.apiKey);
        return base.ProcessHttpRequestAsync(request, cancellationToken);
    }
}