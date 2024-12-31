using System;

double nylon = double.Parse(Console.ReadLine());
double paint = double.Parse(Console.ReadLine());
double thinner = double.Parse(Console.ReadLine());
double hours = double.Parse(Console.ReadLine());
double materialsCost = ((nylon + 2) * 1.5) + ((paint * 1.1) * 14.5) + (thinner * 5) + 0.4;
double laborCost = hours * 0.3 * materialsCost;
double totalCost = materialsCost + laborCost;
Console.WriteLine(totalCost);
    