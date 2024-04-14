using Casino.BLL;
using Casino.BLL.DTO;
using Casino.DAL;
using Casino.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Casino.BLL_EF
{
    public class TransactionsEF : ITransactions
    {
        private CasinoDbContext _context = new CasinoDbContext();

        public IEnumerable<TransactionsDTO> GetHistory(int userId)
        {
            var help = _context.Transactions.Where(t => t.UserId == userId);
            List<TransactionsDTO> result = help.Select(x=>new TransactionsDTO { Amount = x.Amount, UserId =x.UserId,Date=x.Date,TransactionId=x.TransactionId}).ToList();
           return result;
        }
    }
}
