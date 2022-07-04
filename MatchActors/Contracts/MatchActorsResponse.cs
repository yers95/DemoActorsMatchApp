namespace MatchActors.Contracts
{
    /// <summary>
    /// Result of matching actors filmings
    /// </summary>
    public class MatchActorsResponse
    {
        /// <summary>
        /// Matched filmings list
        /// </summary>
        public IEnumerable<string> Filmings { get; init; } = Enumerable.Empty<string>();
    }
}
