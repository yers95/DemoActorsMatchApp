namespace MatchActors.Application
{
    internal class MatchResult
    {
        public IEnumerable<string> Filmings { get; init; } = Enumerable.Empty<string>();

        public override string ToString()
        {
            return $"Result: {Filmings.Count()} matched filmings found";
        }
    }
}
