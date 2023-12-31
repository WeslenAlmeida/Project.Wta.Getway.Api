using System.Net;

namespace Application.Handlers
{
    public class ApiKeyHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.TryGetValues("Key", out IEnumerable<string> myHeaderList);
            
            var myHeader = myHeaderList!.First();

            if (string.IsNullOrEmpty(myHeader))
                return new HttpResponseMessage(HttpStatusCode.Unauthorized);

            if (!string.IsNullOrEmpty(myHeader) && myHeader != "3a20b0d9-d576-4300-b5be-f4f23664feee")
                return new HttpResponseMessage(HttpStatusCode.Forbidden);
                    
            return await base.SendAsync(request, cancellationToken);
              
        }
    }
}