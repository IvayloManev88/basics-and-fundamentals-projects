int n = int.Parse(Console.ReadLine());
double totalPrice  = 0;
double pMicrobus = 0;
double pTruck = 0;
double pTrain = 0;
double totalWeight = 0;
for (int i = 0; i < n; i++)
{
    int  weight = int.Parse(Console.ReadLine());
    totalWeight += weight;
    if (weight <=3)
    {
        totalPrice += weight * 200;
        pMicrobus+= weight;
        
    }
    else if (weight >=12)
    {
        totalPrice += weight * 120;
        pTrain += weight;
       
    }
    else
    {
        totalPrice += weight * 175;
        pTruck += weight;
        
    }
}
double averagePrice = totalPrice / (double)totalWeight;
pMicrobus = pMicrobus / (double)totalWeight * 100;
pTruck = pTruck / (double)totalWeight * 100;
pTrain = pTrain / (double)totalWeight * 100;
Console.WriteLine($"{averagePrice:f2}");
Console.WriteLine($"{pMicrobus:f2}%");
Console.WriteLine($"{pTruck:f2}%");
Console.WriteLine($"{pTrain:f2}%");