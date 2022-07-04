namespace MatchActors.Domain.FilmingsMatchers
{
    internal sealed class MovieFilmingsMatcher : IFilmingsMatcher
    {
        public IEnumerable<string> Match(MatchParameters parameters)
        {
            var firstActorMovies = parameters.FirstActorFilmings.Where(w => w.Role == "Actor" || w.Role == "Actress");
            var secondActorMovies = parameters.SecondActorFilmings.Where(w => w.Role == "Actor" || w.Role == "Actress");

            foreach (var firstActorFilming in firstActorMovies)
            {
                foreach (var secondActorFilming in secondActorMovies)
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
