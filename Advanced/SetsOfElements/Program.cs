namespace SetsOfElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] setSize = Console.ReadLine().Split().Select(int.Parse).ToArray();
            HashSet<int> n = new HashSet<int>();
            HashSet<int> m = new();
            for (int i = 0; i< setSize[0]; i++)
            {
                n.Add(int.Parse(Console.ReadLine()));
            }
            for (int i = 0;i< setSize[1]; i++)
            {
                m.Add(int.Parse(Console.ReadLine()));
            }
            foreach (int number in n)
            {
                if (m.Contains(number)) Console.Write(number + " ");
            }
        }
    }
}
