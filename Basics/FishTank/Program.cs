int length = int.Parse(Console.ReadLine());
int width = int.Parse(Console.ReadLine());
int height = int.Parse(Console.ReadLine());
double percent = double.Parse(Console.ReadLine());
double volumeInLeters = length * width * height * 0.001;
double totalWater = volumeInLeters * (1 - percent / 100);
Console.WriteLine(totalWater);
