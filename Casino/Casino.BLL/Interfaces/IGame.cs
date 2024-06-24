using Casino.BLL.DTO;
using Casino.Model.DataTypes;
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
        public BlackJackResponseDTO GetBlackJackInfo(GameRequestDTO gameId);
        public BanditResponseDTO GetBanditInfo(GameRequestDTO gameId);
        public RouletteResponseDTO GetRouletteInfo(GameRequestDTO gameId);
        public RouletteResponseDTO PlayRoullete(int amount,BetType betType);
        public BlackJackResponseDTO PlayBlackJack(int amount);
        public BanditResponseDTO PlauBandit(int amount);

    }
}
