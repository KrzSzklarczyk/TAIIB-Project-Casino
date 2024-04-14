using Casino.BLL;
using Casino.BLL.DTO;
using Casino.Model;
using Microsoft.AspNetCore.Mvc;

namespace Casino.Controllers
{
    [ApiController]
    [Route("[web/games]")]
    public class GameController : Controller
    {
        private readonly IGame _Game;

       GameController(IGame Game) { _Game = Game; }
        [HttpGet("BANDYTA!!!")]
        public ActionResult BandytaInfo(BanditDTO bandyta)
        {
           
            return Ok(_Game.GetBanditInfo(bandyta.GameId));
        }
        [HttpGet("czarny")]
        public ActionResult BlackInfo(BlackJackDTO black)
        {
            
            return Ok(_Game.GetBanditInfo(black.GameId));
        }
        [HttpGet("ruledga")]
        public ActionResult RulleteInfo(RouletteDTO ruletka)
        {
            
            return Ok(_Game.GetBanditInfo(ruletka.GameId));
        }
        [HttpGet("Gra")]
        public ActionResult GameInfo(GameDTO game)
        {
            
            return Ok(_Game.GetBanditInfo(game.GameId));
        }
    }
}
