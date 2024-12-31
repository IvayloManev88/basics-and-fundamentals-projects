

double money = double.Parse(Console.ReadLine());
int yearToLive = int.Parse(Console.ReadLine());
int currentAge = 17;
double totalMoneyNeeded = 0;
for (int i = 0; i <= (yearToLive-1800); i++)
{
    if (i % 2 ==0)
    {
        currentAge++;
        totalMoneyNeeded += 12000;
    }
    else
    {
        currentAge++;
        totalMoneyNeeded = totalMoneyNeeded + 12000 + 50 * currentAge;
    }
}

if (money >= totalMoneyNeeded)
{
    double remainingMoney = money - totalMoneyNeeded;
    Console.WriteLine($"Yes! He will live a carefree life and will have {remainingMoney:f2} dollars left.");
}
else
{
    double moneyNotEnough = totalMoneyNeeded - money;
    Console.WriteLine($"He will need {moneyNotEnough:f2} dollars to survive.");
}