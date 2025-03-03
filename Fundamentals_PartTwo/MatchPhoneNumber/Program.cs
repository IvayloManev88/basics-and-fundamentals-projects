using System.Text.RegularExpressions;

namespace MatchPhoneNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string matchCase = @"(^|\ )\+359([\ \-])2\2\d{3}\2\d{4}\b";
            string phoneNumbers = Console.ReadLine();
            MatchCollection matchedPhones = Regex.Matches(phoneNumbers,matchCase);
            List<string> matches = matchedPhones.Cast<Match>().Select(a=>a.Value.Trim()).ToList();
            Console.WriteLine(string.Join(", ",matches));
        }
    }
}
