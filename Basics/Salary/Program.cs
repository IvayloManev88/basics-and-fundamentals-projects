int n = int.Parse(Console.ReadLine());
double salary = double.Parse(Console.ReadLine());
double totalMoneyLost = 0.00;
for  (int i = 0; i < n; i++)
{
    string siteName = Console.ReadLine();
    if (siteName == "Facebook") totalMoneyLost += 150;
    else if (siteName == "Instagram") totalMoneyLost += 100;
    else if (siteName == "Reddit") totalMoneyLost += 50;

}
if (salary<=totalMoneyLost) Console.WriteLine("You have lost your salary.");
else  Console.WriteLine(Math.Round(salary - totalMoneyLost,0));