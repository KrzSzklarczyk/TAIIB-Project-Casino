using Casino.BLL;
using Casino.BLL.DTO;
using Casino.DAL;
using Casino.Model.DataTypes;
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
            var user = _context.Users.FirstOrDefault(x => x.Login == username && x.Password == password);
            if (user == null) return null;
            var res = new ResultEF();
            var trans = new TransactionsEF();
            return new UserDTO { Credits = user.Credits, Email = user.Email, NickName = user.NickName, UserId = user.UserId, Results = res.GetAllUserResults(user.UserId).ToList(), Transactions = trans.GetHistory(user.UserId).ToList() };
        }

        public void Logout()
        {

        }

        public UserDTO Register(UserDTO user)
        {
            var xd = _context.Users.FirstOrDefault(x => x.Login == user.Login && x.Password == user.Password);
            if (xd != null) return null;
            _context.Users.Add(new Model.User { Credits = 0, Email = user.Email, Login = user.Login, NickName = user.NickName, Password = user.Password, Results = null, Transactions = null });
        
            _context.SaveChanges();
            return user;
        }
    }
}
