namespace SplitMergeBinaryFile
{
    using System;
    using System.IO;
    using System.Linq;

    public class SplitMergeBinaryFile
    {
        static void Main()
        {
            string sourceFilePath = @"..\..\..\Files\example.png";
            string joinedFilePath = @"..\..\..\Files\example-joined.png";
            string partOnePath = @"..\..\..\Files\part-1.bin";
            string partTwoPath = @"..\..\..\Files\part-2.bin";

            SplitBinaryFile(sourceFilePath, partOnePath, partTwoPath);
            MergeBinaryFiles(partOnePath, partTwoPath, joinedFilePath);
        }

        public static void SplitBinaryFile(string sourceFilePath, string partOneFilePath, string partTwoFilePath)
        {
            using (FileStream reader = new(sourceFilePath, FileMode.Open, FileAccess.Read))
            {
                int sizeSecondPart = (int)(reader.Length / 2);
                int sizeFirstPart = (int)(reader.Length- sizeSecondPart);
                
                using (FileStream writerInFirstFile = new(partOneFilePath, FileMode.Create, FileAccess.Write))
                {

                    byte[] buffer = new byte[1024];
                    int totalReadBytes = 0;
                    while (totalReadBytes <sizeFirstPart)

                    {
                        int readBytes = reader.Read(buffer,0,Math.Min(buffer.Length,sizeFirstPart-totalReadBytes));
                        
                       writerInFirstFile.Write(buffer,0,readBytes);

                        totalReadBytes += readBytes;
                    }
                }
                    using (FileStream writerInSecondFile = new(partTwoFilePath, FileMode.Create, FileAccess.Write))
                    {
                    byte[] buffer = new byte[1024];
                    int totalReadBytes = 0;
                    
                    while (totalReadBytes < sizeSecondPart)

                        {
                        int readBytes = reader.Read(buffer, 0, Math.Min(buffer.Length, sizeSecondPart - totalReadBytes));

                        writerInSecondFile.Write(buffer, 0, readBytes);

                        totalReadBytes += readBytes;
                    }
                }
                
            }
        }

        public static void MergeBinaryFiles(string partOneFilePath, string partTwoFilePath, string joinedFilePath)
        {
            using (FileStream writer = new FileStream(joinedFilePath, FileMode.Create, FileAccess.Write))
            {
                
                using (FileStream readerFileOne = new(partOneFilePath, FileMode.Open, FileAccess.Read))
                {
                    
                    byte[] buffer = new byte[1024];
                    int readBytes; 
                    while ((readBytes = readerFileOne.Read(buffer))!=0)
                    {
                        writer.Write(buffer, 0, readBytes);
                    }
                        
                }
                using (FileStream readerFileTwo = new(partTwoFilePath, FileMode.Open, FileAccess.Read))
                {
                    byte[] buffer = new byte[1024];
                    int readBytes;
                    while ((readBytes = readerFileTwo.Read(buffer)) != 0)
                    {
                        writer.Write(buffer, 0, readBytes);
                    }
                }
            }
        }
    }
}