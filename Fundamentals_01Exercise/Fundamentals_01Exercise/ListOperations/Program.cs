namespace ListOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            string command = string.Empty;
            while ((command=Console.ReadLine())!= "End")
            {
                List<string> commands = command.Split().ToList();
                switch (commands[0])
                {
                    case "Add":
                        numbers.Add(int.Parse(commands[1]));
                        break;
                    case "Insert":
                        if (IsIndexValid(int.Parse(commands[2]), numbers))
                        {
                            numbers.Insert(int.Parse(commands[2]), int.Parse(commands[1]));
                        }
                        break;
                    case "Remove":
                        if (IsIndexValid(int.Parse(commands[1]), numbers))
                        {
                            numbers.RemoveAt(int.Parse(commands[1]));
                        }
                        break;
                    case "Shift":
                        if (commands[1] == "left")
                        {
                            for (int i = 0; i < int.Parse(commands[2]); i++)
                            {
                                int storeFirstValue = numbers[0];
                                numbers.RemoveAt(0);
                                numbers.Add(storeFirstValue);
                            }
                        }
                        else if (commands[1] == "right")
                        {
                            for (int i = 0; i < int.Parse(commands[2]); i++)
                            {
                                int storeLastValue = numbers[numbers.Count - 1];
                                numbers.RemoveAt(numbers.Count - 1);
                                numbers.Insert(0, storeLastValue);
                            }
                        }
                        break;

                }
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
        static bool IsIndexValid (int index, List<int> numbers)
        {
            bool isValid=true;
            if (index >= numbers.Count || index<0)
            {
                Console.WriteLine("Invalid index");
                isValid = false;
            }

            return isValid;

        }

    }
}
