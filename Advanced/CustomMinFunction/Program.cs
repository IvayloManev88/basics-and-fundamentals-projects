namespace CustomMinFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int min = int.MaxValue;
            int[] numbers = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            foreach (int number in numbers)
            {
                Func<int, int> minValue = CheckMin(number, min);
                min =minValue(number);
            }
            Console.WriteLine(min);
            

            Func<int, int> CheckMin(int value, int min)
            {
                if (value < min)
                {
                    min = value;
                }
                return (value)=>min;
            }
        }
    }
}
