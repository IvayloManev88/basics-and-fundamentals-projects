string input = "";
bool isDevided = false;
int sumPrimeNumbers = 0;
int sumNonPrime = 0;
while ((input = Console.ReadLine()) !="stop")
{
    isDevided = false;
    int number = int.Parse(input);
    if (number < 0)
    {
        Console.WriteLine("Number is negative.");
        continue;
    }
    else
    {
        for (int i = 2; i < number; i++)
        {
            if (number % i == 0)
            {
                isDevided = true;
                break;
            }

        }
        if (isDevided) sumNonPrime += number;
        else sumPrimeNumbers += number;
    }
}
Console.WriteLine($"Sum of all prime numbers is: {sumPrimeNumbers}");
Console.WriteLine($"Sum of all non prime numbers is: {sumNonPrime}");
