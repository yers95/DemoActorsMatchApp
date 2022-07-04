using MatchActors.Application.Commands;
using MatchActors.Application.Notifications;
using MatchActors.Domain;
using MatchActors.Domain.MatchFactories;
using MediatR;

namespace MatchActors.Application.CommandHandlers
{
    internal sealed class MatchActorsCommandHandler : IRequestHandler<MatchActorsCommand, MatchResult>
    {
       
        private readonly IMatchersFactory _matchersFactory;
        private readonly IActorFilmingsResolver _filmingsResolver;
        private readonly IMediator _mediator;
        public MatchActorsCommandHandler(IMatchersFactory matchersFactory, IActorFilmingsResolver filmingsResolver, IMediator mediator)
        {
            _matchersFactory = matchersFactory;
            _filmingsResolver = filmingsResolver;
            _mediator = mediator;
        }



        public async Task<MatchResult> Handle(MatchActorsCommand request, CancellationToken cancellationToken)
        {
            var firstActorFilmings = await _filmingsResolver.ResolveFilmings(request.FirstActorName, cancellationToken);
            var secondActorFilmings = await _filmingsResolver.ResolveFilmings(request.SecondActorName, cancellationToken);

            var filmingsMatcher = _matchersFactory.GetMatcher(request.MoviesOnly);

            var result = new MatchResult
            {
                Filmings = filmingsMatcher.Match(new MatchParameters
                {
                    FirstActorFilmings = firstActorFilmings.Filmings,
                    SecondActorFilmings = secondActorFilmings.Filmings
                })
            };

            await _mediator.Publish(new MatchNotification
            {
                Command = request,
                Result = result
            }, cancellationToken);

            return result;
        }

    }
}
