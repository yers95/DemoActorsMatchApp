namespace MatchActors.Contracts
{
    /// <summary>
    /// Request to get matched filmings of two actors
    /// </summary>
    public class MatchActorsRequest
    {
        /// <summary>
        /// First actor name
        /// </summary>
        public string FirstActorName { get; init; } = string.Empty;

        /// <summary>
        /// Second actor name
        /// </summary>
        public string SecondActorName { get; init; } = string.Empty;

        /// <summary>
        /// GetMoviesOnlyFlag
        /// </summary>
        public bool MoviesOnly { get; init; }
    }
}
