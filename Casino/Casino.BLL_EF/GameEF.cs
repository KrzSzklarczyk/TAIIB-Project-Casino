using AutoMapper;
using Casino.BLL;
using Casino.BLL.DTO;
using Casino.DAL;
using Casino.Model;
using Casino.Model.DataTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Casino.BLL_EF
{
    public class GameEF : IGame
    {
        public GameEF(CasinoDbContext dbContext, IMapper _mapper) { context = dbContext; mapper = _mapper; }//userEF =user; }
        private int Rmin = 10,Rmax=10000,Bmin=5,Bmax=2137,Bjmin=1,Bjmax=69420;
        private   CasinoDbContext context;
        private  IMapper mapper;
      private  Random random = new Random();
        private UserEF userEF;
        public GameResponseDTO GetGameInfo(GameRequestDTO gameId)
        {
           var gameInfo = context.Games.FirstOrDefault(x=>x.GameId==gameId.GameId);
            return mapper.Map<GameResponseDTO>(gameInfo);

        }

        public BlackJackResponseDTO GetBlackJackInfo(GameRequestDTO gameId)
        {
            var gameInfo = context.BlackJacks.FirstOrDefault(x => x.BlackJackId == gameId.GameId);
            return mapper.Map<BlackJackResponseDTO>(gameInfo);
        }

        public BanditResponseDTO GetBanditInfo(GameRequestDTO gameId)
        {
            var gameInfo = context.Bandits.FirstOrDefault(x => x.BanditId == gameId.GameId);
            return mapper.Map<BanditResponseDTO>(gameInfo);
        }

        public RouletteResponseDTO GetRouletteInfo(GameRequestDTO gameId)
        {
            var gameInfo = context.Roulettes.FirstOrDefault(x => x.RouletteId == gameId.GameId);
            return mapper.Map<RouletteResponseDTO>(gameInfo);
        }

        public RouletteResponseDTO PlayRoullete(int amount,BetType type)
        {
            if(amount >= Rmin&&amount<= Rmax) { }
            userEF.removeCredits(amount);
            Game game = new Game { Description = "Roullete", StartDate = DateTime.Now, EndDate = DateTime.MaxValue, MaxBet = Rmax, MinBet = Rmin };
            Roulette roultette = new Roulette { GameId = game.GameId, Game = game, BetType = type, Description = "Opis Rulleteka" };
            game.Result=getRoullete(roultette,amount);
            userEF.addCredits(game.Result.Amount);
          context.Games.Add(game);
            context.Roulettes.Add(roultette);
            context.Results.Add(game.Result);
            context.SaveChanges();
            return mapper.Map<RouletteResponseDTO>(roultette);
          

        }

        public BlackJackResponseDTO PlayBlackJack(int amount)
        {
            throw new NotImplementedException();
        }

        public BanditResponseDTO PlauBandit(int amount)
        {
            throw new NotImplementedException();
        }
        private Result getRoullete(Roulette game,int amount)
        {

            int roll = random.Next(0, 36);
            int res = amount;
            if (roll == 0 && game.BetType == BetType.green)
            {
                res *= 36;
            }
            else if (roll % 2 == 0 && game.BetType == BetType.black)
            {
                res *= 2;
            }
            else if (roll % 2 == 1 && game.BetType == BetType.red)
            {
                res *= 2;
            }
            else res = 0;
             return   new Result { Amount = res, Game = game.Game, User = mapper.Map<User>(userEF.GetUserInformation()), DateTime = DateTime.Now };
            }
    }
}
