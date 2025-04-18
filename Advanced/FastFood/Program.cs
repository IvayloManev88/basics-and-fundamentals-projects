namespace FastFood
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            int initialProducts = int.Parse(Console.ReadLine());
            Queue<int> orders = new (Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray());
            Console.WriteLine(orders.Max());
            while (orders.Count > 0 && initialProducts > 0)
            {
                if (initialProducts >= orders.Peek())
                {
                    int currentOrder = orders.Dequeue();
                    initialProducts-= currentOrder;
                    
                }
                else break;
            }
            
            if (orders.Count > 0)
            {
                Console.WriteLine($"Orders left: {string.Join(" ",orders.ToArray())}");
            }
            else Console.WriteLine("Orders complete");
        }
    }
}
