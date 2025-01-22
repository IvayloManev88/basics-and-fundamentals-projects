using System.Collections.Generic;

namespace HouseParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int commandNumber = int.Parse(Console.ReadLine());
            List<string> guestList = new();
            for (int i = 0; i < commandNumber; i++)
            {
                List<string> commandList = Console.ReadLine()
                    .Split()
                    .ToList();
                if (commandList.Count==3)
                {
                    if (guestList.Contains(commandList[0])) Console.WriteLine($"{commandList[0]} is already in the list!");
                    else guestList.Add(commandList[0]);
                }
                else if (commandList.Count == 4)
                {
                    if (guestList.Contains(commandList[0])) guestList.Remove(commandList[0]);
                    else Console.WriteLine($"{commandList[0]} is not in the list!");
                }
            }
            foreach (string guest in guestList)
            {
                Console.WriteLine(guest);
            }
        }
    }
}
