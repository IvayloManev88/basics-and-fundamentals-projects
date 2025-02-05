using System.Diagnostics;

namespace Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            List<Order> orders = new();
            while ((input = Console.ReadLine()) != "buy")
            {
                string[] inputs = input.Split();
                
               if (orders.Any(x => x.Name.Contains(inputs[0])))
                {
                    foreach (Order order in orders)
                    {
                        if (order.Name == inputs[0])
                        {
                            order.Volume += int.Parse(inputs[2]);
                            order.Price = decimal.Parse(inputs[1]);
                            order.ChangeTotal(order.Price, order.Volume);
                        }
                    }
                }
               else
                {
                    orders.Add(new Order (inputs[0], decimal.Parse(inputs[1]), int.Parse(inputs[2])));
                }
            }
            foreach (Order order in orders)
            {
                Console.WriteLine($"{order.Name} -> {order.Total}");
            }
        }
    }
    public class Order
    {   public Order(string name, decimal price, int volume)
        {
            Name = name;
            Price = price;
            Volume = volume;
            Total = price* volume;
        }
    

        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Volume { get; set; }
        public decimal Total { get; set; }

        public void ChangeTotal(decimal price, int volume)
        {
            Total = price* volume;
        }
    }
    
    
    
}
