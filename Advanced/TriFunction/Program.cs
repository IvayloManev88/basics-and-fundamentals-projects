namespace TriFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
            Func<string, int, bool> nameHitsTarget = (name, target) =>
            {
                int counter = 0;
                foreach (char c in name)
                {
                    counter += (int)c;
                }
                if (counter >= target) return true;
                else return false;
            };
            
            Console.WriteLine(names.First(s=> nameHitsTarget(s, n)));
        }
    }
}
