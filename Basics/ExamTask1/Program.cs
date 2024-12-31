double tennisRacketPrice = double.Parse(Console.ReadLine());
int tennisRacketCount = int.Parse(Console.ReadLine()); 
int sneakersCount  = int.Parse(Console.ReadLine());
//1/8 from the price
double priceJokovitch = 0;
//7/8 from the price
double priceSponsors = 0;
double sneakerPrice = tennisRacketPrice / 6.00;
double otherEquipement = 0.2 * (tennisRacketCount * tennisRacketPrice + sneakerPrice * sneakersCount);
double wholeBill = otherEquipement + (tennisRacketCount * tennisRacketPrice + sneakerPrice * sneakersCount);
priceJokovitch = wholeBill / 8.00;
priceSponsors = wholeBill - priceJokovitch;
Console.WriteLine($"Price to be paid by Djokovic {Math.Floor(priceJokovitch)}");
Console.WriteLine($"Price to be paid by sponsors {Math.Ceiling(priceSponsors)}");