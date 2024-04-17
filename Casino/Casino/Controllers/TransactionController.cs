using Casino.BLL;
using Casino.BLL.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace Casino.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionController : Controller
    {
        private readonly ITransactions _transactions;

        public TransactionController(ITransactions t)
        {
            this._transactions = t;
        }
      
        
        [HttpGet("historia/{userid}")]
        public ActionResult ViewHistory(int userid)
        {
            var history = _transactions.GetHistory(userid);
            return Ok(history);
        }
        [HttpPost("nowa")]
        public ActionResult AddTransaction(TransactionsDTO transactions)
        {
            var b = _transactions.AddTransaction(transactions);
          return Ok(b);
        }
    }
}
