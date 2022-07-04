using MediatR;

namespace MatchActors.Application.Commands
{
    internal sealed class MatchActorsCommand :IRequest<MatchResult>
    {
        public string FirstActorName { get; init; } = string.Empty;
        public string SecondActorName { get; init; } = string.Empty;
        public bool MoviesOnly { get; init; }

        public override string ToString()
        {
            return $"Request: FirstActor: {FirstActorName}, SecondActor: {SecondActorName}, MoviesOnly: {MoviesOnly}";
        }
    }
}
