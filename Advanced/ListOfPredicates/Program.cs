using System.Diagnostics;

namespace ListOfPredicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Func<int, bool>[] conditions = new Func<int, bool>[numbers.Length];
            for (int i = 0; i < numbers.Length; i++)
            {
                int currentNumber = i;
                conditions[currentNumber] = x => x % numbers[currentNumber] == 0;
            }
            
            List<int> output = Filter(1, n, conditions);
            Console.WriteLine(string.Join(" ", output));
        }

        static List<int> Filter(int start, int end, Func<int, bool>[] conditions)
        {
            List<int> result = new List<int>();

            for (int i = start; i <= end; i++)
            {
                bool isDividable = true;
                foreach (var condition in conditions)
                {
                    if (condition(i) == false)
                    {
                        isDividable = false;
                        break;
                    }
                }
                if (isDividable)
                {
                    result.Add(i);
                }
            }

            return result;
        }
    }
}
