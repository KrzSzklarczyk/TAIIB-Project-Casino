
using Casino.BLL;
using Microsoft.AspNetCore.Mvc;

namespace Casino.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ResultController : Controller
    {
        private readonly IResults _result;

        public ResultController(IResults res)
        {
            this._result = res;
        }
/*
        [HttpGet("GetAllResults/{userID},{gameID}")]
        public ActionResult GetResults(int userID, int gameID)
        { 
            return Ok(_result.GetResult(userID, gameID));
        }

        [HttpGet("GetUserResult/{userID}")]
        public ActionResult GetResultsUser(int userID)
        {
            return Ok(_result.GetAllUserResults(userID));
        }

        [HttpGet("GetGameResult/{gameID}")]
        public ActionResult GetResultsGame(int gameID)
        {
            return Ok(_result.GetAllGameResults(gameID));
        }*/
    }
}