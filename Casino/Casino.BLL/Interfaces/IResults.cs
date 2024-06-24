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
        public ResultResponseDTO GetResult(ResultRequestDTO Id);
        public IEnumerable<ResultResponseDTO> GetAllUserResults(ResultRequestDTO Id);
        public IEnumerable<ResultResponseDTO> GetAllGameResults(ResultRequestDTO Id);
    }
}
