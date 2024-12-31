int countWindows = int.Parse(Console.ReadLine());
string typeWindows = Console.ReadLine();
string deliveryOption = Console.ReadLine();
double totalPrice = 0;

if (countWindows < 10) Console.WriteLine("Invalid order");
else
{
    if (typeWindows == "90X130")
    {
        if (countWindows > 60) totalPrice = (countWindows * 110) * 0.92;
        else if (countWindows > 30) totalPrice = (countWindows * 110) * 0.95;
        else totalPrice = (countWindows * 110);
    }
    if (typeWindows == "100X150")
    {
        if (countWindows > 80) totalPrice = (countWindows * 140) * 0.9;
        else if (countWindows > 40) totalPrice = (countWindows * 140) * 0.94;
        else totalPrice = (countWindows * 140);
    }
    if (typeWindows == "130X180")
    {
        if (countWindows > 50) totalPrice = (countWindows * 190) * 0.88;
        else if (countWindows > 20) totalPrice = (countWindows * 190) * 0.93;
        else totalPrice = (countWindows * 190);
    }
    if (typeWindows == "200X300")
    {
        if (countWindows > 50) totalPrice = (countWindows * 250) * 0.86;
        else if (countWindows > 25) totalPrice = (countWindows * 250) * 0.91;
        else totalPrice = (countWindows * 250);
    }

    if (deliveryOption == "With delivery") totalPrice += 60;
    if (countWindows > 99) totalPrice = totalPrice * 0.96;


    Console.WriteLine($"{totalPrice:f2} BGN");
}
