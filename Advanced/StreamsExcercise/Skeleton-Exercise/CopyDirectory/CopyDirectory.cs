namespace CopyDirectory
{
    using System;
    using System.IO;

    public class CopyDirectory
    {
        static void Main()
        {
            string inputPath =  @$"{Console.ReadLine()}";
            string outputPath = @$"{Console.ReadLine()}";

            CopyAllFiles(inputPath, outputPath);
        }

        public static void CopyAllFiles(string inputPath, string outputPath)
        {   
            string[] fileNames = Directory.GetFiles(inputPath);
            if (Directory.Exists(outputPath))
            {
                Directory.Delete(outputPath,true);
            }
            Directory.CreateDirectory(outputPath);
            foreach (string fileName in fileNames)

            {

                string newFileName = fileName.Substring(fileName.LastIndexOf('\\')+1);
                File.Copy(fileName, outputPath + "\\" + newFileName); 
            }

            //throw new NotImplementedException();
        }
    }
}
