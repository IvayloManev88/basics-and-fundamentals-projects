namespace _09.PadawanEquipment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float budget = float.Parse(Console.ReadLine());
            int countOfStudents = int.Parse(Console.ReadLine());
            float priceLightSaber = float.Parse(Console.ReadLine());
            float priceRobe = float.Parse(Console.ReadLine());
            float priceBelt = float.Parse(Console.ReadLine());
            int lightSaberCount = (int)Math.Ceiling(countOfStudents * 1.1);
            int beltCount = countOfStudents - (countOfStudents/6);
            float totalPrice = beltCount * priceBelt + priceRobe * countOfStudents + priceLightSaber * lightSaberCount;
            if (budget - totalPrice >=0)
            {
                Console.WriteLine($"The money is enough - it would cost {totalPrice:f2}lv.");
            }
            else Console.WriteLine($"John will need {(totalPrice- budget):f2}lv more.");
        }
    }
}
