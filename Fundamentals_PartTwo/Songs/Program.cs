namespace Songs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int songCounter=int.Parse(Console.ReadLine());
            List<Songs> SongList = new();
            for (int i=1; i<= songCounter;i++)
            {
                List<string> inputs = Console.ReadLine().Split("_").ToList();
                Songs song = new Songs(inputs[0], inputs[1], inputs[2]);
                SongList.Add(song);

            }
            string printTypes = Console.ReadLine();
            if (printTypes =="all")
            {
                foreach (Songs s in SongList)
                {
                    Console.WriteLine(s.Name);
                }
            }
            else
            {
                foreach (Songs s in SongList)
                {
                    if (s.TypeList== printTypes)
                    Console.WriteLine(s.Name);
                }
            }
        }
        
    }

    public class Songs
    {
        public Songs (string typeList, string name, string time)
        {
            TypeList= typeList;
            Name= name;
            Time= time;
        }
        public string TypeList { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }
    }
}
