namespace LineNumbers
{
    using System;
    using System.IO;
    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            int lineCounter = 0;
            string[] lines = File.ReadAllLines(inputFilePath);
            for (int j = 0; j < lines.Length; j++)
            {
                string line = lines[j]; 
                lineCounter++;
                int letterCounter = 0;
                int symbolCounter = 0;
                for (int i = 0; i < line.Length; i++)
                {

                    if (char.IsLetter(line[i])) letterCounter++;
                    else if (char.IsPunctuation(line[i])) symbolCounter++;
                }
                lines[j] = $"Line {lineCounter}: {line} ({letterCounter})({symbolCounter})";
            }
            File.WriteAllLines(outputFilePath, lines);

           // throw new NotImplementedException();
        }
    }
}
