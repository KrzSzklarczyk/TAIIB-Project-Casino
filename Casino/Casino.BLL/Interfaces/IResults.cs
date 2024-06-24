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
        public Task<ResultResponseDTO> GetResult(ResultRequestDTO result);
        public Task<List<ResultResponseDTO>> GetAllUserResults(ResultRequestDTO result);
        public Task<List<ResultResponseDTO>> GetAllGameResults(ResultRequestDTO result);
    }
}
