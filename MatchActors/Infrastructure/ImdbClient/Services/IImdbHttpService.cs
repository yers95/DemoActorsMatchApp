using MatchActors.Infrastructure.ImdbClient.Models;

namespace MatchActors.Infrastructure.ImdbClient.Services
{
    internal interface IImdbHttpService
    {
        Task<Data> GetActorsByName(string name, CancellationToken cancellationToken);

        Task<ActorData> GetActorDataById(string id, CancellationToken cancellationToken);
    }
}
