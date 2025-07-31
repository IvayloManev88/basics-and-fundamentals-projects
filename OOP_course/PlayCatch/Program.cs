using System.Security.Cryptography.X509Certificates;

namespace PlayCatch
{
    internal class Program
    {
        static void Main(string[] args)
        {
           int[] numbers = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int exceptionsCounter = 0;
            while (exceptionsCounter < 3)
            {
                string[] commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    switch (commands[0])
                    {
                        case "Replace":
                            int index = int.Parse(commands[1]);
                            int element = int.Parse(commands[2]);
                            numbers = Replace(index,element, numbers);
                            break;
                        case "Print":
                            
                            int startIndex = int.Parse(commands[1]);
                            int endIndex = int.Parse(commands[2]);
                            if (startIndex < 0 || endIndex >= numbers.Length) throw new IndexOutOfRangeException("out of range");
                            Print(startIndex,endIndex, numbers);
                            break;
                        case "Show":
                            Console.WriteLine(numbers[int.Parse(commands[1])]);
                            break;

                    }
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("The index does not exist!");
                    exceptionsCounter++;
                }
                catch (FormatException)
                {
                    Console.WriteLine("The variable is not in the correct format!");
                    exceptionsCounter++;
                }
            }
            Console.WriteLine(string.Join(", ",numbers));

           
        }
        static int[] Replace(int index, int element, int[] numbers)
        {
            
            numbers[index] = element;
            return numbers;
        }
        static void Print(int startIndex, int endIndex, int[] numbers)
        {
           
            for (int i = startIndex; i <= endIndex; i++)
            {
                if (i == endIndex)
                    Console.Write(numbers[i]);
                else Console.Write(numbers[i] + ", ");


            }
            Console.WriteLine();
        }
    }
}
