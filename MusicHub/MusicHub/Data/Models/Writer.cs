using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicHub.Data.Models
{
    public class Writer
    {

        /*
         * •	Id – integer, Primary Key
•	Name – text with max length 20 (required)
•	Pseudonym – text
•	Songs – a collection of type Song

         * */

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Pseudonym { get; set; }
        public virtual ICollection<Song> Songs { get; set; } = new HashSet<Song>();
    }
}
