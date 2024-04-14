using Casino.BLL;
using Casino.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.BLL_EF
{
    public class ResultEF : IResult
    {
        public IEnumerable<ResultDTO> GetAllGameResults(int gameId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ResultDTO> GetAllUserResults(int userId)
        {
            throw new NotImplementedException();
        }

        public ResultDTO GetResult(int userId, int gameId)
        {
            throw new NotImplementedException();
        }
    }
}
