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
        ResultDTO GetResult(int userId, int gameId);
        IEnumerable<ResultDTO> GetAllUserResults(int userId);
        IEnumerable<ResultDTO> GetAllGameResults(int gameId);
    }
}
