using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace OddOccurrences
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> occurances = new();
            string[] inputs = Console.ReadLine().Split().ToArray();
            foreach (string input in inputs)
            {
                string lowerCaseCurrentItem = input.ToLower();
                if (occurances.ContainsKey(lowerCaseCurrentItem))
                {
                    occurances[lowerCaseCurrentItem]++;
                }
                else
                {
                    occurances.Add(lowerCaseCurrentItem, 1);
                }
            }
            Console.WriteLine(string.Join(" ", occurances.Where(dictionary => dictionary.Value % 2!=0).Select(dictionary=>dictionary.Key)));
        }
    }
}
