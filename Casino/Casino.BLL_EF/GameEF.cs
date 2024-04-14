﻿using Casino.BLL;
using Casino.BLL.DTO;
using Casino.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.BLL_EF
{
    public class GameEF : IGame
    {
        public CasinoDbContext context = new CasinoDbContext();
        public BanditDTO GetBanditInfo(int gameId)
        {
            var war = context.Bandits.First(x => x.GameId==gameId);
            return new BanditDTO { BanditId = war.BanditId,Description = war.Description,GameId = war.GameId, Position1 = war.Position1, Position2 = war.Position2, Position3=war.Position3};
        }

        public BlackJackDTO GetBlackJackInfo(int gameId)
        {
            var war = context.BlackJacks.First(x => x.GameId == gameId);
            return new BlackJackDTO { BlackJackId = war.BlackJackId, Description = war.Description, GameId = war.GameId, DealerHunt=war.DealerHunt,UserHunt=war.UserHunt};
        }

        public GameDTO GetGameInfo(int gameId)
        {
            var war = context.Games.First(x => x.GameId == gameId);
            return new GameDTO { BlackJackId = war.BlackJackId, Description = war.Description, GameId = war.GameId, BanditId= war.BanditId, EndDate = war.EndDate, MaxBet= war.MaxBet, MinBet=war.MinBet, ResultId=war.ResultId,RouletteId=war.RouletteId, StartDate=war.StartDate };

        }

        public RouletteDTO GetRouletteInfo(int gameId)
        {
            var war = context.Roulettes.First(x => x.GameId == gameId);
            return new RouletteDTO { RouletteId = war.RouletteId, Description = war.Description, GameId = war.GameId, BetType=war.BetType };

        }
    }
}
