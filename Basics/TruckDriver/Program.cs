string season = Console.ReadLine();
double kilometers = double.Parse(Console.ReadLine());

double moneyBeforeTaxes = 0;
double moneyAfterTaxes = 0;
if (10000 < kilometers  && kilometers <= 20000) moneyBeforeTaxes = 4 * kilometers * 1.45;
else if ( kilometers <= 5000)
{
    if (season == "Summer") moneyBeforeTaxes = 4 * kilometers * 0.9;
    else if (season == "Winter") moneyBeforeTaxes = 4 * kilometers * 1.05;
    else moneyBeforeTaxes = 4 * kilometers * 0.75;
}
else
{
    if (season == "Summer") moneyBeforeTaxes = 4 * kilometers * 1.1;
    else if (season == "Winter") moneyBeforeTaxes = 4 * kilometers * 1.25;
    else moneyBeforeTaxes = 4 * kilometers * 0.95;
}
moneyAfterTaxes = 0.9 *  moneyBeforeTaxes;
Console.WriteLine($"{moneyAfterTaxes:f2}");