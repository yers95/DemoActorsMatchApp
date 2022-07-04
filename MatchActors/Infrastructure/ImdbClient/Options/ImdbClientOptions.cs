namespace MatchActors.Infrastructure.ImdbClient.Options
{
    internal sealed class ImdbClientOptions
    {
        public string ApiKey { get; init; } = string.Empty;

        public string BaseUrl { get; init; } = string.Empty;
    }
}
