namespace MagicSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int magicNumber=int.Parse(Console.ReadLine());
            int firstNumber = 0;
            int secondNumber = 0;
           
            
            for (int i = 0; i < numbers.Length-1; i++)
            {
                firstNumber = numbers[i];
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    secondNumber = numbers[j];
                    if (firstNumber + secondNumber == magicNumber)
                    {
                        Console.WriteLine(firstNumber + " " + secondNumber);
                    }

                }
            }
        }
    }
}
