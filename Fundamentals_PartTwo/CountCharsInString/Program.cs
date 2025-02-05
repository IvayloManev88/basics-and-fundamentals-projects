namespace CountCharsInString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, int> charCounter = new();
           char[] chars = Console.ReadLine().Where(c => !char.IsWhiteSpace(c)).ToArray();
            foreach (char c in chars)
            {
                if (charCounter.ContainsKey(c))
                {
                    charCounter[c]++;
                }
                else charCounter.Add(c, 1);
            }
            foreach ((char outputChar, int outputInt) in charCounter)
            {
                Console.WriteLine($"{outputChar} -> {outputInt}");
            }
        }
    }
}
