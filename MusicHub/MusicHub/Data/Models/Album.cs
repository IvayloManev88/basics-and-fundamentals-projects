using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicHub.Data.Models
{
    public class Album
    {
        /*
         * •	Id – integer, Primary Key
•	Name – text with max length 40 (required)
•	ReleaseDate – date (required)
•	Price – calculated property (the sum of all song prices in the album)
•	ProducerId – integer, foreign key
•	Producer – the Album's Producer
•	Songs – a collection of all Songs in the Album 
*/
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime ReleaseDate { get; set; }
        public decimal Price => this.Songs.Sum(s => s.Price);
        public int? ProducerId { get; set; }
        public virtual Producer? Producer { get; set; }
        public virtual ICollection<Song> Songs { get; set; } = new HashSet<Song>();
    }
}
  