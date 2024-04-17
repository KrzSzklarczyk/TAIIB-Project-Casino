using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Casino.Model.DataTypes;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Casino.Model
{
    public class Roulette
    {
        [Key]
        public int RouletteId { get; set; }
        public int GameId { get; set; }
        [ForeignKey(nameof(GameId))]
        public required Game Game { get; set; }
        [MaxLength(500)]
        public required string Description { get; set; }
        public required BetType BetType { get; set; }
        
        public void Configure(EntityTypeBuilder<Roulette> builder)
        {
            builder.HasOne(x => x.Game)
                .WithOne(x => x.Roulette)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
