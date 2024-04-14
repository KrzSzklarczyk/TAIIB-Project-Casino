using Casino.BLL;
using Casino.BLL.DTO;
using Casino.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
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
        }
    }
}
