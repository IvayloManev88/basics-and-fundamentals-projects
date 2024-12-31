int months = int.Parse(Console.ReadLine());
double waterBill = 0;
double intenetBill = 0;
double electricityBill =0;
double otherBill = 0;
double averageBills = 0;
for (int i = 0; i < months; i++)
{
    double electricity = double.Parse(Console.ReadLine());
    electricityBill += electricity;
    waterBill += 20;
    intenetBill += 15;
    otherBill = (waterBill + electricityBill + intenetBill) * 1.2;
}
Console.WriteLine($"Electricity: {electricityBill:f2} lv");
Console.WriteLine($"Water: {waterBill:f2} lv");
Console.WriteLine($"Internet: {intenetBill:f2} lv");
Console.WriteLine($"Other: {otherBill:f2} lv");
averageBills = (electricityBill + waterBill + intenetBill + otherBill) / (double)months;
Console.WriteLine($"Average: {averageBills:f2} lv");
