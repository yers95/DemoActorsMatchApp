namespace MatchActors.Infrastructure.ImdbClient.Models
{
    internal sealed class Data
    {
        public Actor[] Results { get; init; } = Array.Empty<Actor>();
    }
}
