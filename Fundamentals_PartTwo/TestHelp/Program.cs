using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        int coolSum = 1;
        string text = Console.ReadLine();
        List<string> emojis = new List<string>();
        int emojisCount = 0;

        string pattern = @"([\:\*]{2})([A-Z]{1}[a-z]{2,})\1";

        foreach (char ch in text)
        {
            if (char.IsDigit(ch))
            {
                coolSum *= int.Parse(ch.ToString());
            }
        }

        MatchCollection result = Regex.Matches(text, pattern);
        foreach (Match match in result)
        {
            string emoji = match.Value;
            string emojiContent = match.Groups[2].Value;
            int charSum = 0;

            foreach (char currentChar in emojiContent)
            {
                charSum += (int)currentChar;
            }

            emojisCount++;

            if (charSum >= coolSum)
            {
                emojis.Add(emoji);
            }
        }

        Console.WriteLine($"Cool threshold: {coolSum}");
        Console.WriteLine($"{emojisCount} emojis found in the text. The cool ones are:");

        foreach (var item in emojis)
        {
            Console.WriteLine(item);
        }
    }
}