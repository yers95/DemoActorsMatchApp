using Flurl;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net.Http.Headers;
using System.Text;

namespace MatchActors.Infrastructure.ImdbClient.Services
{
    internal abstract class BaseHttpService
    {
        private protected readonly HttpClient _client;

        protected BaseHttpService(HttpClient client)
        {
            _client = client;
        }

        private protected async Task<T> GetResult<T>(string url, CancellationToken cancellationToken) where T : new()
        {
            var response = await _client.GetStringAsync(url, cancellationToken);
            return JsonConvert.DeserializeObject<T>(response) ?? new();
        }

        private protected async Task<T> PostResult<T, C>(Url url, C criteria, CancellationToken cancellationToken) where T : new()
        {
            T result = new();
            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(criteria, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() }), Encoding.UTF8);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await _client.PostAsync(url, httpContent, cancellationToken);
            if (response.IsSuccessStatusCode)
            {
                result = JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync(cancellationToken).Result) ?? result;
            }

            return result;
        }
    }
}
