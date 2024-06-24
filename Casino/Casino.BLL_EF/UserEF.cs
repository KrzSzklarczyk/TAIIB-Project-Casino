using AutoMapper;
using Casino.BLL;
using Casino.BLL.DTO;
using Casino.DAL;
using Casino.Model.DataTypes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Casino.BLL_EF
{
    public class UserEF : IUser
    {
        public UserEF(CasinoDbContext dbContext,IMapper mapper_,ClaimsPrincipal principal) { _context = dbContext; mapper = mapper_; claim = principal; }
        public ClaimsPrincipal claim;
        private CasinoDbContext _context ;
        private IMapper mapper;

        public Task<UserResponseDTO> Login(UserRequestDTO user)
        {
            return mapper.Map<Task<UserResponseDTO>>( _context.Users.FirstOrDefaultAsync(x=>x.Login==user.Login&&x.Password==user.Password));
        }

        public Task<UserResponseDTO> Register(UserRequestDTO user, UserResponseDTO dane)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetCredits()
        {
            throw new NotImplementedException();

        }

        public Task<List<UserResponseDTO>> GetAllUsers()
        {
            throw new NotImplementedException();
        }
    }
}
