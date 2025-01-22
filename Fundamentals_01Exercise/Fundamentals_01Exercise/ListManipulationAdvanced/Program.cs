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
            int change = 0;
            while ((command = Console.ReadLine()) != "end")
            {
                List<string> commandList = command.Split().ToList();
                if (commandList[0] == "Add")
                {
                    numbers.Add(int.Parse(commandList[1]));
                    change++;
                }
                else if (commandList[0] == "Remove")
                {
                    numbers.Remove(int.Parse(commandList[1]));
                    change++;
                }
                else if (commandList[0] == "RemoveAt")
                {
                    numbers.RemoveAt(int.Parse(commandList[1]));
                    change++;
                }
                else if (commandList[0] == "Insert")
                {
                    numbers.Insert(int.Parse(commandList[2]), int.Parse(commandList[1]));
                    change++;
                }
                else if (commandList[0] == "Contains")
                {
                    if (numbers.Contains(int.Parse(commandList[1]))) Console.WriteLine("Yes");
                    else Console.WriteLine("No such number");
                }
                else if (commandList[0] == "PrintEven")
                {
                    List<int> workNumbers = numbers.ToList();
                    workNumbers.RemoveAll(n => n % 2 != 0);
                    Console.WriteLine(string.Join(" ", workNumbers));
                }
                else if (commandList[0] == "PrintOdd")
                {
                    List<int> workNumbers = numbers.ToList();
                    workNumbers.RemoveAll(n => n % 2 == 0);
                    Console.WriteLine(string.Join(" ", workNumbers));
                }
                else if (commandList[0] == "GetSum")
                {
                    int sum = 0;
                    for (int i=0; i<numbers.Count;i++)
                    {
                        sum += numbers[i];
                    }
                    Console.WriteLine(numbers.Sum());
                }
                else if (commandList[0] == "Filter")
                {
                    List<int> workNumbers = numbers.ToList();
                    int conditionNumber = int.Parse(commandList[2]);
                    if (commandList[1] == ">") workNumbers.RemoveAll(n => n <= conditionNumber);
                    else if (commandList[1] == ">=") workNumbers.RemoveAll(n => n < conditionNumber);
                    else if (commandList[1] == "<") workNumbers.RemoveAll(n => n >= conditionNumber);
                    else if (commandList[1] == "<=") workNumbers.RemoveAll(n => n > conditionNumber);

                    Console.WriteLine(string.Join(" ", workNumbers));
                }
            }

            if (change>0) Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
