using Casino.BLL;
using Casino.BLL.Authentication;
using Casino.BLL.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Casino.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionController : Controller
    {
        private readonly ITransactions _transactions;

        public TransactionController(ITransactions t)
        {
            _transactions = t;
        }

       [HttpPost("History/{userid}")]
        public ActionResult ViewHistory(int userID,[FromBody]UserTokenResponse user)
        {
            var history = _transactions.GetHistory(new TransactionsRequestDTO { UserId=userID},user);
            return Ok(history);
        }

        [HttpPost("New/{amount}")]
        public ActionResult AddTransaction(int amount, [FromBody] UserTokenResponse user)
        {
            var transtaction = _transactions.AddTransaction(amount,user);
            return Ok(transtaction);
        }
    }
}
