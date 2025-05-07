namespace ExtractSpecialBytes
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    public class ExtractSpecialBytes
    {
        static void Main()
        {
            string binaryFilePath = @"..\..\..\Files\example.png";
            string bytesFilePath = @"..\..\..\Files\bytes.txt";
            string outputPath = @"..\..\..\Files\output.bin";

            ExtractBytesFromBinaryFile(binaryFilePath, bytesFilePath, outputPath);
        }

        public static void ExtractBytesFromBinaryFile(string binaryFilePath, string bytesFilePath, string outputPath)
        {
            using (FileStream fsReader = new(binaryFilePath, FileMode.Open, FileAccess.Read))
            {
                HashSet<byte> bytes = new();
                using (StreamReader bytesRead = new StreamReader(bytesFilePath))
                {
                   
                    while (!bytesRead.EndOfStream)
                    {
                        bytes.Add(byte.Parse(bytesRead.ReadLine()));
                    }
                }
                using (FileStream fsWriter = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                {
                    byte[] buffer = new byte[1024];
                    int readBytes;
                    while ((readBytes = fsReader.Read(buffer)) != 0)
                    {
                        int specialBytesCount = 0;
                        for (int i = 0; i < readBytes; i++)
                        {
                            if (bytes.Contains(buffer[i]))
                            {
                                buffer[specialBytesCount] = buffer[i];
                                specialBytesCount++;
                            }
                        }
                        fsWriter.Write(buffer, 0, specialBytesCount);
                    }
                    
                }
            }   
        }
    }
}
