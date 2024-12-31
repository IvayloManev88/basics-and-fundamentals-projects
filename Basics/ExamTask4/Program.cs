string name1 = Console.ReadLine();
string name2 = Console.ReadLine();
string input = "";
int points1= 0;
int points2 = 0;
int card1= 0;
int card2= 0;
while ((input=Console.ReadLine())!= "End of game")
{
    card1 = int.Parse(input);
    card2 = int.Parse(Console.ReadLine());
    if (card1 > card2) points1 += card1 - card2;
    else if (card1 < card2) points2 += card2 - card1;
    else
    {
        card1 = int.Parse(Console.ReadLine());
        card2 = int.Parse(Console.ReadLine());
        if (card1 > card2)
        {

            Console.WriteLine("Number wars!");
            Console.WriteLine($"{name1} is winner with {points1} points");
        }


        else
        {
            Console.WriteLine("Number wars!");
            Console.WriteLine($"{name2} is winner with {points2} points");
        }
        return;
    }
}
Console.WriteLine($"{name1} has {points1} points");
Console.WriteLine($"{name2} has {points2} points");