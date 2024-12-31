int n = int.Parse(Console.ReadLine());
int evenSum = 0;
int oddSum = 0;
for (int i = 0; i < n; i++)
{
    int newNumber = int.Parse((Console.ReadLine()));
    if (i%2 ==0) evenSum += newNumber;
    else oddSum += newNumber;

}
if (evenSum == oddSum)

{
    Console.WriteLine("Yes");
    Console.WriteLine($"Sum = {oddSum}");
}
else
{
    Console.WriteLine("No");
    Console.WriteLine($"Diff = {Math.Abs(oddSum-evenSum)}");
}
