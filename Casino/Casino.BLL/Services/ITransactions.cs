using Casino.BLL.Authentication;
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
        public List<TransactionsResponseDTO> GetHistory( UserTokenResponse token);
        public bool AddTransaction(int amount, UserTokenResponse token);
    }
}
