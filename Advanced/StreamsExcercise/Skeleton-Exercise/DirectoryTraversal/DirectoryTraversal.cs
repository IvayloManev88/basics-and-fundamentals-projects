namespace DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class DirectoryTraversal
    {
        static void Main()
        {
            string path = Console.ReadLine();
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            StringBuilder sb = new StringBuilder();
            string[] fileNames = Directory.GetFiles(inputFolderPath);
            Dictionary<string, Dictionary<string, decimal>> extentions = new();
            foreach (string fileName in fileNames)
            {
                int dotIndex = fileName.LastIndexOf('.');
                string currentExtention = fileName.Substring(dotIndex);
                if (!extentions.ContainsKey(currentExtention))
                {
                    extentions[currentExtention] = new Dictionary<string, decimal>();
                }

                string currentFileName = fileName.Substring(fileName.LastIndexOf("\\")+1);
                decimal currentFileSize = 0;
                FileInfo size = new(fileName);
                currentFileSize = size.Length/1024m;
                extentions[currentExtention].Add(currentFileName, currentFileSize);

            }
            extentions=extentions.OrderByDescending(x=>x.Value.Count()).ThenBy(x=>x.Key).ToDictionary(x=>x.Key,x=>x.Value);
            foreach ((string extention, Dictionary<string, decimal> fileInformation) in extentions)
            {
                sb.AppendLine(extention);
                Dictionary<string, decimal> ordered = fileInformation.OrderBy(x=>x.Value).ToDictionary(x => x.Key, x => x.Value);
                foreach ((string filename, decimal size) in ordered)
                {
                    sb.AppendLine($"--{filename} - {size}kb");
                }
            }
            return sb.ToString();
            



            //throw new NotImplementedException();
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            File.WriteAllText(reportFileName, textContent);
            //throw new NotImplementedException();
        }
    }
}
