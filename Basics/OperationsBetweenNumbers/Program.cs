int n1 = int.Parse(Console.ReadLine());
int n2 = int.Parse(Console.ReadLine());
string operation = Console.ReadLine();
double total = 0;
if (operation == "+") total = n1 + n2;
else if (operation == "-") total = n1 - n2;
else if (operation == "*") total = n1 * n2;
else if (operation == "/")
{
    if (n2 != 0)
    { total = (n1 / (double)n2);
        Console.WriteLine($"{n1} {operation} {n2} = {total:f2}");
    }
    else Console.WriteLine($"Cannot divide {n1} by zero");
}
else if (operation == "%")
{
    if (n2 != 0)
    {
        total = n1 % n2;
        Console.WriteLine($"{n1} {operation} {n2} = {total}");
    }
    else Console.WriteLine($"Cannot divide {n1} by zero");
}




if (operation == "+" || operation == "-" || operation == "*")
{
    if (total % 2 == 0)
        Console.WriteLine($"{n1} {operation} {n2} = {total} - even");
    else Console.WriteLine($"{n1} {operation} {n2} = {total} - odd");
}
