namespace CountSymbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<char, int> sorted = new();
            string input = Console.ReadLine();
            for (int i = 0; i<input.Length; i++)
            {
                char currentChar = input[i];
                if (!sorted.ContainsKey(currentChar))
                {
                    sorted.Add(currentChar, 0);
                }
                sorted[currentChar]++;
            }
            foreach ((char c, int n) in sorted)
            {
                Console.WriteLine($"{c}: {n} time/s");
            }
        }
    }
}
