int n = int.Parse(Console.ReadLine());
int sum = 0;
int max = int.MinValue;
for (int i = 0; i < n; i++)
{
    int newValue = int.Parse(Console.ReadLine());
    sum += newValue;
    if (newValue>max) max = newValue;

}

if (max == (sum / 2.00))
{
    Console.WriteLine("Yes");
    Console.WriteLine($"Sum = {max}");
}
else
{
    Console.WriteLine("No");
    Console.WriteLine($"Diff = {Math.Abs(sum - 2 * max)}");
}