namespace FindEvensOrOdds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int min = input[0];
            int max = input[1];
            string command = Console.ReadLine();
            Predicate<int> printNumber = null;
            if (command == "odd")
            {
                printNumber = x => x % 2 != 0;
            }
            else if (command == "even")
            {
                printNumber = x => x % 2 == 0;
            }
            for (int i = min; i <= max; i++)
            {
                if (printNumber(i))
                    Console.Write(i+" ");
            }

        }
    }
}
