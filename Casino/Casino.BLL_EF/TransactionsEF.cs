using Casino.BLL;
using Casino.BLL.DTO;
using Casino.DAL;

namespace Casino.BLL_EF
{
    public class TransactionsEF : ITransactions
    {
        public TransactionsEF(CasinoDbContext dbContext) { _context = dbContext; }

 

        private  CasinoDbContext _context ;

        public Task<List<TransactionsResponseDTO>> GetHistory(TransactionsRequestDTO id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddTransaction(int amount, UserRequestDTO user)
        {
            throw new NotImplementedException();
        }
    }
}
