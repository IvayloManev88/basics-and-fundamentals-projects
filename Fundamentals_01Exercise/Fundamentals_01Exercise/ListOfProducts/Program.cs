using System.Security.Authentication;

namespace ListOfProducts
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfProducts = int.Parse(Console.ReadLine());
            List<string> products = new();
            for (int i=0; i<numberOfProducts;i++)
            {
                products.Add(Console.ReadLine());
            }
            products.Sort();
            for (int i=1; i<=numberOfProducts;i++)
            {
                Console.WriteLine($"{i}.{products[i-1]}");
            }
          
        }
    }
}
