namespace RecordUniqueNames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> names = new HashSet<string>();
            int inputsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < inputsCount; i++)
                names.Add(Console.ReadLine());
            
            foreach (string name in names)
                Console.WriteLine(name);
            
        }
    }
}
