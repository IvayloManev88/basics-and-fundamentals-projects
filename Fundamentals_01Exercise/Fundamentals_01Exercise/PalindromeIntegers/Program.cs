namespace PalindromeIntegers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = "";
            while ((input = Console.ReadLine())!="END")
            {
                int numberOfDigits = input.Length;
                int number = int.Parse(input);
                Console.WriteLine(PalindromeIntegerFinder(number, numberOfDigits));
            }

        }
        static bool PalindromeIntegerFinder (int number, int numberOfDigits)
        {
            bool isPalindorm = false;
            string strnumber = number.ToString();
            if (numberOfDigits %2==0)
            {
                int[] leftNumbers = new int[numberOfDigits / 2];
                for (int i=0; i< numberOfDigits/2;i++)
                {
                    leftNumbers[i] = (int)(strnumber[i] - '0');
                }
                int[] rightNumbers = new int[numberOfDigits / 2];
                for (int i = 0; i < numberOfDigits / 2; i++)
                {
                    rightNumbers[i] = (int)(strnumber[numberOfDigits-1-i] - '0');
                }
                if (string.Join(" ",leftNumbers) == string.Join(" ",rightNumbers)) isPalindorm = true;
            }
            else
            {
                int[] leftNumbers = new int[(numberOfDigits-1) / 2];
                for (int i = 0; i < (numberOfDigits-1) / 2; i++)
                {
                    leftNumbers[i] = (int)(strnumber[i] - '0');
                }
                int[] rightNumbers = new int[(numberOfDigits-1) / 2];
                for (int i = 0; i < (numberOfDigits-1) / 2; i++)
                {
                    rightNumbers[i] = (int)(strnumber[numberOfDigits - 1 - i] - '0');
                }
                if (string.Join(" ", leftNumbers) == string.Join(" ", rightNumbers)) isPalindorm = true;
            }
            return isPalindorm;
        }
    }
}
