string companyName = Console.ReadLine();
int countAdultTickets = int.Parse(Console.ReadLine());
int countChildTickets = int.Parse(Console.ReadLine());
double priceAdultTicket = double.Parse(Console.ReadLine());
double priceChildTicket = priceAdultTicket * 0.3;
double fee = double.Parse(Console.ReadLine());
double profit = priceAdultTicket * countAdultTickets + countChildTickets * priceChildTicket + (countAdultTickets + countChildTickets) * fee;
Console.WriteLine($"The profit of your agency from {companyName} tickets is {(profit*0.2):f2} lv.");