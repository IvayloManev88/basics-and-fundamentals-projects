namespace SmallestOfThreeNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());
            GetSmallestNumber(firstNumber, secondNumber, thirdNumber);
        }
        static void GetSmallestNumber(int firstNumber, int secondNumber, int thirdNumber)
        {
            int minNumber = firstNumber;
            if (minNumber>=secondNumber)
            {
                minNumber = secondNumber;
            }
            
            if (minNumber>=thirdNumber)
            {
                minNumber = thirdNumber;
            }
            Console.WriteLine(minNumber);
        }
    }
}
