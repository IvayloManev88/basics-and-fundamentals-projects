using System.Text.RegularExpressions;

namespace MatchDates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string matchCase = @"\b(?<Day>\d{2})(\/|\.|\-)(?<Month>[A-Z][a-z]{2})\1(?<Year>\d{4})\b";
            string input = Console.ReadLine();
            MatchCollection matches = Regex.Matches(input, matchCase);
            foreach (Match date in matches)
            {
                
                Console.WriteLine($"Day: {date.Groups["Day"].Value}, Month: {date.Groups["Month"].Value}, Year: {date.Groups["Year"].Value}");
                
            }
        }
    }
}
