namespace Rounding
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<double> numbers = Console.ReadLine().Split().Select(double.Parse).ToList();
            for (int i = 0; i < numbers.Count; i++)
            {
                
                numbers[i] = Math.Round(numbers[i]);
            }
            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
