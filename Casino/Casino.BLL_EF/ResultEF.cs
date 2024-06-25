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
    public class ResultEF : IResults
    {
        public ResultEF(CasinoDbContext dbContext) { _context = dbContext; }

        public  CasinoDbContext _context ;

        public Task<ResultResponseDTO> GetResult(ResultRequestDTO result)
        {
            throw new NotImplementedException();
        }

        public Task<List<ResultResponseDTO>> GetAllUserResults(ResultRequestDTO result)
        {
            throw new NotImplementedException();
        }

        public Task<List<ResultResponseDTO>> GetAllGameResults(ResultRequestDTO result)
        {
            throw new NotImplementedException();
        }
    }
}
