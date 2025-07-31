namespace Cards
{
    public class Program
    {
        static void Main(string[] args)
        {
           List <Card> cards = new List <Card> ();
            string[] cardInput = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < cardInput.Length; i++)
            {
                try
                {
                    string[] getCardDetails = cardInput[i].Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                    Card currentCard = new Card(getCardDetails[0], getCardDetails[1]);
                    cards.Add(currentCard);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.WriteLine(string.Join(" ",cards));

        }
    }
}
