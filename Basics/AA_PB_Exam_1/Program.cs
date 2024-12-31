int fat = int.Parse(Console.ReadLine());
int protein  = int.Parse(Console.ReadLine());
int carbohydrates  = int.Parse(Console.ReadLine());
int calories  = int.Parse(Console.ReadLine());
int waterPercentage = int.Parse(Console.ReadLine());

double fatInGrams = ((fat/100.00) * calories)/ 9.00;
double proteinInGrams = ((protein / 100.00) * calories) / 4.00;
double carbohydratesInGrams = ((carbohydrates / 100.00) * calories) / 4.00;

double CaloriesInGram = calories / (fatInGrams + proteinInGrams + carbohydratesInGrams);
double finalCalories = (((100-waterPercentage) / 100.00) * CaloriesInGram);
Console.WriteLine($"{finalCalories:f4}");

