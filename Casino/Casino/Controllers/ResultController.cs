
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

        [HttpGet]
        public ActionResult GetResults(int userID, int gameID)
        {
          
            return Ok(_result.GetResult(userID, gameID));
        }
    }
}