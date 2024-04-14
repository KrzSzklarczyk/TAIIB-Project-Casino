using Casino.BLL;
using Casino.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.BLL_EF
{
    public class GameEF : IGame
    {
        public BanditDTO GetBanditInfo(int gameId)
        {
            throw new NotImplementedException();
        }

        public BlackJackDTO GetBlackJackInfo(int gameId)
        {
            throw new NotImplementedException();
        }

        public GameDTO GetGameInfo(int gameId)
        {
            throw new NotImplementedException();
        }

        public RouletteDTO GetRouletteInfo(int gameId)
        {
            throw new NotImplementedException();
        }
    }
}
