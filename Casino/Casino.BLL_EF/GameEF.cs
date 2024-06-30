using AutoMapper;
using Casino.BLL;
using Casino.BLL.Authentication;
using Casino.BLL.DTO;
using Casino.DAL;
using Casino.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace Casino.BLL_EF
{
    public class GameEF : IGame
    {
        public GameEF(CasinoDbContext dbContext, IMapper mapper_, AuthSettings set, UserEF userEF)
        {
            context = dbContext; mapper = mapper_; _authenticationSettings = set; _userEF = userEF;
        }
        private CasinoDbContext context;
        private IMapper mapper;
        private readonly AuthSettings _authenticationSettings;
        private UserEF _userEF;
        

        public GameResponseDTO GetGameInfo(GameRequestDTO gameId)
        {
            var xd = context.Games.FirstOrDefault(x => x.GameId == gameId.GameId);
            if (xd == null) { return null; }
            return mapper.Map<GameResponseDTO>(xd);
        }

        public BanditResponseDTO GetBanditInfo(GameRequestDTO gameId)
        {
            var xd = context.Bandits.FirstOrDefault(x => x.GameId == gameId.GameId);
            if (xd == null) { return null; }
            return mapper.Map<BanditResponseDTO>(xd);
        }

        public RouletteResponseDTO GetRouletteInfo(GameRequestDTO gameId)
        {
            var xd = context.Roulettes.FirstOrDefault(x => x.GameId == gameId.GameId);
            if (xd == null) { return null; }
            return mapper.Map<RouletteResponseDTO>(xd);
        }


        public ResultResponseDTO PlayRoulette(UserTokenResponse token, RouletteRequestDTO roulette)
        {
            throw new NotImplementedException();
        }

        bool IGame.PlayBandit(UserTokenResponse token, BanditRequestDTO bandit)
        {
            if(bandit.betAmount<25)return false;
           
                var principal = _userEF.GetPrincipalFromExpiredToken(token.AccessToken);
                var userIdClaim = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

                if (userIdClaim is null)
                {
                    throw new SecurityTokenException("UserId was not found");
                }

                var userId = int.Parse(userIdClaim.Value);
                var user = context.Users.FirstOrDefault(u => u.UserId == userId);

                if (user == null || user.RefreshToken != token.RefreshToken || user.RefreshTokenExpiryDate <= DateTime.UtcNow)
                {
                    throw new SecurityTokenException();
                }
                if(user.Credits<bandit.betAmount)return false;

            int amo;
            if(bandit.pos3==bandit.pos2&& bandit.pos2 == bandit.pos1)
            {
               amo= bandit.betAmount*(bandit.pos1+1)*100;
                
            }
            else if(bandit.pos3 == bandit.pos2|| bandit.pos2 == bandit.pos1)
            {
               amo= bandit.betAmount * (bandit.pos1 + 1) * 10;
            }
            else { amo= -bandit.betAmount; }
            user.Credits += amo;
            context.Users.Update(user);
            Game game = new Game { Description = "test", EndDate = DateTime.UtcNow, MaxBet = 999999999, MinBet = 25, StartDate = DateTime.UtcNow ,amount=bandit.betAmount};
            Bandit bandit1 = new Bandit { Description = "test", Game = game, Position1 = bandit.pos1, Position2 = bandit.pos2, Position3 = bandit.pos3 };
            game.Bandit = bandit1;
            context.Games.Add(game);
            context.Bandits.Add(bandit1);
            Result result = new Result { Amount = amo, Game = game, User = user };
            context.Results.Add(result);
            context.SaveChanges();
            return true;
            }
        
    }
}
