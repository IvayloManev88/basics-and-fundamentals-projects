int customerCount = int.Parse(Console.ReadLine());
string input = "";
double totalIncome = 0;
for (int i = 0; i < customerCount; i++)
{
    int customerItemsCount = 0;
    double customerBill = 0;
    while ((input=Console.ReadLine())!="Finish")
    {
       
        double itemPrice = 0;
        if (input == "basket") itemPrice = 1.5;
        else if (input == "wreath") itemPrice = 3.8;
        else if (input == "chocolate bunny") itemPrice = 7;
        customerItemsCount++;
        customerBill += itemPrice;
    }
    if (customerItemsCount % 2 == 0) customerBill = customerBill * 0.8;
    totalIncome += customerBill;
    Console.WriteLine($"You purchased {customerItemsCount} items for {customerBill:f2} leva.");
}
Console.WriteLine($"Average bill per client is: {totalIncome/ (double)customerCount:f2} leva.");