namespace DataCenter
{
    public class Server
    {
        public Server(string serial, string model, int capacity, int power) 
        {
            SerialNumber = serial;
            Model = model;
            Capacity = capacity;
            PowerUsage = power;
        }
        public string SerialNumber { get; set; }
        public string Model { get; set; }
        public int Capacity { get; set; }
        public int PowerUsage { get; set; }
        public override string ToString() => $"Server {SerialNumber}: {Model}, {Capacity}TB, {PowerUsage}W";
        
    }
}
