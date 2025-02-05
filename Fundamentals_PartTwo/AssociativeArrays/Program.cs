namespace AssociativeArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<int, int> sortedNumbers = new();
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            foreach (int i in input)
            {
                if (!sortedNumbers.ContainsKey(i))
                {
                    sortedNumbers.Add(i, 0);
                }
                sortedNumbers[i]++;
            }
            foreach ((int key, int value) in sortedNumbers)
            {
                Console.WriteLine($"{key} -> {value}");
            }
        }
    }
}
