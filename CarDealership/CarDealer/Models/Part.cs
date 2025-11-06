using System.ComponentModel.DataAnnotations;

namespace CarDealer.Models
{
    public class Part
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = null!; 

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public int SupplierId { get; set; }

        public virtual Supplier Supplier { get; set; } = null!;

        public virtual ICollection<PartCar> PartsCars { get; set; } = new HashSet<PartCar>();
    }
}
