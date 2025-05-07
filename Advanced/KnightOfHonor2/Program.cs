namespace KnightOfHonor2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Action<string> printer = name => Console.WriteLine($"Sir {name}");
            foreach (string name in names)
            {
                printer(name);
            }
            Action <string> PrintSirAndName(string name)
            {
                return n=>Console.WriteLine($"Sir {name}");
            }
        }
    }
}
