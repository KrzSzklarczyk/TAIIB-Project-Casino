using Casino.BLL;
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

        [HttpGet("History/{userid}")]
        public ActionResult ViewHistory(int userID)
        {
            var history = _transactions.GetHistory(userID);
            return Ok(history);
        }

        [HttpPost("New")]
        public ActionResult AddTransaction(TransactionsDTO transactions)
        {
            var transtaction = _transactions.AddTransaction(transactions);
            return Ok(transtaction);
        }
    }
}
