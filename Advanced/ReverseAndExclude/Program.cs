namespace ReverseAndExclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int n = int.Parse(Console.ReadLine());
            Predicate<int> isDivisible(int n)=> x=> x%n!=0;
            numbers = numbers.Reverse().Where(x=>isDivisible(n)(x)).ToArray();
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
