namespace FactorialDivision
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            double firstNumberFactorial = (double)Factorial(firstNumber);
            double secondNumberFactorial = (double)Factorial(secondNumber);
            Console.WriteLine($"{(firstNumberFactorial/secondNumberFactorial):f2}");
          
        }
        static double Factorial(int Number)
        {
            double factorial = 1;
            for (int i= Number; i>=1;i--)
            {
                factorial *= i;
            }
            return factorial;
        }

    }
}
