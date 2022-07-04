using MatchActors.Application.Commands;
using MediatR;

namespace MatchActors.Application.Notifications
{
    internal sealed class MatchNotification:INotification
    {
        public MatchActorsCommand Command { get; init; } = new();

        public MatchResult Result { get; init; } = new();

        public override string ToString()
        {
            return $"{Command} => {Result}";
        }
    }
}
