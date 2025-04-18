namespace SimpleTextEditor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfCommands = int.Parse(Console.ReadLine());
            Stack<char> text = new Stack<char>();
            Stack<string> reverseOperations = new Stack<string>();
            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] commands = Console.ReadLine().Split();
                switch (commands[0])
                {
                    case "1":
                            char[] reversed = text.ToArray();
                            
                            string reversedString = new string(reversed);

                            reverseOperations.Push(reversedString);
                        
                        for (int j =0; j < commands[1].Length;j++)
                        {
                            text.Push(commands[1][j]);
                        }
                        break;
                    case "2":
                            reversed = text.ToArray();

                       
                        reversedString = new string( reversed);
                            reverseOperations.Push(reversedString);
                        
                        
                        int numberToErase = int.Parse(commands[1]);
                        for (int k = 0; k < numberToErase; k++)
                            text.Pop();
                        break;
                    case "3":
                        int index = int.Parse(commands[1]);
                        char[] output = text.ToArray();
                        output = output.Reverse().ToArray();
                        Console.WriteLine(output[index-1]);
                        break;
                    case "4":
                        string lastText = reverseOperations.Pop();
                        text.Clear();
                        if (lastText.Length > 0)
                        {
                            for (int m= lastText.Length-1; m >= 0; m--)
                            {
                                text.Push(lastText[m]);
                            }
                        }
                        
                        
                        break;
                }
            }
        }
    }
}
