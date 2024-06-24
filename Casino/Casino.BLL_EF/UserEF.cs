using AutoMapper;
using Casino.BLL;
using Casino.BLL.DTO;
using Casino.DAL;
using Casino.Model;
using Casino.Model.DataTypes;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Casino.BLL_EF
{
    public class UserEF : IUsers
    {
        public UserEF(CasinoDbContext dbContext,IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager, ClaimsPrincipal claims)
        { _context = dbContext; this.mapper = mapper; this.claims = claims; this.userManager = userManager; this.signIn = signInManager; }

        private CasinoDbContext _context ;
        private readonly ClaimsPrincipal claims;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signIn;
        private readonly IMapper mapper;
        
        public async Task<UserResponseDTO> Login(UserRequestDTO user)
        {
           var us= await userManager.FindByNameAsync(user.Login);
            if (us != null)
            {
                var result = await signIn.PasswordSignInAsync(us, user.Password, true, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return mapper.Map<UserResponseDTO>(us);
                }
                
            }
            return null;
        }

        public UserResponseDTO Register(UserRequestDTO user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserResponseDTO> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public UserResponseDTO GetUserInformation()
        {
            string userId = claims.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var userInfo = userManager.Users.Where(u => u.Id == int.Parse(userId)).Select(u => new UserResponseDTO
            {
                UserId = u.UserId,
                Avatar = u.Avatar,
                Credits = u.Credits,
                Email = u.Email,
                NickName = u.NickName,
                //Results = mapper.Map<List<ResultResponseDTO>>(u.Results),
             //   Transactions = mapper.Map<List<TransactionsResponseDTO>>(u.Transactions)
            }).FirstOrDefault();
            return userInfo;
        }

        internal bool addCredits(int amount)
        {
            string userId = claims.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var xd = userManager.Users.FirstOrDefault(x=>x.Id== int.Parse(userId));
            if (xd == null) return false;
            xd.Credits += amount;
            userManager.UpdateAsync(xd);
            
            return true;
        }
        internal bool removeCredits(int amount)
        {
            string userId = claims.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var xd = userManager.Users.FirstOrDefault(x => x.Id == int.Parse(userId));
            if (xd == null||xd.Credits<amount) return false;
            xd.Credits -= amount;
            userManager.UpdateAsync(xd);
            return true;
        }
    }
}
