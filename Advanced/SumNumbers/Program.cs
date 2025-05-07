using System.Security.Cryptography.X509Certificates;

namespace SumNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string, int> parser = Parcer;
            int[] ints = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(parser)
                .ToArray();
            Func<int[], int> counter = Counter;
            Func<int[], int> sum = Sum;
            Console.WriteLine(counter(ints));
            Console.WriteLine(sum(ints));
            
        }
        public static int Counter(int[] ints)
            {
                int result = ints.Count();
                
                return result;
            }
        public static int Sum(int[] ints)
        {
            return ints.Sum();
        }
        public static int Parcer(string s)
        {
            return int.Parse(s);
        }
}
}
 