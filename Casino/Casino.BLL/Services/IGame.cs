using Casino.BLL.Authentication;
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
        public GameResponseDTO GetGameInfo(GameRequestDTO gameId);
       
        public BanditResponseDTO GetBanditInfo(GameRequestDTO gameId);
        public RouletteResponseDTO GetRouletteInfo(GameRequestDTO gameId);
        public bool PlayBandit(UserTokenResponse token, BanditRequestDTO bandit);
        public ResultResponseDTO PlayRoulette(UserTokenResponse token, RouletteRequestDTO roulette);
    }
}
