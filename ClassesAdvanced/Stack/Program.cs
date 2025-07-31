namespace Stack
{
    public class Program
    {
        public static void Main()
        {
            CustomStack<int>  stack = new CustomStack<int>();
            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                if (command == "Pop")
                {
                    if (stack.Count == 0) Console.WriteLine("No elements");
                    else stack.Pop();
                }
                else if (command.StartsWith("Push"))
                { 
                    IEnumerable<int> numbers =  command.Substring(5).Split(", ").Select(int.Parse);
                    foreach (int number in numbers)
                    {
                        stack.Push(number);
                    }
                }
            }
            for (int i = 0; i<2; i++)
            {
                foreach (int number in stack)
                    Console.WriteLine(number);
            }
        }
    }
}
