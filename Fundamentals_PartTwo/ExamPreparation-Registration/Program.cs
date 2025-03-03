using System.Runtime.CompilerServices;
using System.Text;

namespace ExamPreparation_Registration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputName = Console.ReadLine();
            StringBuilder userName = new();
            string command = string.Empty;
            while ((command=Console.ReadLine())!= "Registration")
            {
                string[] commands = command.Split(" ");
                switch (commands[0])
                {
                    case "Letters":
                        if (commands[1]== "Lower")
                        {
                            inputName = inputName.ToLower();
                            
                        }
                        else if (commands[1] == "Upper")
                        {
                            inputName = inputName.ToUpper();
                        }
                        Console.WriteLine(inputName);
                        break;

                    case "Reverse":
                        int startIndex = int.Parse(commands[1]);
                        int endIndex = int.Parse(commands[2]);
                        
                        
                        

                            if (isIndexCorrect(startIndex, endIndex, inputName))
                            {
                                StringBuilder reverseValue = new();
                                reverseValue.Append(inputName, startIndex, endIndex-startIndex+1);
                                char[] reverse = reverseValue.ToString().ToArray();
                                reverse=reverse.Reverse().ToArray();
                                

                                Console.WriteLine(string.Join("", reverse));
                            }
                        
                        break;

                    case "Substring":
                        StringBuilder substring= new StringBuilder();
                        substring.Append(inputName);
                        substring.Replace(commands[1], "");
                        if (inputName.Length == substring.Length)
                        {
                            Console.WriteLine($"The username {inputName} doesn't contain {commands[1]}.");
                        }
                        else
                        {
                            inputName = substring.ToString();
                            Console.WriteLine(inputName );
                        }
                        break;
                    case "Replace":
                        StringBuilder replace = new StringBuilder();
                        replace.Append(inputName);
                        replace.Replace(commands[1], "-");
                        inputName = replace.ToString();
                        Console.WriteLine(inputName);

                        break;

                    case "IsValid":
                        if (inputName.Contains(commands[1]))
                        {
                            Console.WriteLine("Valid username.");
                        }
                        else Console.WriteLine($"{commands[1]} must be contained in your username.");
                        break;





                }
                
            }
        }
        public static bool isIndexCorrect(int startIndex, int endIndex, string userName)
        {
            bool isIndexCorrect = false;
            if (startIndex>=0 &&endIndex>=0 &&startIndex<userName.Length&& endIndex<userName.Length) isIndexCorrect = true;
            
            return isIndexCorrect;
        }
    }
}
