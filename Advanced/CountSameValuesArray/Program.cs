namespace CountSameValuesArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<decimal, int> sameValueDictionary = new();
            decimal[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(decimal.Parse).ToArray();
            foreach (decimal value in input)
            {
                if (!sameValueDictionary.ContainsKey(value))
                {
                    sameValueDictionary.Add(value, 0);
                }
                sameValueDictionary[value]++;
            }
            foreach ( (decimal key, int value) in sameValueDictionary)
            {
                Console.WriteLine($"{key} - {value} times");
                    //-2.5 - 3 times
            }
        }
    }
}
