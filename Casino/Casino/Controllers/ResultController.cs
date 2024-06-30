
using Casino.BLL;
using Casino.BLL.Authentication;
using Casino.BLL.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

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

      [HttpPost("GetAllResults/{userID},{gameID}")]
        public ActionResult GetResults(int userID, int gameID, [FromBody]UserTokenResponse toekn )
        { 
            var rez = new ResultRequestDTO { UserId=userID,GameId=gameID };
            var odp = _result.GetResult(rez,toekn);
            return odp==null?BadRequest("bledne dane lub brak"): Ok (odp);
        }

        [HttpPost("GetUserResult/{userID}")]
        public ActionResult GetResultsUser(int userID, [FromBody] UserTokenResponse toekn)
        {
            var rez = new ResultRequestDTO { UserId = userID };
            var odp = _result.GetAllUserResults( toekn);
            return odp == null ? BadRequest("bledne dane lub brak") : Ok(odp);
            
        }

        [HttpPost("GetGameResult/{gameID}")]
        public ActionResult GetResultsGame(int gameID, [FromBody] UserTokenResponse toekn)
        {
            var rez = new ResultRequestDTO {  GameId = gameID };
            var odp = _result.GetAllGameResults(rez, toekn);
            return odp == null ? BadRequest("bledne dane lub brak") : Ok(odp);
            
        }
    }
}