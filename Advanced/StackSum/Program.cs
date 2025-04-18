using System.Reflection.Metadata.Ecma335;

namespace StackSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] ints = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            
             
            Stack<int> stackOfInts = new();
          
            for (int i = 0; i < ints.Length; i++)
            {
                stackOfInts.Push(ints[i]);
            }
            string command = string.Empty;
            while ((command = Console.ReadLine().ToLower()) != "end")
            {
                string[] commands = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                switch (commands[0])
                {
                    case "add":
                        stackOfInts.Push (int.Parse(commands[1]));
                        stackOfInts.Push (int.Parse (commands[2]));
                        break;
                    case "remove":
                        int numberToRemove = int.Parse(commands[1]);
                        if (numberToRemove <= stackOfInts.Count)
                        {
                            while (numberToRemove>0)
                            {
                                stackOfInts.Pop();
                                numberToRemove--;
                            }
                        }
                        break;
                }
            }
            
            Console.WriteLine($"Sum: {stackOfInts.Sum()}");

        }
    }
}
