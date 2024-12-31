namespace _03.Vacation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            string type = Console.ReadLine();
            string day = Console.ReadLine();
            double totalBudget = 0;
            if (type == "Students")
            {
                if (day == "Friday") totalBudget = count * 8.45;
                else if (day == "Saturday") totalBudget = count * 9.80;
                else if (day == "Sunday") totalBudget = count * 10.46;
                if (count >= 30) totalBudget = totalBudget * 0.85;
            }
            else if (type == "Business" && count >= 100)
            {
                if (day == "Friday") { totalBudget = (count - 10) * 10.90; }
                else if (day == "Saturday") { totalBudget = (count - 10) * 15.60; }
                else if (day == "Sunday") { totalBudget = (count - 10) * 16; }
            }
            else if (type == "Business" && count < 100)
            {
                if (day == "Friday") { totalBudget = count * 10.90; }
                else if (day == "Saturday") { totalBudget = count * 15.60; }
                else if (day == "Sunday") { totalBudget = count * 16; }
            }
            else if (type == "Regular")
            {
                if (day == "Friday") { totalBudget = count * 15; }
                else if (day == "Saturday") { totalBudget = count * 20; }
                else if (day == "Sunday") { totalBudget = count * 22.50; }

                if (count <= 20 && count >= 10) { totalBudget = totalBudget * 0.95; }
            }
            Console.WriteLine($"Total price: {totalBudget:f2}");
        }
    }
}
