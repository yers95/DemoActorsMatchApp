using MatchActors.Domain.FilmingsMatchers;

namespace MatchActors.Domain.MatchFactories
{
    internal sealed class MatchersFactory : IMatchersFactory
    {
        public IFilmingsMatcher GetMatcher(bool moviesOnly)
        {
            return moviesOnly ? new MovieFilmingsMatcher() : new DefaultFilmingsMatcher();
        }
    }
}
