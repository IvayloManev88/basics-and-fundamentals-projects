namespace CardsGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> cardsFirstPlayer = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            List<int> cardsSecondPlayer = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            
                while (cardsFirstPlayer.Count>0&& cardsSecondPlayer.Count>0)
                {
                     if (cardsFirstPlayer[0] == cardsSecondPlayer[0])
                     {
                     cardsFirstPlayer.RemoveAt(0);
                     cardsSecondPlayer.RemoveAt(0);
                     }
                     else if (cardsFirstPlayer[0] > cardsSecondPlayer[0])
                     {
                     int helpCard = cardsFirstPlayer[0];
                     cardsFirstPlayer.RemoveAt(0);
                     cardsFirstPlayer.Add(cardsSecondPlayer[0]);
                     cardsFirstPlayer.Add(helpCard);
                     cardsSecondPlayer.RemoveAt(0);
                     }
                    else
                    {
                    int helpCard = cardsSecondPlayer[0];
                    cardsSecondPlayer.RemoveAt(0);
                    cardsSecondPlayer.Add(cardsFirstPlayer[0]);
                    cardsSecondPlayer.Add(helpCard);
                    cardsFirstPlayer.RemoveAt(0);
                    }
                    
                }
                int sum = 0;
            if (cardsFirstPlayer.Count == 0)
            {
                foreach (int card in cardsSecondPlayer)
                {
                    sum += card;
                }
                Console.WriteLine($"Second player wins! Sum: {sum}");
                }
            else if (cardsSecondPlayer.Count == 0)
            {
                foreach (int card in cardsFirstPlayer)
                {
                    sum += card;
                }
                Console.WriteLine($"First player wins! Sum: {sum}");

            }
            
        }
    }
}
