namespace CustomComparator
{
    public class Program
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            IComparer<int> comparer = Comparer<int>.Create(
                (x, y) =>
                {
                    if (x % 2 == 0 && y % 2 != 0) return -1;
                    if (x % 2 != 0 && y % 2 == 0) return 1;

                    return Comparer<int>.Default.Compare(x, y);
                });
            Array.Sort(numbers, comparer);
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
