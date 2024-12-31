namespace _06.StrongNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            string numberToString = number.ToString();
            int helpNumber = number;
            int sum = 0;
            for (int i = (numberToString.Length - 1); i >= 0; i--)
            {
                int helpValue = 0;
                if (i == 0)
                {
                    helpValue = helpNumber;
                }
                else
                {
                    helpValue = helpNumber / (int)Math.Pow(10,i);
                    helpNumber -= helpValue * (int)Math.Pow(10,i);
                }
                //sum+=helpValue
                int n = 1;
                for (int k = helpValue; k > 1; k--)
                {
                    n = n * k;
                }
                sum += n;
            }
            if (sum == number) Console.WriteLine("yes");
            else Console.WriteLine("no");
        }
    }
}
