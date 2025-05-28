namespace DateModifier
{
    public class StartUp
    {
        static void Main()
        {
            string startDate = Console.ReadLine();
            string endDate = Console.ReadLine();
            DateModifier date = new DateModifier()
            {
                StartDate = startDate,
                EndDate = endDate
            };
            Console.WriteLine(date.CalculateDays());
        }
    }
}
