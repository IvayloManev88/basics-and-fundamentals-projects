namespace Animals
{
    public class StartUp
    {
        static void Main()
        {
            string animalType = string.Empty;
            List<Animal> animals = new List<Animal>();
            while ((animalType = Console.ReadLine()) != "Beast!")
            {
                string[] parameters = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = parameters[0];
                int age = int.Parse(parameters[1]);
                string gender = parameters.Length > 2 ? parameters[2] : null;


                if (animalType == "Cat")
                {
                    
                    Cat currentCat = new Cat(name, age, gender);
                    animals.Add(currentCat);
                }
                else if (animalType == "Dog")
                {
                    
                    Dog currentDog = new Dog(name, age, gender);
                    animals.Add(currentDog);
                }
                else if (animalType == "Frog")
                {
                   
                    Frog currentFrog = new Frog(name, age, gender);
                    animals.Add(currentFrog);

                }
                else if (animalType == "Tomcat")
                {
                   
                    Tomcat tomcat = new Tomcat(name, age);
                    animals.Add(tomcat);
                }
                else if (animalType == "Kitten")
                {
                    
                    Kitten kitten = new Kitten(name, age);
                    animals.Add(kitten);
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }

            }
            foreach (Animal animal in animals)
            {
                Console.WriteLine(animal);
                Console.WriteLine(animal.ProduceSound());
            }


        }
        
    }
}
