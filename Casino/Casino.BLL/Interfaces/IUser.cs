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
        public Task<UserResponseDTO> Login(UserRequestDTO user);
        public Task<UserResponseDTO> Register(UserRequestDTO user,UserResponseDTO dane);
        public Task<int>GetCredits();
        public Task<List<UserResponseDTO>> GetAllUsers();
        
    }
}
