namespace MatchActors.Domain.MatchFactories
{
    internal interface IMatchersFactory
    {
         public IFilmingsMatcher GetMatcher(bool moviesOnly);
    }
}
