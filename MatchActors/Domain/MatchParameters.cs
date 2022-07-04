namespace MatchActors.Domain
{
    internal sealed class MatchParameters
    {
        public IEnumerable<Filming> FirstActorFilmings { get; init; } = Enumerable.Empty<Filming>();

        public IEnumerable<Filming> SecondActorFilmings { get; init; } = Enumerable.Empty<Filming>();
    }
}
