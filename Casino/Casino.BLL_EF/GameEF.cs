using AutoMapper;
using Casino.BLL;
using Casino.BLL.Authentication;
using Casino.BLL.DTO;
using Casino.DAL;
using Microsoft.EntityFrameworkCore;

namespace Casino.BLL_EF
{
    public class GameEF : IGame
    {
        public GameEF(CasinoDbContext dbContext,IMapper _mapper) { context = dbContext;mapper = _mapper; }
  
        private  CasinoDbContext context;
        private IMapper mapper;

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

        public ResultResponseDTO PlayBandit(UserTokenResponse token, BanditRequestDTO bandit)
        {
            throw new NotImplementedException();
        }

        public ResultResponseDTO PlayRoulette(UserTokenResponse token, RouletteRequestDTO roulette)
        {
            throw new NotImplementedException();
        }
    }
}
