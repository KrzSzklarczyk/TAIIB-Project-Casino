using Casino.BLL;
using Casino.BLL.DTO;
using Casino.DAL;
using Casino.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.BLL_EF
{
    public class ResultEF : IResult
    {
        public CasinoDbContext _context=new CasinoDbContext();
        public IEnumerable<ResultDTO> GetAllGameResults(int gameId)
        {
            var help = _context.Results.Where(t => t.GameId == gameId);
            List<ResultDTO> result = help.Select(x => new ResultDTO { Amount=x.Amount,DateTime=x.DateTime,GameId=x.GameId,ResultId=x.ResultId,UserId=x.UserId }).ToList();
            return result;
        }

        public IEnumerable<ResultDTO> GetAllUserResults(int userId)
        {
            var help = _context.Results.Where(t => t.UserId == userId);
            List<ResultDTO> result = help.Select(x => new ResultDTO { Amount = x.Amount, DateTime = x.DateTime, GameId = x.GameId, ResultId = x.ResultId, UserId = x.UserId }).ToList();
            return result;
        }

        public ResultDTO GetResult(int userId, int gameId)
        {
            var help = _context.Results.First(t => t.UserId == userId && t.GameId==gameId);
            var result = new ResultDTO { Amount = help.Amount, DateTime = help.DateTime, GameId = help.GameId, ResultId = help.ResultId, UserId = help.UserId };
            return result;
        }
    }
}
