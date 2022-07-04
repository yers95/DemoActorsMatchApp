namespace MatchActors.Infrastructure.ImdbClient.Models
{
    internal sealed class ActorData
    {
        public Movie[] CastMovies { get; init; } = Array.Empty<Movie>();
    }
}
