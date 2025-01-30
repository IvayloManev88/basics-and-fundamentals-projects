namespace SoftUniReception
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int employee1 = int.Parse(Console.ReadLine());
            int employee2 = int.Parse(Console.ReadLine());
            int employee3 = int.Parse(Console.ReadLine());
            int totalRequests = int.Parse(Console.ReadLine());
            int hoursNeeded = 0;
            while (totalRequests>0)
            {
                hoursNeeded++;
                totalRequests -= employee1 + employee2 + employee3;
                if (hoursNeeded%4==0) hoursNeeded++;
            }
            Console.WriteLine($"Time needed: {hoursNeeded}h.");
        }
    }
}
