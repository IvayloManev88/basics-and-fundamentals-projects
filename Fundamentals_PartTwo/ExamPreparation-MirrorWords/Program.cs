using System.Text.RegularExpressions;

namespace ExamPreparation_MirrorWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"([\@\#])(?<word>[A-Za-z]{3,})\1\1(?<Reverse>[A-Za-z]{3,})\1";
            string input = Console.ReadLine();
            int counter = 0;
            List<string> words = new List<string>();
            MatchCollection matches = Regex.Matches(input, pattern);
            if (matches.Count > 0)
            {
                Console.WriteLine($"{matches.Count} word pairs found!");
                foreach (Match match in matches)
                {
                    string word = match.Groups["word"].Value;
                    string reverse = match.Groups["Reverse"].Value;
                    string reverseReverse = new string(reverse.Reverse().ToArray());
                    if (word == reverseReverse)
                    {
                        string newString = word + " <=> " + reverse;
                        words.Add(newString);
                    }
                }
            }
            else Console.WriteLine($"No word pairs found!");
            if (words.Count > 0)
            {
                Console.WriteLine("The mirror words are:");
                Console.WriteLine(string.Join(", ", words));
            }
            else Console.WriteLine("No mirror words!");
        }
    }
}
