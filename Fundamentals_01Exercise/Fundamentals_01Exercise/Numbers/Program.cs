namespace Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select (int.Parse)
                .ToList();
            long sum = 0;
            foreach (int number in numbers)
            {
                sum += number;
            }
            int averageNumber = (int)sum/numbers.Count;
            numbers =numbers.OrderByDescending(n=>n).ToList();
            numbers.RemoveAll(n => n <= averageNumber);
            if (numbers.Count>5)
            {
                numbers = numbers.GetRange(0,5);
            }
            if (numbers.Count == 0) Console.WriteLine("No");
            else Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
