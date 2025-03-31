using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace SantaSecretHelper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            string input = string.Empty;
            string pattern = @"\@(?<Name>[A-Za-z]+)[^\@\!\-\:\>]*\!(?<GN>[GN])\!";

            while ((input=Console.ReadLine())!= "end")
            {
                char[] inputs = input.ToArray();
                for (int i = 0; i < inputs.Length; i++)
                {
                    inputs[i] = (char)(inputs[i] - key);
                }
                
                input = new string(inputs);
                
                MatchCollection matches = Regex.Matches(input, pattern);
                foreach (Match match in matches)
                {
                    if (match.Groups["GN"].Value == "G") Console.WriteLine(match.Groups["Name"].Value);
                }
            }
        }
    }
}
