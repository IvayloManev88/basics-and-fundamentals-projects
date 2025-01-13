using System.Runtime.CompilerServices;

namespace TopNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number=int.Parse(Console.ReadLine());
            for (int i = 1; i <= number; i++)
            {
               if ((IsDivisibleBy8(i))&& (HasOddDigit(i))) Console.WriteLine(i);
            }
          


        }
        static bool IsDivisibleBy8(int number)
        {
            bool isDivisible = false;
            int sum = 0;
            int legnth =number.ToString().Length;
            for (int i = 0; i < legnth; i++)
            {
                sum += number % 10;
                number /= 10;
            }
            if (sum % 8 == 0) isDivisible = true;
            return isDivisible;
        }
        static bool HasOddDigit(int number)
        {
            bool hasOddDigit = false;
            int legnth = number.ToString().Length;
            for (int i = 0; i < legnth; i++)
            {
                int currentNumber = number % 10;
                if (currentNumber % 2 != 0)
                {
                    hasOddDigit = true;
                    return hasOddDigit;
                }
                number /= 10;
            }
            
            return hasOddDigit;
        }
    }
}
