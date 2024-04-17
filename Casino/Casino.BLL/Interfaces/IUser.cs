using Casino.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.BLL
{
    public interface IUser
    {
        public UserDTO Login(string username, string password);
        public void Logout();
        public UserDTO Register(UserDTO user);
    }
}
