using AutoMapper;
using Casino.BLL;
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

        public Task<GameResponseDTO> GetGameInfo(GameRequestDTO gameId)
        {
            throw new NotImplementedException();
        }

        public Task<BanditResponseDTO> GetBanditInfo(GameRequestDTO gameId)
        {
            throw new NotImplementedException();
        }

        public Task<RouletteResponseDTO> GetRouletteInfo(GameRequestDTO gameId)
        {
            throw new NotImplementedException();
        }

        public Task<ResultResponseDTO> PlayBandit(UserRequestDTO user, BanditRequestDTO bandit)
        {
            throw new NotImplementedException();
        }

        public Task<ResultResponseDTO> PlayRoulette(UserRequestDTO user, RouletteRequestDTO roulette)
        {
            throw new NotImplementedException();
        }
    }
}
