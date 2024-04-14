
using Casino.BLL;
using Microsoft.AspNetCore.Mvc;

namespace Casino.Controllers
{
    [ApiController]
    [Route("[web/Results]")]
    public class ResultController : Controller
    {
        private readonly IResults _result;

        public ResultController(IResults res)
        {
            this._result = res;
        }

        [HttpGet]
        public ActionResult GetResults(int userID, int gameID)
        {
            _result.GetResult(userID, gameID);
            return Ok();
        }
    }
}