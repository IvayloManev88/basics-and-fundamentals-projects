
using System;
using System.Linq;
using System.Numerics;


namespace ArrayManipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            string command = "";
            int numbersLength = numbers.Length;
            while ((command=Console.ReadLine())!="end")
            {
                string[] commands = command
                    .Split();
                  
                if (commands[0]== "exchange")
                {

                   if (IsInvalidIndex(int.Parse(commands[1]),numbersLength-1))
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }

                    numbers = ExchangeMethod(numbers, int.Parse(commands[1]));
                                        
                }
                if (commands[0] == "max")
                {
                    MaxMethod(commands[1], numbers);
                }
                if (commands[0] == "min")
                {
                    MinMethod(commands[1], numbers);
                }
                if (commands[0] == "first")
                {
                    if (int.Parse(commands[1]) > numbersLength)
                    {
                        Console.WriteLine("Invalid count");
                        continue;
                    }
                    MethodPrintFirstNumbers(int.Parse(commands[1]), commands[2], numbers);
                    
                }
                if (commands[0] == "last")
                {
                    if (int.Parse(commands[1]) > numbersLength)
                    {
                        Console.WriteLine("Invalid count");
                        continue;
                    }
                    MethodPrintLastNumbers(int.Parse(commands[1]), commands[2], numbers);

                }

            }
            Console.WriteLine($"[{string.Join(", ", numbers)}]");
        }

        

        static bool IsInvalidIndex(int index,int length)
        {
           bool isInvalid = true;
            if (index>=0 && index<=length) isInvalid = false;
            return isInvalid;
        }

        static int[] ExchangeMethod(int[] numbers, int index)
        {
            int[] newArray = new int[numbers.Length];
            int newArrayIndex = 0;
            for (int i=index+1; i< numbers.Length;i++)
            {
                newArray[newArrayIndex] = numbers[i];
                newArrayIndex++;
            }
            for (int i=0;i<=index;i++)
            {
                newArray[newArrayIndex] = numbers[i];
                newArrayIndex++;
            }
            return newArray;
        }

        static void MaxMethod(string type, int[] numbers)
        {
            int maxNumber = int.MinValue;
            int index = -1;
            if (type == "even")
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (numbers[i] % 2 == 0 && maxNumber <= numbers[i])
                    {
                        maxNumber = numbers[i];
                        index = i;
                    }
                }
                if (index == -1) Console.WriteLine("No matches");
                else Console.WriteLine(index);
            }
            if (type == "odd")
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (numbers[i] % 2 != 0 && maxNumber <= numbers[i])
                    {
                        maxNumber = numbers[i];
                        index = i;
                    }
                }
                if (index == -1) Console.WriteLine("No matches");
                else Console.WriteLine(index);
            }
            
        }
        static void MinMethod(string type, int[] numbers)
        {
            int minNumber = int.MaxValue;
            int index = -1;
            if (type == "odd")
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (numbers[i] % 2 != 0 && minNumber >= numbers[i])
                    {
                            minNumber = numbers[i];
                            index = i;
                    }
                }

            }
                if (type == "even")
                {
                    for (int i = 0; i < numbers.Length; i++)
                    {
                        if (numbers[i] % 2 == 0 && minNumber >= numbers[i])
                        {
                            minNumber = numbers[i];
                            index = i;
                        }
                    }

                }       
                if (index == -1) Console.WriteLine("No matches");
            else Console.WriteLine(index);
            
        }
        static void MethodPrintFirstNumbers(int count, string type, int [] numbers)
        {
            string outputString = "";
            for (int i=0; i<numbers.Length;i++)
            {
                if (type=="even" && numbers[i]%2==0&&count>0)
                {
                    count--;
                    outputString += numbers[i] + ", ";
                    
                }
                if (type == "odd" && numbers[i] % 2 != 0 && count > 0)
                {
                    count--;
                    outputString += numbers[i] + ", ";

                }
            }
           
            Console.WriteLine($"[{outputString.Trim(' ', ',')}]");
        }


        static void MethodPrintLastNumbers(int count, string type, int[] numbers)
        {
            string outputString = "";
            for (int i = numbers.Length-1; i >= 0; i--)
            {
                if (type == "even" && numbers[i] % 2 == 0 && count > 0)
                {
                    count--;
                    outputString = $"{ numbers[i]}, " + outputString;

                }
                if (type == "odd" && numbers[i] % 2 != 0 && count > 0)
                {
                    count--;
                    outputString = $"{numbers[i]}, " + outputString;

                }
            }

            Console.WriteLine($"[{outputString.Trim(' ', ',')}]");
        }
    }
    
    
}
