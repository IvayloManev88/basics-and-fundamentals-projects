namespace AaExamFirstTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputCommand = Console.ReadLine();
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Finish")
            {
                string[] commands = command.Split(" ",StringSplitOptions.RemoveEmptyEntries);
                switch (commands[0])
                {
                    case "Replace":
                        inputCommand = inputCommand.Replace(commands[1], commands[2]);
                        Console.WriteLine(inputCommand);
                        break;
                    case "Make":
                        if (commands[1] == "Lower") inputCommand =inputCommand.ToLower();
                        else if (commands[1] == "Upper") inputCommand = inputCommand.ToUpper();
                        Console.WriteLine(inputCommand);
                        break;
                    case "Check":
                        if (inputCommand.Contains(commands[1])) Console.WriteLine($"Message contains {commands[1]}");
                        else Console.WriteLine($"Message doesn't contain {commands[1]}");
                        
                        break;
                    case "Sum":
                        int startIndex = int.Parse(commands[1]);
                        int endIndex = int.Parse(commands[2]);
                        if (startIndex >= 0 && endIndex >= 0 && startIndex < inputCommand.Length && endIndex < inputCommand.Length)
                        {
                            string subString = inputCommand.Substring(startIndex, endIndex - startIndex + 1);
                            int sum = 0;
                            for (int i = 0; i < subString.Length; i++)
                            {
                                sum += (int)subString[i];
                            }
                            Console.WriteLine(sum);
                        }
                        else Console.WriteLine("Invalid indices!");
                        break;
                    case "Cut":
                         startIndex = int.Parse(commands[1]);
                         endIndex = int.Parse(commands[2]);
                        if (startIndex >= 0 && endIndex >= 0 && startIndex < inputCommand.Length && endIndex < inputCommand.Length)
                        {
                            string initialPart = inputCommand.Substring(0, startIndex);
                            string endPart=string.Empty;
                            if (endIndex+1<inputCommand.Length)  endPart = inputCommand.Substring(endIndex + 1);
                             inputCommand = initialPart + endPart;
                            Console.WriteLine(inputCommand);
                        }
                        else Console.WriteLine("Invalid indices!");
                        break;

                }

                    
            }

        }
    }
}
