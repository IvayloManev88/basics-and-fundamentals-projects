namespace PredicateForNames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
            Iterate(names, x=>x.Length<=n, x=>Console.WriteLine(x));

        }
        static void Iterate(string[] names, Predicate<string> condition, Action<string> action)
        {
            foreach (string name in names)
            {
                if (condition(name))
                    action(name);

            }
        }
    }
}
