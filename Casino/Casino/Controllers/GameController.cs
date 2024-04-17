using Casino.BLL;
using Microsoft.AspNetCore.Mvc;

namespace Casino.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : Controller
    {
        private readonly IGame _Game;

        public GameController(IGame Game) 
        { 
            _Game = Game; 
        }

        [HttpGet("BanditDescription/{id}")]
        public ActionResult BandytaInfo(int id)
        {
            return Ok(_Game.GetBanditInfo(id));
        }
        [HttpGet("BlackJackDescription/{id}")]
        public ActionResult BlackInfo(int id)
        {
            return Ok(_Game.GetBanditInfo(id));
        }
        [HttpGet("Roulette/{id}")]
        public ActionResult RouletteInfo(int id)
        {
            return Ok(_Game.GetBanditInfo(id));
        }
        [HttpGet("Game/{id}")]
        public ActionResult GameInfo(int id)
        {
            return Ok(_Game.GetGameInfo(id));
        }
    }
}
