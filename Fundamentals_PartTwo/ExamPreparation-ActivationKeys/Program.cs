using System.ComponentModel;
using System.Data.SqlTypes;
using System.Text;

namespace ExamPreparation_ActivationKeys
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string initialKey= Console.ReadLine();
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Generate")
            {
                string[] commands = command.Split(">>>");
                switch (commands[0])
                {
                    case "Contains":
                        if (initialKey.IndexOf(commands[1]) != -1)
                        {
                            Console.WriteLine($"{initialKey} contains {commands[1]}");

                        }
                        else Console.WriteLine("Substring not found!");
                        break;
                    case "Flip":
                        int startIndex = int.Parse(commands[2]);
                        int endIndex = int.Parse(commands[3]);
                        StringBuilder sb = new StringBuilder();
                        //here maybe if
                        sb.Append(initialKey,0,startIndex-0);
                        string helpString = initialKey.Substring(startIndex,endIndex-startIndex);

                        if (commands[1] == "Upper")
                        {
                            sb.Append(helpString.ToUpper());
                        }
                        else sb.Append(helpString.ToLower());

                        sb.Append(initialKey,endIndex,initialKey.Length-endIndex);
                           
                        Console.WriteLine(sb.ToString());
                        initialKey = sb.ToString();
                        break;
                    case "Slice":
                        int startIndexSlice = int.Parse(commands[1]);
                        int endIndexSlice = int.Parse(commands[2]);
                        initialKey =initialKey.Remove(startIndexSlice, endIndexSlice - startIndexSlice);
                        Console.WriteLine(initialKey);
                        break;
                }
            }
            Console.WriteLine($"Your activation key is: {initialKey}");
        }
    }
}
