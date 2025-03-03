using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> racers = new Dictionary<string, int>();
            string[] inputs = Console.ReadLine().Split(", ");
            foreach (string inp in inputs)
            {
                racers.Add(inp, 0);
            }
            string input = string.Empty;
            while ((input=Console.ReadLine())!= "end of race")
            {
                string patternName = @"[A-Za-z]";
                string patternNumber = @"[0-9]";
                StringBuilder currentName = new StringBuilder();
                foreach (Match name in Regex.Matches(input, patternName))
                {
                    
                    currentName.Append(name.Value);
                }
                int currentDistance = 0;
                foreach (Match distance in Regex.Matches(input, patternNumber))
                {
                    currentDistance += int.Parse(distance.Value);
                }
                if (racers.ContainsKey(currentName.ToString()))
                {
                    racers[currentName.ToString()] += currentDistance;
                }
            }
            List<string> orderedRacers = racers.OrderByDescending(x => x.Value).Select(x=>x.Key).ToList();
            Console.WriteLine($"1st place: {orderedRacers[0]}");
            Console.WriteLine($"2nd place: {orderedRacers[1]}");
            Console.WriteLine($"3rd place: {orderedRacers[2]}");


        }
    }
}
