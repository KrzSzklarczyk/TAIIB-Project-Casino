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
    public class BlackJack
    {
        [Key]
        public int BlackJackId { get; set; }
        public int GameId { get; set; }
        [ForeignKey(nameof(BlackJackId))]
        public required Game Game { get; set; }
        [MaxLength(500)]
        public required string Description { get; set; }
        public required int DealerHunt { get; set; }
        public required int UserHunt { get; set; }

        public void Configure(EntityTypeBuilder<BlackJack> builder)
        {
            builder.HasOne(x => x.Game)
                .WithOne(x => x.BlackJack)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
