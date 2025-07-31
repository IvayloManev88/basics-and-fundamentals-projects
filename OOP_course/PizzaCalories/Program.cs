namespace PizzaCalories
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Pizza pizza = ReadPizza();
                pizza.Dough = ReadDough();
               
                
                foreach (Topping topping in ReadTopping())
                    pizza.AddTopping(topping);

                Console.WriteLine($"{pizza.Name} - {pizza.Calories:f2} Calories.");

            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }


        private static Pizza ReadPizza()
        {
            string [] data = Console.ReadLine().Split(" ");
            if (data[0] != "Pizza") throw new InvalidOperationException("Unexpected pizza input");

            return new Pizza(data[1]);

        }
        private static Dough ReadDough()
        {
            string[] input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
            if (input[0] != "Dough") throw new InvalidOperationException("Unexpected dough input");

            return new Dough(input[1], input[2], double.Parse(input[3]));
         }

        private static IEnumerable<Topping> ReadTopping()
        {
            string command;
            
            while ((command = Console.ReadLine()) != "END")
            {
                string[] input = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (input[0] != "Topping") throw new InvalidOperationException("Unexpected topping input");

                yield return new Topping(input[1], double.Parse(input[2]));
                
            }
            

         
        }
    }
}
