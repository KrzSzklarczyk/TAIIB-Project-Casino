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
        public IEnumerable<TransactionsResponseDTO> GetHistory(TransactionsRequestDTO Id);
        public bool AddTransaction(TransactionsResponseDTO transaction);
    }
}
