int trainingCost = int.Parse(Console.ReadLine());
double sneakers = trainingCost * 0.6;
double jursey = 0.8 * sneakers;
double ball = 0.25 * jursey;
double accessories = 0.2 * ball;
double totalCost = sneakers + accessories + ball + jursey + trainingCost;
Console.WriteLine(totalCost);
