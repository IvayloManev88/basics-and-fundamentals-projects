namespace OddLines
{
    using System.IO;
	
    public class OddLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\Files\input.txt";
            string outputFilePath = @"..\..\..\Files\output.txt";

            ExtractOddLines(inputFilePath, outputFilePath);
        }

        public static void ExtractOddLines(string inputFilePath, string outputFilePath)
        {
            StreamReader reader = new StreamReader(inputFilePath);
            {
                int rowNumber = 0;
                StreamWriter writer = new StreamWriter(outputFilePath);
                {
                    using (reader)
                    {
                        using (writer)
                        {
                            string line = reader.ReadLine();
                            while (!reader.EndOfStream)
                            {
                                if (rowNumber % 2 != 0) writer.WriteLine(line);


                                rowNumber++;
                                line = reader.ReadLine();
                            }
                        }
                    }
                }
            }
        }
    }
}
