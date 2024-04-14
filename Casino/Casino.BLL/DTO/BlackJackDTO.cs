using Casino.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.BLL.DTO
{
    public class BlackJackDTO
    {
        public int BlackJackId { get; set; }
        public int GameId { get; set; }
        public string Description { get; set; }
        public int DealerHunt { get; set; }
        public int UserHunt { get; set; }
    }
}
