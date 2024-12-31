using System;

int chickenMenu = int.Parse(Console.ReadLine());
int fishMenu = int.Parse(Console.ReadLine());
int vegetarianMenu = int.Parse(Console.ReadLine());
double orderTotal = chickenMenu * 10.35 + fishMenu * 12.40 + vegetarianMenu * 8.15 + 0.2 * (chickenMenu * 10.35 + fishMenu * 12.40 + vegetarianMenu * 8.15) + 2.50;

Console.WriteLine(orderTotal);
