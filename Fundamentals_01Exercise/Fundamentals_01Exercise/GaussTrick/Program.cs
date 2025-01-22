using System.Diagnostics.Metrics;
using System.Runtime.CompilerServices;

namespace GaussTrick
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            int counter = numbers.Count;
            for (int i = 0; i < counter/2; i++)
            {
                numbers[i] += numbers[numbers.Count - 1];
                numbers.RemoveAt(numbers.Count - 1);
            }
            Console.WriteLine(string.Join(" ", numbers));
            
        }
    }
}
