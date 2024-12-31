int degrees = int.Parse(Console.ReadLine());
string timeOfDay = Console.ReadLine();
string outfit = "";
string shoes = "";

if (10 <= degrees && degrees <= 18)
{
    if (timeOfDay == "Morning")
    {
        outfit = "Sweatshirt";
        shoes = "Sneakers";
    }
    else
    {
        outfit = "Shirt";
        shoes = "Moccasins";
    }
}
else if (degrees >= 25)
{
    if (timeOfDay == "Morning")
    {
        outfit = "T-Shirt";
        shoes = "Sandals";
    }
    else if (timeOfDay == "Afternoon")
    {
        outfit = "Swim Suit";
        shoes = "Barefoot";
    }
    else if (timeOfDay == "Evening")
    {
        outfit = "Shirt";
        shoes = "Moccasins";
    }
}
else
{
    if (timeOfDay == "Morning")
    {
        outfit = "Shirt";
        shoes = "Moccasins";
    }
    else if (timeOfDay == "Afternoon")
    {
        outfit = "T-Shirt";
        shoes = "Sandals";
    }
    else if (timeOfDay == "Evening")
    {
        outfit = "Shirt";
        shoes = "Moccasins";
    }
}
Console.WriteLine($"It's {degrees} degrees, get your {outfit} and {shoes}.");