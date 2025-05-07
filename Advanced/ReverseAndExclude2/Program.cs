namespace ReverseAndExclude2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int n = int.Parse(Console.ReadLine());

            List<int> output = ReverseNumbers(numbers, x=>x%n!=0);
            Console.WriteLine(String.Join(" ",output));

        }
        static List<int> ReverseNumbers(int[] numbers, Predicate<int> condition)
        {
            List<int> result = new List<int>();
            for (int i = numbers.Length - 1; i >= 0; i--)
            {
                if (condition(numbers[i])) result.Add(numbers[i]);
            }
            return result;
        }
    }
}
