using System.Text.RegularExpressions;

namespace MatchFullName
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string regex = @"\b([A-Z][a-z]+)[ ]([A-Z][a-z]+)\b";
            string names = Console.ReadLine();
            MatchCollection matchNames = Regex.Matches(names, regex);
            foreach (Match name in matchNames)
            {
                Console.Write(name.Value+ " ");

            }
            
        }
    }
}
