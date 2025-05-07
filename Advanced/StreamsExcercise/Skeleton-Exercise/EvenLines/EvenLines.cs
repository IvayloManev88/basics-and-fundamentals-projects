namespace EvenLines
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            int row = 0;
            StringBuilder sb = new StringBuilder();
            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (row % 2 == 0)
                    {

                        char[] chars = new char[] { '-', ',', '.', '!', '?' };
                        foreach (char c in chars)
                        {
                            if (line.Contains(c)) line = line.Replace(c, '@');
                        }
                        string[] words = line.Split(" ").ToArray();
                        for (int i = words.Length-1; i >= 0; i--) sb.Append(words[i]+" ");
                        sb.AppendLine();
                        
                    }
                    row++;
                }
                
            }
            return sb.ToString();
            //throw new NotImplementedException();
        }
    }
}
