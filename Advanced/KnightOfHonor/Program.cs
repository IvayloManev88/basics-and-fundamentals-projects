namespace KnightOfHonor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            ForEach(names,x=> Console.WriteLine($"Sir {x}"));
        }
        static void ForEach(string[] inputArray, Action<string> action)
        {
            foreach (string element in inputArray)
            {
                action(element);
            }
        }
    }
}
