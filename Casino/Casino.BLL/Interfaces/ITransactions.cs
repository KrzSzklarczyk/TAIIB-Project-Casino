using Casino.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.BLL
{
    public interface ITransactions
    {
        public Task<List<TransactionsResponseDTO>> GetHistory(TransactionsRequestDTO id);
        public Task<bool> AddTransaction(int amount,UserRequestDTO user);
    }
}
