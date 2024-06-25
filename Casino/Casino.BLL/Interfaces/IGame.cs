using Casino.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.BLL
{
    public interface IGame
    {
        public Task<GameResponseDTO> GetGameInfo(GameRequestDTO gameId);
       
        public Task<BanditResponseDTO> GetBanditInfo(GameRequestDTO gameId);
        public Task<RouletteResponseDTO> GetRouletteInfo(GameRequestDTO gameId);
        public Task<ResultResponseDTO> PlayBandit(UserRequestDTO user, BanditRequestDTO bandit);
        public Task<ResultResponseDTO> PlayRoulette(UserRequestDTO user, RouletteRequestDTO roulette);
    }
}
