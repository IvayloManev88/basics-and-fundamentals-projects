using System.ComponentModel.Design;

int totalAmountToBeCollected = int.Parse(Console.ReadLine());
string input = "";
int transactionAmount = 0;
int counter = 0;
int cashPaymentCounter =0;
int cardPaymentCounter = 0;
int cashPaymentAmount = 0;
int cardPaymentAmount = 0;
while ((input = Console.ReadLine()) != "End")
{
    transactionAmount = int.Parse(input);
    counter++;
    if (counter % 2 != 0)
    {
        if (transactionAmount > 100) Console.WriteLine("Error in transaction!");
        else
        {
            Console.WriteLine("Product sold!");
            cashPaymentCounter++;
            cashPaymentAmount += transactionAmount;
        }
    }
    else
    {
        if (transactionAmount < 10) Console.WriteLine("Error in transaction!");
        else
        {
            Console.WriteLine("Product sold!");
            cardPaymentCounter++;
            cardPaymentAmount += transactionAmount;
        }
    }
    
    if (totalAmountToBeCollected<=(cardPaymentAmount+cashPaymentAmount))
    {
        Console.WriteLine($"Average CS: {(double)cashPaymentAmount/cashPaymentCounter:f2}");
        Console.WriteLine($"Average CC: {(double)cardPaymentAmount / cardPaymentCounter:f2}");
        return;
    }
    
}
Console.WriteLine("Failed to collect required money for charity.");