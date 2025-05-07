namespace SortEvenNumbers
{
    internal class Program
    {
        static void Main(string[] args)

        {
           
            int[] ints = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Where (x=> x%2==0)
                .OrderBy (x => x)
                .ToArray ();
        
            Console.WriteLine(string.Join(", ", ints));
        }
    }
}
