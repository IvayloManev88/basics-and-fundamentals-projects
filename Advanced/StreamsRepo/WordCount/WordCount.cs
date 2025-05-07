namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            Dictionary<string,int> words = new ();
            char[] chars = new char[] {' ', '-', '!', '\n', '\r', '…', '.', ',','?', };
            using (StreamReader wordsReader = new StreamReader(wordsFilePath))
            {
                string[] input = wordsReader.ReadToEnd().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => x.ToLower()).ToArray();
                foreach (string word in input)
                {
                    words.Add(word,0);
                }
            }
            using (StreamReader textReader = new StreamReader(textFilePath))
            {
                string[] inputLine = textReader.ReadToEnd().Split(chars, StringSplitOptions.RemoveEmptyEntries).Select(x=>x.ToLower()).ToArray();
                
                             
                    foreach (string word in inputLine)
                    {
                    if (words.ContainsKey(word)) words[word]++;
                    }
                     
                

            }
            
            using (StreamWriter writer = new(outputFilePath))
            {
                foreach ((string word,int  occurance) in words.OrderByDescending(x => x.Value))
                {
                    writer.WriteLine($"{word} - {occurance}");
                }
            }
            //hop

        }
    }
}
