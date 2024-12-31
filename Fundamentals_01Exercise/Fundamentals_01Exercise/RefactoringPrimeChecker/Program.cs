using System;

namespace RefactoringPrimeChecker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            for (int i = 2; i <= number; i++)
            {
                bool isPrime = true;
                for (int prime = 2; prime < i; prime++)
                {
                    if (i % prime == 0)
                    {
                        isPrime = false;
                        break;
                    }
                   
                }
                Console.WriteLine("{0} -> {1}", i, isPrime.ToString().ToLower());

            }

        }
    }
}
