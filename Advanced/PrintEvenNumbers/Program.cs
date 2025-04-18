namespace PrintEvenNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] inputs = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Queue<int> even = new Queue<int>();
            foreach (int input in inputs)
            {
                if (input % 2 == 0)
                {
                    even.Enqueue(input);
                }
            }
            Console.WriteLine(string.Join(", ", even.ToArray()));
        }
    }
}
