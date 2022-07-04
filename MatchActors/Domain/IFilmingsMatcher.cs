namespace MatchActors.Domain
{
    internal interface IFilmingsMatcher
    {
        IEnumerable<string> Match(MatchParameters parameters);
    }
}
