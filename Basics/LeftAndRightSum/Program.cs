using System.Security.Cryptography;

int n = int.Parse(Console.ReadLine());

int sumLeft =0;
int sumRight =0;

for (int i = 0; i < n*2; i++)
{
    int newNumber = int.Parse(Console.ReadLine());
    if (i<n) sumLeft += newNumber;
    else sumRight += newNumber;
}


if (sumLeft == sumRight) Console.WriteLine($"Yes, sum = {sumLeft}");
else Console.WriteLine($"No, diff = {Math.Abs(sumLeft - sumRight)}");