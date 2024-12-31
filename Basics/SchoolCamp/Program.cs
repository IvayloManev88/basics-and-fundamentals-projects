string season = Console.ReadLine();
string groupType = Console.ReadLine();
int studentCount = int.Parse(Console.ReadLine());
int nightsStay  = int.Parse(Console.ReadLine());
double totalPrice = 0;
string sports = "";
if (groupType == "mixed")
{
    if (season == "Winter") totalPrice = 10 * nightsStay * studentCount;
    else if (season =="Spring") totalPrice = 9.5 * nightsStay * studentCount;
    else totalPrice = 20 * nightsStay * studentCount;
}
else
{
    if (season == "Winter") totalPrice = 9.6 * nightsStay * studentCount;
    else if (season == "Spring") totalPrice = 7.2 * nightsStay * studentCount;
    else totalPrice = 15 * nightsStay * studentCount;
}
if (studentCount>=50)  totalPrice = 0.5 * totalPrice;
else if (20 <=studentCount && studentCount < 50) totalPrice = 0.85 * totalPrice;
else if (10 <= studentCount && studentCount < 20) totalPrice = 0.95 * totalPrice;

if (season == "Winter" && groupType == "girls") sports = "Gymnastics";
else if (season == "Winter" && groupType == "boys") sports = "Judo";
else if (season == "Winter" && groupType == "mixed") sports = "Ski";
else if (season == "Spring" && groupType == "girls") sports = "Athletics";
else if (season == "Spring" && groupType == "boys") sports = "Tennis";
else if (season == "Spring" && groupType == "mixed") sports = "Cycling";
else if (season == "Summer" && groupType == "girls") sports = "Volleyball";
else if (season == "Summer" && groupType == "boys") sports = "Football";
else if (season == "Summer" && groupType == "mixed") sports = "Swimming";

Console.WriteLine($"{sports} {totalPrice:f2} lv.");