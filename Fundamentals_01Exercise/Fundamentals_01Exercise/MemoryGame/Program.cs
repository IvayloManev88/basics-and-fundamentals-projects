using System.ComponentModel.Design;

namespace MemoryGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine()
                .Split()
                .ToList();
            string command = string.Empty;
            int counter = 0;
            while ((command = Console.ReadLine()) != "end")
            {
                counter++;
                List<int> commands = command.Split().Select(int.Parse).ToList();
                int index1 = commands[0];
                int index2 = commands[1];
                if (index1 < 0 || index1 >= input.Count || index2 < 0 || index2 >= input.Count||index1 ==index2)
                {
                    string toInsert = "-" + counter + "a";
                    Console.WriteLine("Invalid input! Adding additional elements to the board");
                    input.Insert(input.Count / 2, $"-{counter}a");
                    input.Insert(input.Count / 2, $"-{counter}a");
                }
                else
                { 
                    if (input[index1] == input[index2])
                    {
                        Console.WriteLine($"Congrats! You have found matching elements - {input[index1]}!");
                        if (index1 > index2)
                        {
                        input.RemoveAt(index1);
                        input.RemoveAt(index2);
                        }
                        else
                         {
                        input.RemoveAt(index2);
                        input.RemoveAt(index1);
                         }
                                        
                      }
                     else
                       {
                        Console.WriteLine($"Try again!");
                      }
                    if (input.Count == 0 || input.Count == 1)
                    {

                        Console.WriteLine($"You have won in {counter} turns!");
                        return;

                     }  
                }       
            }
            if (input.Count>1)
            {
                Console.WriteLine("Sorry you lose :(");
                Console.WriteLine(string.Join(" ",input));
            }
        }
    }
}
