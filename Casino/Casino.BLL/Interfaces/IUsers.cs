using Casino.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.BLL
{
    public interface IUsers
    {
        public Task<UserResponseDTO> Login(UserRequestDTO user);
        public UserResponseDTO Register(UserRequestDTO user);
        public IEnumerable<UserResponseDTO> GetAllUsers();
        public UserResponseDTO GetUserInformation();
        
    }
}
