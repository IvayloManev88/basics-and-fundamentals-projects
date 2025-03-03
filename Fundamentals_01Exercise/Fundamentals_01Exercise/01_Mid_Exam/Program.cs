namespace _01_Mid_Exam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int buiscuitsPerPerson = int.Parse(Console.ReadLine());
            int numberOfPeople = int.Parse(Console.ReadLine());
            int competingFactory = int.Parse(Console.ReadLine());
            int totalCookies = 0;
            int buisquitsPerDay = 0;
            for (int i = 1; i <=30; i++)
            {
                if (i % 3 == 0)
                {
                    buisquitsPerDay = (int)Math.Floor(0.75 * buiscuitsPerPerson * numberOfPeople);
                }
                else buisquitsPerDay = buiscuitsPerPerson * numberOfPeople;
                totalCookies += buisquitsPerDay;
            }
            Console.WriteLine($"You have produced {totalCookies} biscuits for the past month.");
            double percentage = 0;
            if (totalCookies> competingFactory)
            {
                percentage = (totalCookies - competingFactory) / (double)competingFactory * 100.0;
                Console.WriteLine($"You produce {percentage:f2} percent more biscuits.");
            }
            else
            {
                percentage = (competingFactory- totalCookies) / (double)competingFactory * 100.0;
                Console.WriteLine($"You produce {percentage:f2} percent less biscuits.");
            }
            
        }
    }
}
