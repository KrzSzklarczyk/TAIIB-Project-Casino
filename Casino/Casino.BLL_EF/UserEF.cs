using AutoMapper;
using Casino.BLL;
using Casino.BLL.DTO;
using Casino.DAL;
using Casino.Model;
using Casino.Model.DataTypes;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Casino.BLL_EF
{
    public class UserEF : IUser
    {
        public UserEF(CasinoDbContext dbContext,IMapper mapper_, AuthSettings set) { _context = dbContext; mapper = mapper_; _authenticationSettings = set; }
        private CasinoDbContext _context ;
        private IMapper mapper;
        private readonly AuthSettings _authenticationSettings;

        private string GetToken(User user)
        {


            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Name, $"{user.NickName}"),
                new Claim(ClaimTypes.Role, $"{user.UserType.ToString()}"),
                new Claim(ClaimTypes.Email, user.Email),
               
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiredDate = DateTime.Now.AddDays(_authenticationSettings.JwtExpiredDays);

            var token = new JwtSecurityToken(_authenticationSettings.JwtIssuer, _authenticationSettings.JwtIssuer, claims, expires: expiredDate, signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        private string GetRefreshToken()
        {
            var randomNumber = new byte[64];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
            }

            return Convert.ToBase64String(randomNumber);
        }
        private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParamters = new TokenValidationParameters()
            {
                ValidIssuer = _authenticationSettings.JwtIssuer,
                ValidAudience = _authenticationSettings.JwtIssuer,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey))
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            SecurityToken securityToken;
            var principal = tokenHandler.ValidateToken(token, tokenValidationParamters, out securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;

            if (jwtSecurityToken is null || !jwtSecurityToken.Header.Alg.
                Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Invalid token");

            }
            return principal;
        }
        private UserTokenResponse CreateToken(User user, bool populateExp)
        {
            var refreshToken = GetRefreshToken();

            user.RefreshToken = refreshToken;

            if (populateExp)
            {
                user.RefreshTokenExpiryDate = DateTime.UtcNow.AddDays(7);
            }


            _context.Update(user);
            _context.SaveChanges();
            var token = GetToken(user);
            var response = new UserTokenResponse(token, refreshToken);



            return response;
        }
        public UserTokenResponse LoginUser(UserRequestDTO dto, bool populateExp = true)
        {
            var user = _context.Users.Include(u => u.UserType).FirstOrDefault(u => u.Login == dto.Login&&u.Password==dto.Password);
           
          if(user == null) { return null; }

            return CreateToken(user, populateExp);
        }
        public void RegisterUser(UserRegisterDto dto)
        {
            var newUser = _mapper.Map<User>(dto);
            _context.Users.Add(newUser);
            _context.SaveChanges();
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
