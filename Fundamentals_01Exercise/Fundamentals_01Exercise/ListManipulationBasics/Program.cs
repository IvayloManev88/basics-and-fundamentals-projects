namespace ListManipulationBasics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            string command = "";
            while ((command =Console.ReadLine())!= "end")
            {
                List<string> commandList = command.Split().ToList();
                if (commandList[0]=="Add")
                {
                    numbers.Add(int.Parse(commandList[1]));
                }
                else if (commandList[0] == "Remove")
                {
                    numbers.Remove(int.Parse(commandList[1]));
                }
                else if (commandList[0] == "RemoveAt")
                {
                    numbers.RemoveAt(int.Parse(commandList[1]));
                }
                else if (commandList[0] == "Insert")
                {
                    numbers.Insert(int.Parse(commandList[2]),int.Parse(commandList[1]));
                }
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
