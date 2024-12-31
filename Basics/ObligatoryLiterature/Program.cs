int pageNumber = int.Parse(Console.ReadLine());
int pagePerHour = int.Parse(Console.ReadLine());
int daysForReading = int.Parse(Console.ReadLine());
double hours = pageNumber  * daysForReading / pagePerHour;
Console.WriteLine(hours);