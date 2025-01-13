namespace AddAndSubtract
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber=int.Parse(Console.ReadLine());
            int thirdNumber=int.Parse(Console.ReadLine());
            Console.WriteLine(SubtractThirdNumber(FirstTwoNumbersSum(firstNumber, secondNumber), thirdNumber));
        }
        static int FirstTwoNumbersSum (int n1,int n2)
        {
            return (n1 + n2);
        }
        static int SubtractThirdNumber(int n1, int n2)
        {
            return (n1 - n2);
        }
    }
}
