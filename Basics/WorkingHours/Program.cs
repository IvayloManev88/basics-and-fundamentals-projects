int workingHours = int.Parse(Console.ReadLine());
string dayOfWeek = Console.ReadLine();

switch (dayOfWeek)
{
    case "Monday":
    case "Tuesday":
    case "Wednesday":
    case "Thursday":
    case "Friday":
    case "Saturday":
        {
            if (workingHours >= 10 && workingHours <= 18)
            {
                Console.WriteLine("open");
            }
            else Console.WriteLine("closed");
            break;
        }
    default:
                Console.WriteLine("closed");
            break;
}
