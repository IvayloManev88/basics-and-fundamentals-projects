namespace _02_Mid_Exam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> coffees = Console.ReadLine().Split().ToList();
            int numberOfCommands = int.Parse(Console.ReadLine());
            for (int i = 0; i< numberOfCommands; i++) 
                {
                    List <string> inputs = Console.ReadLine().Split().ToList();
                    switch (inputs[0])
                     {
                          case "Include":
                            coffees.Add(inputs[1]);
                          break;

                          case "Remove":
                           int numbersToRemove = int.Parse(inputs[2]);
                             if (numbersToRemove <= coffees.Count)
                             {
                            if (inputs[1] == "first")
                            {
                                coffees.RemoveRange(0, numbersToRemove);
                            }
                            else if (inputs[1] == "last")
                            {
                                //tuk
                                coffees.RemoveRange(coffees.Count - numbersToRemove, numbersToRemove);
                            }
                             }
                          break;
                         case "Prefer":
                        int index1=int.Parse(inputs[1]);
                        int index2=int.Parse(inputs[2]);
                        if (index1>=0 && index1<coffees.Count && index2>=0 && index2<coffees.Count)
                        {
                            string helpValue = coffees[index1];
                            coffees[index1] = coffees[index2];
                            coffees[index2] = helpValue;
                        }
                        break;
                    case "Reverse":
                        coffees.Reverse();
                        break;

                }
                          
            }
            Console.WriteLine("Coffees:");
            Console.WriteLine(string.Join(" ", coffees));
        }
        public bool IsIndexListCorrect(List<string> list, int index)
        {
            bool isCorrect = false;
            if (index >= 0 && index < list.Count)
            {
                isCorrect = true;
            }
            return isCorrect;
        }
    }

}
