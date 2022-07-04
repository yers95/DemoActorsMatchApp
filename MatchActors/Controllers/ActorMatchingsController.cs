using Microsoft.AspNetCore.Mvc;

namespace MatchActors.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorMatchingsController : ControllerBase
    {
        /// <summary>
        /// Получение автора по имени
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<string> GetActorByName(string name)
        {
            return name;
        }
    }
}
