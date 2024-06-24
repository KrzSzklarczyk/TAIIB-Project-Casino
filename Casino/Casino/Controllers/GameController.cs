using AutoMapper;
using Casino.BLL;
using Casino.BLL.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Casino.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : Controller
    {
        private readonly IGame _Game;
        private IMapper mapper;

        public GameController(IGame Game, IMapper _mapper) 
        { 
            _Game = Game;
            mapper = _mapper;
        }

        [HttpGet("BanditDescription/{id}")]
        public ActionResult BandytaInfo(int id)
        {
            return Ok(_Game.GetBanditInfo(new GameRequestDTO { GameId=id} ));
        }
        [HttpGet("BlackJackDescription/{id}")]
        public ActionResult BlackInfo(int id)
        {
            return Ok(_Game.GetBanditInfo(new GameRequestDTO { GameId = id }));
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
