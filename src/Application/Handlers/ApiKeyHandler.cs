using System.Net;
using Application.Configuration;

namespace Application.Handlers
{
    public class ApiKeyHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.TryGetValues("Key", out IEnumerable<string> myHeaderList);
            
            var myHeader = myHeaderList!.First();

            if (string.IsNullOrEmpty(myHeader) || !string.IsNullOrEmpty(myHeader) && myHeader != BuilderConfiguration.Builder()["ApiKey"])
                return new HttpResponseMessage(HttpStatusCode.Unauthorized);
                    
            return await base.SendAsync(request, cancellationToken);
        }
    }
}