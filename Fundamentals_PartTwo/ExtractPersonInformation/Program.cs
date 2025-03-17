using System.Text.RegularExpressions;

namespace ExtractPersonInformation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());
            string patternName = @"\@(?<Name>[A-Za-z]+)\|";
            string patternAge = @"\#(?<Age>\d+)\*";
            for (int i = 0; i < numberOfLines; i++)
            {
                string line = Console.ReadLine();
                string name = string.Empty;
                int age = 0;
                MatchCollection Names = Regex.Matches(line, patternName);
                foreach (Match match in Names)
                {
                    name = match.Groups["Name"].Value;
                }
                MatchCollection Ages = Regex.Matches(line, patternAge);
                foreach (Match match in Ages)
                {
                    age = int.Parse(match.Groups["Age"].Value);
                }
                Console.WriteLine($"{name} is {age} years old.");
            }
        }
    }
}
