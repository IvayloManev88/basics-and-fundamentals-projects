int studentCount = int.Parse(Console.ReadLine());
double percentFail = 0;
double percent3 = 0;
double percent4 = 0;
double percentTop = 0;
double averageMark = 0;
for (int i = 0; i < studentCount; i++)
{
    double mark = double.Parse(Console.ReadLine());
    averageMark += mark;
    if (mark < 3) percentFail++;
    else if (mark < 4) percent3++;
    else if (mark < 5) percent4++;
    else percentTop++;

}
percentTop = percentTop / (studentCount) * 100;
percent3 = percent3 / (studentCount) * 100;
percent4 = percent4 / (studentCount) * 100;
percentFail = percentFail / (studentCount) * 100;
averageMark = averageMark / (double)studentCount;
Console.WriteLine($"Top students: {percentTop:f2}%");
Console.WriteLine($"Between 4.00 and 4.99: {percent4:f2}%");
Console.WriteLine($"Between 3.00 and 3.99: {percent3:f2}%");
Console.WriteLine($"Fail: {percentFail:f2}%");
Console.WriteLine($"Average: {averageMark:f2}");