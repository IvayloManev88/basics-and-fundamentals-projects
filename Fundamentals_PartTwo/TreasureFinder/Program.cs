using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

namespace TreasureFinder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] key = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            string input = string.Empty;
            StringBuilder message = new StringBuilder();
            string itemPattern = @"(\&)(?<Item>[A-Za-z]+)\1";
            string coordinatesPattern = @"<(?<Coordinates>.*)>";
            while ((input = Console.ReadLine()) != "find")
            {
                int keyIndex = 0;
                for (int i = 0; i<input.Length; i++)
                {
                    char c = input[i];
                    message.Append((char)(c-key[keyIndex]));
                    if (keyIndex == key.Length - 1) keyIndex = 0;
                    else keyIndex++;

                }
                input = message.ToString();
                message.Clear();
                string itemName = string.Empty;
                foreach (Match match in Regex.Matches(input, itemPattern))
                {
                    itemName = match.Groups["Item"].Value;
                }
                string coordinates = string.Empty;
                foreach (Match match in Regex.Matches(input, coordinatesPattern))
                {
                    coordinates = match.Groups["Coordinates"].Value;
                }
                Console.WriteLine($"Found {itemName} at {coordinates}");

            }
        }
    }
}
