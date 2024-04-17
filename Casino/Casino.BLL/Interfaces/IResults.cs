using Casino.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.BLL
{
    public interface IResults
    {
        public ResultDTO GetResult(int userId, int gameId);
        public IEnumerable<ResultDTO> GetAllUserResults(int userId);
        public IEnumerable<ResultDTO> GetAllGameResults(int gameId);
    }
}
