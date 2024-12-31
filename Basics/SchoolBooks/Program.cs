int pens = int.Parse(Console.ReadLine());
int markers = int.Parse(Console.ReadLine());
int cleaner = int.Parse(Console.ReadLine());
double percentDiscount = double.Parse(Console.ReadLine());
double totalPrice = (pens * 5.80 + markers * 7.20 + cleaner * 1.2) * (1 - percentDiscount / 100);
Console.WriteLine(totalPrice);