namespace FolderSize
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    public class FolderSize
    {
        static void Main(string[] args)
        {
            string folderPath = @"..\..\..\Files\TestFolder";
            string outputPath = @"..\..\..\Files\output.txt";

            GetFolderSize(folderPath, outputPath);
        }

        public static void GetFolderSize(string folderPath, string outputFilePath)
        {
            Queue<string> paths = new Queue<string>();
            paths.Enqueue(folderPath);
            decimal totalSize = 0;
            while (paths.Count > 0)
            {
                string path = paths.Dequeue();
                string [] filePaths = Directory.GetFiles(path);
                foreach ( string file in filePaths )
                {
                    FileInfo size = new FileInfo(file);
                    totalSize += size.Length;
                }
                string [] newFolders = Directory.GetDirectories(path);
                foreach ( string newFolder in newFolders )
                    paths.Enqueue(newFolder);
            }
            /*
            using (StreamWriter writer = new(outputFilePath))
            {
                writer.Write($"{totalSize / 1024m} KB");
            }
            */
            File.WriteAllText(outputFilePath, $"{totalSize / 1024m} KB");
        }
    }
}
