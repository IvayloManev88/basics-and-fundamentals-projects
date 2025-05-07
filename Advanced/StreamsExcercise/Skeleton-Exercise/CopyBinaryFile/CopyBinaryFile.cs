namespace CopyBinaryFile
{
    using System;
    using System.IO;

    public class CopyBinaryFile
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\copyMe.png";
            string outputFilePath = @"..\..\..\copyMe-copy.png";

            CopyFile(inputFilePath, outputFilePath);
        }

        public static void CopyFile(string inputFilePath, string outputFilePath)
        {
            using (FileStream reader = new(inputFilePath, FileMode.Open, FileAccess.Read))
            {
                using (FileStream writer = new (outputFilePath, FileMode.Create,FileAccess.Write))
                {
                    byte[] buffer = new byte[1024];
                    int readBytes=0;
                    while (readBytes < reader.Length)
                    {
                        int currentReadBytes = reader.Read(buffer, 0, (int)Math.Min(buffer.Length,reader.Length-readBytes));
                        readBytes+=currentReadBytes;
                        writer.Write(buffer, 0, currentReadBytes);
                    }
                }
            }

           //throw new NotImplementedException();
        }
    }
}
