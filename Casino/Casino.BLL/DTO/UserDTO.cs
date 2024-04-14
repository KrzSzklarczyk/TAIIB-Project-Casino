using Casino.Model.DataTypes;
using Casino.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.BLL.DTO
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public List<TransactionsDTO>? Transactions { get; set; }
        public List<ResultDTO>? Results { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        public string Email { get; set; }
        public string NickName { get; set; }
        public int Credits { get; set; }
    }
}
