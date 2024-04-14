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
        GameDTO GetGameInfo(int gameId);
        BlackJackDTO GetBlackJackInfo(int gameId);
        BanditDTO GetBanditInfo(int gameId);
        RouletteDTO GetRouletteInfo(int gameId);
    }
}
