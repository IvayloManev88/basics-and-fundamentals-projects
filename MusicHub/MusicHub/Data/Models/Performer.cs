using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicHub.Data.Models
{
    public class Performer
    {
        /*•	Id – integer, Primary Key
•	FirstName – text with max length 20 (required) 
•	LastName – text with max length 20 (required) 
•	Age – integer (required)
•	NetWorth – decimal (required)
•	PerformerSongs – a collection of type SongPerformer
*/
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int Age { get; set; }
        public decimal NetWorth { get; set; }
        public virtual ICollection<SongPerformer> PerformerSongs { get; set; } = new HashSet<SongPerformer>();

    }
}
