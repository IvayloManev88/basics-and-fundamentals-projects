using System.Text.RegularExpressions;

namespace AaExamSecondTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfPasswords = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfPasswords; i++)
            {
                string password = Console.ReadLine();
                string pattern = @"([^\>]+)\>(?<Digits>[0-9]{3})\|(?<lower>[a-z]{3})\|(?<upper>[A-Z]{3})\|(?<symbols>[^\>\<]{3})\<\1";
                MatchCollection passwordMatches = Regex.Matches(password,pattern);
                if (passwordMatches.Count == 0)
                {
                    Console.WriteLine($"Try another password!");
                }
                else
                {
                    foreach (Match match in passwordMatches)
                    {
                        string realPassword = match.Groups["Digits"].Value + match.Groups["lower"].Value + match.Groups["upper"].Value + match.Groups["symbols"].Value;
                        Console.WriteLine($"Password: {realPassword}");
                    }
                }
            }
        }
    }
}
