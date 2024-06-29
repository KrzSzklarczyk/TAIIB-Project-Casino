using Casino.BLL.Authentication;
using Casino.BLL.DTO;
using Casino.Model.DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.BLL
{
    public interface IUser
    {
        public UserTokenResponse Login(UserRequestDTO user);
        public UserTokenResponse Register(UserRegisterRequestDTO user);
        public int GetCredits(UserTokenResponse token);
        public UserResponseDTO GetUserInfo(UserTokenResponse token);
        public UserTokenResponse RefreshToken(UserTokenResponse token);
        public List<UserResponseDTO> GetAllUsers(UserTokenResponse token);
        public int GetUserRole(UserTokenResponse token);
        
    }
}
