using System.Text;

namespace DataCenter
{
    public class Rack
    {
        public Rack(int slots)
        {
            Slots = slots;
            Servers = new List<Server>();
        }
        public int Slots { get; set; }
        public List<Server> Servers { get; set; }
        public int GetCount => Servers.Count;

        public void AddServer(Server server)
        {
            if (this.GetCount < this.Slots)
            {
                if (!this.Servers.Any(s => s.SerialNumber == server.SerialNumber))
                {
                    Servers.Add(server);
                }
            }

        }
        public bool RemoveServer(string serialNumber)
        {
            Server server = Servers.FirstOrDefault(s => s.SerialNumber == serialNumber);
            if (server != null)
            {
                Servers.Remove(server);
                return true;
            }
            return false;
        }
        public string GetHighestPowerUsage()
        {
            int maxPower = this.Servers.Max(s => s.PowerUsage);
            Server highestPowerServer = this.Servers.FirstOrDefault(s => s.PowerUsage == maxPower);
            return highestPowerServer.ToString();
        }
        public int GetTotalCapacity()
        {
            int totalCapacity = Servers.Sum(s => s.Capacity);
            return totalCapacity;
        }
        public string DeviceManager()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.GetCount} servers operating:");
            foreach (Server server in Servers)
            {
                sb.AppendLine(server.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
