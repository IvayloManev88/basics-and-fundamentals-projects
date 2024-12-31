int n = int.Parse(Console.ReadLine());
int maxDiff = 0;
int sumNewNumbers = 0;
int sumOldNumbers = 0;
int equals = 0;
int difference = 0;
for (int i = 0; i < n; i++)
{
    int number1 = int.Parse(Console.ReadLine());
    int number2 = int.Parse(Console.ReadLine());
    sumNewNumbers = number1 + number2;

    if (sumNewNumbers == sumOldNumbers && i > 0) equals = sumNewNumbers;
    else if (i == 0)
    {
        equals = sumNewNumbers;
       
    }
    else if (sumNewNumbers != sumOldNumbers)
    {
        difference = Math.Abs(sumNewNumbers - sumOldNumbers);
        if (difference > maxDiff) maxDiff = difference;
    }
    sumOldNumbers = sumNewNumbers;

}
if (maxDiff == 0)
    Console.WriteLine($"Yes, value={equals}");
else Console.WriteLine($"No, maxdiff={maxDiff}");