using MatchActors.Application.Commands;
using MatchActors.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MatchActors.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorMatchingsController : ControllerBase
    {

        private readonly IMediator _mediator;

        public ActorMatchingsController(IMediator mediator)
        {
            _mediator = mediator;
        }


        /// <summary>
        /// Get actors matched filmings
        /// </summary>
        /// <remarks>
        /// Sample value of actor
        /// 
        ///     POST /ActorMatchings
        ///     {
        ///        "firstActorName": "Chris Hemsworth",
        ///        "secondActorName": "Natalie Portman",
        ///        "moviesOnly": true
        ///     }
        ///     
        /// </remarks>
        [HttpPost]
        public async Task<ActionResult<MatchActorsResponse>> FindMatchedFilmings(MatchActorsRequest request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new MatchActorsCommand
            { FirstActorName = request.FirstActorName, SecondActorName = request.SecondActorName, MoviesOnly = request.MoviesOnly }, cancellationToken);

            return Ok(new MatchActorsResponse { Filmings = result.Filmings });
        }
    }
}
