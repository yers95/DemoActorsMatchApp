namespace MatchActors.Domain
{
    internal sealed class ActorFilmings
    {
        public string ActorId { get; init; } = string.Empty;

        public string ActorName { get; init; } = string.Empty;

        public IEnumerable<Filming> Filmings { get; init; } = Enumerable.Empty<Filming>();
    }
}
