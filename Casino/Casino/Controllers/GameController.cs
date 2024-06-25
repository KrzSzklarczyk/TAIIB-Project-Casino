using Casino.BLL;
using Microsoft.AspNetCore.Mvc;
using Casino.BLL.DTO;
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

        [HttpGet("Bandit/{id}")]
        public ActionResult BandytaInfo(int id)
        {
            return Ok(_Game.GetBanditInfo(new GameRequestDTO { GameId=id}));
        }
        
        
        [HttpGet("Roulette/{id}")]
        public ActionResult RouletteInfo(int id)
        {
            return Ok(_Game.GetBanditInfo(new GameRequestDTO { GameId = id }));
        }
        [HttpGet("Game/{id}")]
        public ActionResult GameInfo(int id)
        {
            return Ok(_Game.GetGameInfo(new GameRequestDTO { GameId = id }));
        }
    }
}
