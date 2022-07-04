using Flurl;
using MatchActors.Infrastructure.ImdbClient.Models;
using MatchActors.Infrastructure.ImdbClient.Options;
using Microsoft.Extensions.Options;

namespace MatchActors.Infrastructure.ImdbClient.Services
{
    internal sealed class ImdbHttpService:BaseHttpService, IImdbHttpService
    {
        private readonly ImdbClientOptions _options;
        public ImdbHttpService(HttpClient httpClient, IOptions<ImdbClientOptions> options) : base(httpClient)
        {
            _options = options.Value;
        }

        public async Task<Data> GetActorsByName(string name, CancellationToken cancellationToken)
        {
            var url = _client.BaseAddress
                .AppendPathSegments($"SearchName/{_options.ApiKey}/{name}");

            return await GetResult<Data>(url, cancellationToken);
        }

        public async Task<ActorData> GetActorDataById(string id, CancellationToken cancellationToken)
        {
            var url = _client.BaseAddress
                .AppendPathSegments($"Name/{_options.ApiKey}/{id}");

            return await GetResult<ActorData>(url, cancellationToken);
        }
    }
}
