using Casino.BLL;
using Casino.BLL.DTO;
using Casino.DAL;

namespace Casino.BLL_EF
{
    public class TransactionsEF : ITransactions
    {
        private CasinoDbContext _context = new CasinoDbContext();

        public IEnumerable<TransactionsDTO> GetHistory(int userId)
        {
            var help = _context.Transactions.Where(t => t.UserId == userId);
            List<TransactionsDTO> result = help.Select(x => new TransactionsDTO { Amount = x.Amount, UserId = x.UserId, Date = x.Date, TransactionId = x.TransactionId }).ToList();
            return result;
        }
        public bool AddTransaction(TransactionsDTO transaction)
        {
            Model.Transactions tran = new Model.Transactions { Amount = (double)transaction.Amount, UserId = (int)transaction.UserId, Date = (DateTime)transaction.Date, User = _context.Users.SingleOrDefault(x => x.UserId == transaction.UserId) };
            _context.Transactions.Add(tran);
            _context.Users.FirstOrDefault(x => x.UserId == transaction.UserId).Credits += (int)transaction.Amount;
            _context.SaveChanges();
            return true;
        }
    }
}
