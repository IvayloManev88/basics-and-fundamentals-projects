using System.Numerics;
using System.Text.RegularExpressions;

namespace ExamPreparation_EmojiDetector
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"([\:\*])\1[A-Z][a-z]{2,}\1\1";
            string patternNumbers = @"[0-9]";
            string input = Console.ReadLine();
            BigInteger cool = 1;
            MatchCollection numbers = Regex.Matches(input, patternNumbers);
            foreach (Match match in numbers)
            {
                cool*= int.Parse(match.Value);
            }
            Console.WriteLine($"Cool threshold: {cool}");
            MatchCollection emojis = Regex.Matches(input, pattern);
            Console.WriteLine($"{emojis.Count()} emojis found in the text. The cool ones are:");
            foreach (Match match in emojis)
            {
                string emoji = match.Value.Substring(2, match.Value.Length - 4);
                BigInteger emojisNumber = 0;
                foreach (char c in emoji)
                {
                    emojisNumber += (int)c;
                }
                if (emojisNumber >= cool)
                    Console.WriteLine(match.Value);
            }

        }
    }
}
