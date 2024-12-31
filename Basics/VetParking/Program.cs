

int days = int.Parse(Console.ReadLine());
int hours = int.Parse(Console.ReadLine());

double totalPrice = 0;
for (int i = 1; i <= days; i++)
{
    int countOtherHours = 0;
    int countEvenDayOddHour = 0;
    int countOddDayEvenHour = 0;
    for (int j = 1; j <= hours; j++)
    {
        if (i % 2 != 0)
        {

            if (j % 2 == 0) countOddDayEvenHour++;
            else countOtherHours++;

            
        }
        if (i % 2 == 0)
        {

            if (j % 2 != 0) countEvenDayOddHour++;
            else countOtherHours++;

           
        }
    }
    Console.WriteLine($"Day: {i} - {(countOddDayEvenHour * 1.25+ countEvenDayOddHour * 2.5 + countOtherHours):f2} leva");
    totalPrice += countOddDayEvenHour * 1.25 + countEvenDayOddHour * 2.5 + countOtherHours;
}
Console.WriteLine($"Total: {totalPrice:f2} leva");