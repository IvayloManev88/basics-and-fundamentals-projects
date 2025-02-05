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
                    Order currentOrder = orders.First(x => x.Name.Contains(inputs[0]));

                    currentOrder.Volume += int.Parse(inputs[2]);
                    currentOrder.Price = decimal.Parse(inputs[1]);
                    currentOrder.ChangeTotal(currentOrder.Price, currentOrder.Volume);
                        
                    
                }
                else
                {
                    orders.Add(new Order(inputs[0], decimal.Parse(inputs[1]), int.Parse(inputs[2])));
                }
            }
            foreach (Order order in orders)
            {
                Console.WriteLine($"{order.Name} -> {order.Total}");
            }
        }
    }
    public class Order
    {
        public Order(string name, decimal price, int volume)
        {
            Name = name;
            Price = price;
            Volume = volume;
            Total = price * volume;
        }


        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Volume { get; set; }
        public decimal Total { get; set; }

        public void ChangeTotal(decimal price, int volume)
        {
            Total = price * volume;
        }
    }



}
