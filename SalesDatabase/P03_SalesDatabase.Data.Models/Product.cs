namespace P03_SalesDatabase.Data.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = null!;
        public double Quantity { get; set; }
        public decimal Price { get; set; }
        public virtual ICollection<Sale> Sales { get; set; } = new HashSet<Sale>();


    }
}
