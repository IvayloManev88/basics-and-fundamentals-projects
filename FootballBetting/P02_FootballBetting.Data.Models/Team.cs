using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static P02_FootballBetting.Common.EntityValidationConstants.Team;

namespace P02_FootballBetting.Data.Models
{
    public class Team
    {
       
        //TeamId, Name, LogoUrl, Initials (JUV, LIV, ARS…), Budget, PrimaryKitColorId, SecondaryKitColorId, TownId
        [Key]
        public int TeamId { get; set; }

        [Required]
        [MaxLength(TeamNameMaxLength)]
        public string Name { get; set; } = null!;

        [MaxLength(TeamLogoUrlMaxLength)]
        public string ?LogoUrl { get; set; }

        [Required]
        [MaxLength(TeamInitialsMaxLength)]
        public string Initials { get; set; } = null!;

        public decimal Budget { get; set; }

        // public int PrimaryKitColorId { get; set; }
        [ForeignKey(nameof(PrimaryKitColor))]
        public int PrimaryKitColorId { get; set; }
        public virtual Color PrimaryKitColor { get; set; } = null!;

        // public int SecondaryKitColorId { get; set; }
        [ForeignKey(nameof(SecondaryKitColor))]// This relates the FK to the Navigational property!!
        public int SecondaryKitColorId { get; set; }
        public virtual Color SecondaryKitColor { get; set; } = null!;

        // public int TownId { get; set; }
        [ForeignKey(nameof(Town))]
        public int TownId { get; set; }
        public virtual Town Town { get; set; } = null!;

        [InverseProperty(nameof(Game.HomeTeam))]
        public virtual ICollection<Game> HomeGames { get; set; } = new HashSet<Game>();
        [InverseProperty(nameof(Game.AwayTeam))]
        public virtual ICollection<Game> AwayGames { get; set; } = new HashSet<Game>();

        public virtual ICollection<Player> Players { get; set; } = new HashSet<Player>();
    }
}
