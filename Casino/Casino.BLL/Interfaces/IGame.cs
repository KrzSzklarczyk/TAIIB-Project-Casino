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
        public GameDTO GetGameInfo(int gameId);
        public BlackJackDTO GetBlackJackInfo(int gameId);
        public BanditDTO GetBanditInfo(int gameId);
        public RouletteDTO GetRouletteInfo(int gameId);
    }
}
