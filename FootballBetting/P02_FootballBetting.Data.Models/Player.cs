using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static P02_FootballBetting.Common.EntityValidationConstants.Player;

namespace P02_FootballBetting.Data.Models
{
    public class Player
    {
        //PlayerId, Name, SquadNumber, IsInjured, PositionId , TeamId, TownId 
        [Key]
        public int PlayerId { get; set; }

        [Required]
        [MaxLength(PlayerNameMaxLength)]
        public string Name { get; set; } = null!;
        
        public int SquadNumber { get; set; }

        public bool IsInjured { get; set; }
        
        [ForeignKey(nameof(Position))]
        public  int PositionId { get; set; }
        public virtual Position Position { get; set; } = null!;

        [ForeignKey(nameof(Team))]
        public  int TeamId { get; set; }
        public virtual Team Team { get; set; } = null!;

        [ForeignKey(nameof(Town))]
        public int TownId { get; set; }
        public virtual Town Town { get; set; } = null!;

        public virtual ICollection<PlayerStatistic> PlayersStatistics { get; set; } = new List<PlayerStatistic>();

    }
}
