namespace UniqueUsernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfNames = int.Parse(Console.ReadLine());
            HashSet<string> names = new HashSet<string>();
            for (int i = 0; i < numberOfNames; i++)
            {
                names.Add(Console.ReadLine());
            }
            Console.WriteLine(String.Join("\n", names));
        }
    }
}
