namespace WordFilter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] inputs = Console.ReadLine().Split();
            Console.WriteLine(string.Join("\n", inputs.Where(word=>word.Length%2==0)));
        }
    }
}
