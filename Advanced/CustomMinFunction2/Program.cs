namespace CustomMinFunction2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int minimum =Aggregate(numbers, (number, min) => number < min ? number:min, int.MaxValue);
            Console.WriteLine(minimum);

        }
        static int Aggregate(int[] numbers, Func<int, int,int> func, int initial)
        {
            int aggregate = initial;
            foreach (int number in numbers)
            {
                func(number, aggregate);
                
            }
            return aggregate;
        }
    }
}
