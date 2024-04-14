using Casino.Model.DataTypes;
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
    public class RouletteDTO
    {
        public int RouletteId { get; set; }
        public int GameId { get; set; }
        public required string Description { get; set; }
        public required BetType BetType { get; set; }
    }
}
