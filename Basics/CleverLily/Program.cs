int n = int.Parse(Console.ReadLine());
double washingMachinePrice = double.Parse(Console.ReadLine());
int priceOfToy = int.Parse(Console.ReadLine());
int numberToys = 0;
double sumMoney = 0;
double totalMoney = 0;
int birthday = 0;
for (int i = 2; i <= n; i+=2)
{
    birthday++;
    sumMoney = (sumMoney + birthday*10)-1;
}
for (int i = 1; i <= n; i += 2) 
{
    numberToys++; 
}
totalMoney = sumMoney + (numberToys * priceOfToy);

if (totalMoney >= washingMachinePrice) Console.WriteLine($"Yes! {(totalMoney - washingMachinePrice):f2}");
else Console.WriteLine($"No! {(washingMachinePrice-totalMoney):f2}");


