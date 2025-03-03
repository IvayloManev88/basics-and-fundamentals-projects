using System.Text;

namespace MultiplyBigNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder calculation = new StringBuilder(Console.ReadLine());
            int times = int.Parse(Console.ReadLine());
            StringBuilder newString = new StringBuilder();
            int helpValue = 0;
            if (times == 0)
            {
                Console.WriteLine("0");
                return;
            }

            for (int i = calculation.Length - 1; i >= 0; i--)
            {
                
                helpValue = int.Parse(calculation[i].ToString()) *times + helpValue;

                int valueToAdd = helpValue % 10;
                if (i == 0) { newString.Insert(0, helpValue); }
                else
                {
                    newString.Insert(0, valueToAdd);
                    helpValue /= 10;
                }

            }
            Console.WriteLine(newString.ToString());
        }
    }
}
