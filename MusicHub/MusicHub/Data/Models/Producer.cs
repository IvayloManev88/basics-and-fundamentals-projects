using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicHub.Data.Models
{
    public class Producer
    {
        /*
        Id – integer, Primary Key
•	Name – text with max length 30 (required)
•	Pseudonym – text
•	PhoneNumber – text
•	Albums – a collection of type Album

        */
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public string? Pseudonym { get; set; }
        public string? PhoneNumber { get; set; }
        public virtual ICollection<Album> Albums { get; set; } = new HashSet<Album>();
    }
}
