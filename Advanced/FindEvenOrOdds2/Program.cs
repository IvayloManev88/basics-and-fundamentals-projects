namespace FindEvenOrOdds2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Predicate<int>> predicatesCommands = new Dictionary<string, Predicate<int>>()
            {
                ["even"] = number => number % 2 == 0,
                ["odd"] = number => number % 2 != 0

            };
            int[] range = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int start = range[0], end = range[1];
            string type = Console.ReadLine();
            Predicate<int> condition;
            if (predicatesCommands.ContainsKey(type))
            {
                condition = predicatesCommands[type];
            }
            else
            {
                condition = _ => false;
            }
            List <int> result= Filter(start, end, condition);
            Console.WriteLine(string.Join(" ", result));


        }
        static List<int> Filter(int start, int end, Predicate<int> condition)
        {
            List<int> result = new List<int>();
            for (int i = start; i <= end; i++)
            {
                if (condition(i)) result.Add(i);
            }
            return result;
        }
    }
}
