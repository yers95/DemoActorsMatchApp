namespace MatchActors.Domain.FilmingsMatchers
{
    internal sealed class DefaultFilmingsMatcher:IFilmingsMatcher
    {
        public IEnumerable<string> Match(MatchParameters parameters)
        {
            foreach (var firstActorFilming in parameters.FirstActorFilmings)
            {
                foreach (var secondActorFilming in parameters.SecondActorFilmings)
                {
                    if (firstActorFilming.Id == secondActorFilming.Id)
                    {
                        yield return firstActorFilming.Title;
                        break;
                    }
                }
            }
        }
    }
}
