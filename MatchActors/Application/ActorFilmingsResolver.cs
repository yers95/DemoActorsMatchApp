using MatchActors.Domain;
using MatchActors.Domain.Exceptions;
using MatchActors.Infrastructure.Database;
using MatchActors.Infrastructure.ImdbClient.Services;

namespace MatchActors.Application
{
    internal sealed class ActorFilmingsResolver : IActorFilmingsResolver
    {
        private readonly IActorInfoRepository _repository;
        private readonly IImdbHttpService _httpService;

        public ActorFilmingsResolver(IImdbHttpService httpService, IActorInfoRepository repository)
        {
            _httpService = httpService;
            _repository = repository;
        }

        public async Task<ActorFilmings> ResolveFilmings(string actorName, CancellationToken cancellationToken)
        {
            
            var actorInfo = await _repository.GetActorInfo(actorName, cancellationToken);

            if(actorInfo is null)
            {
                var resultFromImdbClient = await _httpService.GetActorsByName(actorName, cancellationToken);

                if(resultFromImdbClient is null)
                {
                    throw new ActorNotFoundException($"Actor {actorName} was not found");
                }

                var actor = resultFromImdbClient.Results.FirstOrDefault(t => actorName.ToLower() == t.Title.ToLower());

                if(actor is null)
                {
                    throw new ActorNotFoundException($"Actor {actorName} was not found");
                }

                actorInfo = new ActorInfo
                {
                    ActorId = actor.Id,
                    Name = actor.Title
                };
            }

            var filmings = (await _httpService.GetActorDataById(actorInfo.ActorId, cancellationToken)).CastMovies;

            return new ActorFilmings
            {
                ActorId = actorInfo.ActorId,
                ActorName = actorInfo.Name,
                Filmings = filmings?.Select(t => new Filming
                {
                  Id = t.Id,
                  Role = t.Role,
                  Title = t.Title
                }) ?? Enumerable.Empty<Filming>()
            };
        }
    }
}
