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
    public class Bandit
    {
        [Key]
        public int BanditId { get; set; }
        public int GameId { get; set; }
        [ForeignKey(nameof(GameId))]
        public required Game Game { get; set; }
        [MaxLength(500)]
        public required string Description { get; set; }
        public required BanditType Position1 { get; set; }
        public required BanditType Position2 { get; set; }
        public required BanditType Position3 { get; set; }

        public void Configure(EntityTypeBuilder<Bandit> builder)
        {
            builder.HasOne(x => x.Game)
                .WithOne(x => x.Bandit) //?
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
