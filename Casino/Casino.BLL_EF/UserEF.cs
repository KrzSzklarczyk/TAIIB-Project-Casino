using Casino.BLL;
using Casino.BLL.DTO;
using Casino.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.BLL_EF
{
    public class UserEF : IUser
    {
        public CasinoDbContext _context = new CasinoDbContext();
        public UserDTO Login(string username, string password)
        {
           var user = _context.Users.First(x=>x.Login == username && x.Password == password);
            var res = new ResultEF();
            var trans = new TransactionsEF();
            return new UserDTO { Credits = user.Credits, Email = user.Email, NickName = user.NickName, UserId = user.UserId, Results = res.GetAllUserResults(user.UserId).ToList(), Transactions = trans.GetHistory(user.UserId).ToList() };
        }
    }
}
