using System.Net.WebSockets;

namespace SumOfIntegers
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ");
            int sum = 0;
            for (int i = 0; i < input.Length; i++)
            {
                try
                {
                    int number = int.Parse(input[i]);
                    sum+= number;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"The element '{input[i]}' is in wrong format!");
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine($"The element '{input[i]}' is out of range!");
                }
                finally
                {
                    Console.WriteLine($"Element '{input[i]}' processed - current sum: {sum}");
                }
            }


            Console.WriteLine($"The total sum of all integers is: {sum}");
        }
    }
}
