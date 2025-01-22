namespace PokemonDoNotGo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> pokemons = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            long sum = 0;
            while (pokemons.Count>0)
            {
                int pokemonValue;
                int pokemonIndex = int.Parse(Console.ReadLine());
                if (pokemonIndex < 0)
                {
                    pokemonValue = pokemons[0];
                    pokemons[0]= pokemons[pokemons.Count - 1];
                }
                else if (pokemonIndex >= pokemons.Count)
                {
                    pokemonValue = pokemons[pokemons.Count - 1];
                    pokemons[pokemons.Count - 1] = pokemons[0];
                }
                else
                {
                    pokemonValue = pokemons[pokemonIndex];
                    pokemons.RemoveAt(pokemonIndex);
                }
                              
                sum += pokemonValue;
                for (int i=0;i<pokemons.Count;i++)
                {
                    if (pokemons[i] > pokemonValue) pokemons[i] -= pokemonValue;
                    else if (pokemons[i] <= pokemonValue) pokemons[i] += pokemonValue;
                }
            }
            Console.WriteLine(sum);
        }
    }
}
