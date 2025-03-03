using System.Diagnostics;
using System.Text.RegularExpressions;

namespace ExamPreparation_DestinationMapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(\=(?<Equals>[A-Z][A-Za-z]{2,})\=)|(\/(?<Column>[A-Z][A-Za-z]{2,})\/)";
            string input = Console.ReadLine();
            List<string> destinationList = new List<string>();
            int travelPoints = 0;
            MatchCollection matches = Regex.Matches(input, pattern);
            foreach (Match match in matches)
            {

                if (match.Groups["Equals"].Success)
                {
                    destinationList.Add(match.Groups["Equals"].Value);
                    travelPoints += match.Groups["Equals"].Value.Length;
                }
                else if (match.Groups["Column"].Success)
                {
                    destinationList.Add(match.Groups["Column"].Value);
                    travelPoints += match.Groups["Column"].Value.Length;
                }
            }
            Console.WriteLine($"Destinations: {string.Join(", ", destinationList)}");
            Console.WriteLine($"Travel Points: {travelPoints}");
        }
    }
}
