using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.Model
{
    public class Result
    {
        [Key]
        public int ResultId { get; set; }
        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public required User User { get; set; }
        public int GameId { get; set; }
        [ForeignKey(nameof(GameId))]
        public required Game Game { get; set; }
        public DateTime DateTime { get; set; }
        public required int Amount { get; set; }

        public void Configure(EntityTypeBuilder<Roulette> builder)
        {
            //?
        }
    }
}
