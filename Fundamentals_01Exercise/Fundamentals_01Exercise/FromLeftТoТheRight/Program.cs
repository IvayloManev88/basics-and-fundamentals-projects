using System.Diagnostics.CodeAnalysis;

namespace FromLeftТoТheRight
{
    internal class Program
    {
        static void Main(string[] args)
        {
           int numberOfRows = int.Parse(Console.ReadLine());
            int input = 0;

            
          
            for (int i = 0; i < numberOfRows; i++)
            {
                long sum = 0;
                string leftnumber = "";
                while ((input = Console.Read()) !=32)
                {
                    
                    leftnumber = string.Concat(leftnumber,(char)input);

                }
                long leftNumberValue = long.Parse(leftnumber);
                long rightNumberValue = long.Parse(Console.ReadLine());
              
                if (leftNumberValue > rightNumberValue)
                {
                    leftNumberValue = Math.Abs(leftNumberValue);
                    while (leftNumberValue>0)
                    {
                        sum += leftNumberValue % 10;
                        leftNumberValue /= 10;
                    }
                }
            else
                {
                    rightNumberValue = Math.Abs(rightNumberValue);
                    while (rightNumberValue > 0)
                    {
                        sum += rightNumberValue % 10;
                        rightNumberValue /= 10;
                    }
                }
                Console.WriteLine(sum);
            }
            
        }
    }
}
