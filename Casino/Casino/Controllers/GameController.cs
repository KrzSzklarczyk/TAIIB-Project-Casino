using Casino.BLL;
using Casino.BLL.DTO;
using Casino.Model;
using Microsoft.AspNetCore.Mvc;

namespace Casino.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : Controller
    {
        private readonly IGame _Game;

        GameController(IGame Game) { _Game = Game; }
        [HttpGet("BANDYTA!!!/{id}")]
        public ActionResult BandytaInfo(int id)
        {
           
            return Ok(_Game.GetBanditInfo(id));
        }
        [HttpGet("czarny/{id}")]
        public ActionResult BlackInfo(int id)
        {
            
            return Ok(_Game.GetBanditInfo(id));
        }
        [HttpGet("ruledga/{id}")]
        public ActionResult RulleteInfo(int id)
        {
            
            return Ok(_Game.GetBanditInfo(id));
        }
        [HttpGet("Gra/{id}")]
        public ActionResult GameInfo(int id)
        {
            
            return Ok(_Game.GetBanditInfo(id));
        }
    }
}
