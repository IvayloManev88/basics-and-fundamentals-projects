namespace PeriodicTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedSet<string> elements = new();
            int inputCount  = int.Parse(Console.ReadLine());
            for (int i = 0; i < inputCount; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                foreach (string s in input)
                {
                    elements.Add(s);
                }
            }
            Console.WriteLine(string.Join(" ", elements));
        }
    }
}
