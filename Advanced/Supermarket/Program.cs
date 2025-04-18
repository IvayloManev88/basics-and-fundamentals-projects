namespace Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            Queue<string> customers = new Queue<string>();
            while ((input = Console.ReadLine()) != "End")
            {
                if (input== "Paid")
                { 
                    Console.WriteLine(string.Join("\n",customers.ToArray()));
                    customers.Clear();
                }
                else customers.Enqueue(input);
            }
            Console.WriteLine($"{customers.Count} people remaining.");
        }
    }
}
