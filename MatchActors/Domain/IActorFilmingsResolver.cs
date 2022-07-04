namespace MatchActors.Domain
{
    internal interface IActorFilmingsResolver
    {
        public Task<ActorFilmings> ResolveFilmings(string actorName, CancellationToken cancellationToken);
    }
}
