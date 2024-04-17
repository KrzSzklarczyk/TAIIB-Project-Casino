﻿using Casino.BLL;
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
            this._transactions = t;
        }
        [HttpGet("transakcje")]
        public ITransactions? Get_transactions()
        {
            return _transactions;
        }
        
        [HttpPost("historia")]
        public ActionResult ViewHistory(int userId, ITransactions? _transactions)
        {
            var history = _transactions.GetHistory(userId);
            return Ok(history);
        }
    }
}
