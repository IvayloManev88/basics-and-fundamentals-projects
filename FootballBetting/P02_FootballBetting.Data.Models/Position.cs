using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static P02_FootballBetting.Common.EntityValidationConstants.Position;

namespace P02_FootballBetting.Data.Models
{
    public class Position
    {

        [Key]
        public int PositionId { get; set; }

        [Required]
        [MaxLength(PositionNameMaxLength)]
        public string Name { get; set; } = null!;

        public virtual ICollection<Player> Players { get; set; } = new HashSet<Player>();
    }
}
