using AutoMapper;
using Casino.BLL;
using Casino.BLL.Authentication;
using Casino.BLL.DTO;
using Casino.DAL;
using Casino.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Casino.BLL_EF
{
    public class ResultEF : IResults
    {
        public ResultEF(CasinoDbContext dbContext, UserEF use)
        {
            _context = dbContext;
            this.use = use;
        }
        public UserEF use;
        public  CasinoDbContext _context ;

        public ResultResponseDTO GetResult(ResultRequestDTO result, UserTokenResponse token)
        {
            
                var principal = use.GetPrincipalFromExpiredToken(token.AccessToken);
                var userIdClaim = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

                if (userIdClaim is null)
                {
                    throw new SecurityTokenException("UserId was not found");
                }

                var userId = int.Parse(userIdClaim.Value);
                var user = _context.Users.FirstOrDefault(u => u.UserId == userId);

                if (user == null || user.RefreshToken != token.RefreshToken || user.RefreshTokenExpiryDate <= DateTime.UtcNow)
                {
                    throw new SecurityTokenException();
                }
            // return mapper.Map<UserResponseDTO>(user);
            throw new NotImplementedException();

        }

        public List<ResultResponseDTO> GetAllUserResults(ResultRequestDTO result, UserTokenResponse token)
        {
            throw new NotImplementedException();
        }

        public List<ResultResponseDTO> GetAllGameResults(ResultRequestDTO result, UserTokenResponse token)
        {
            throw new NotImplementedException();
        }
    }
}
