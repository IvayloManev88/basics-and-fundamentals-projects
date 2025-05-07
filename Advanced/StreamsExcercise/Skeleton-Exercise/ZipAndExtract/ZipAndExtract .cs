namespace ZipAndExtract
{
    using System;
    using System.IO;
    using System.IO.Compression;

    public class ZipAndExtract
    {
        static void Main()
        {
            string inputFile = @"..\..\..\copyMe.png";
            string zipArchiveFile = @"..\..\..\archive.zip";
            string extractedFile = @"..\..\..\extracted.png";

            ZipFileToArchive(inputFile, zipArchiveFile);

            var fileNameOnly = Path.GetFileName(inputFile);
            ExtractFileFromArchive(zipArchiveFile, fileNameOnly, extractedFile);
        }

        public static void ZipFileToArchive(string inputFilePath, string zipArchiveFilePath)
        {
            //throw new NotImplementedException();
            string tempFolder = Path.Combine(Path.GetTempPath(),"ZipFolder");
            if (Directory.Exists(tempFolder))
            {
                Directory.Delete(tempFolder, true);
            }
            Directory.CreateDirectory(tempFolder);
            
            File.Copy(inputFilePath, Path.Combine(tempFolder , Path.GetFileName(inputFilePath)));
            if (File.Exists(zipArchiveFilePath))
            {
                File.Delete(zipArchiveFilePath);
            }
            ZipFile.CreateFromDirectory(tempFolder, zipArchiveFilePath);
            Directory.Delete(tempFolder, true);

        }

        public static void ExtractFileFromArchive(string zipArchiveFilePath, string fileName, string outputFilePath)
        {
            //throw new NotImplementedException();
            string tempFolder = Path.Combine(Path.GetTempPath(), "ZipFolder");
            ZipFile.ExtractToDirectory(zipArchiveFilePath, tempFolder);
            string extractedFile = Path.Combine(tempFolder, fileName);
            if (File.Exists(outputFilePath))
            {
                File.Delete(outputFilePath);
            }
            File.Copy (extractedFile, outputFilePath);
            Directory.Delete (tempFolder, true);

        }
    }
}
