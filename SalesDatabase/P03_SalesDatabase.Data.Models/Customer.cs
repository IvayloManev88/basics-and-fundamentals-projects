using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03_SalesDatabase.Data.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? CreditCardNumber { get; set; } 
        public virtual ICollection<Sale> Sales { get; set; } = new HashSet<Sale>();

    }
}
