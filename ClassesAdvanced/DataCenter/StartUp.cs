using System.ComponentModel;

namespace DataCenter
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //Initialize new repository (Rack) with slots for 8 servers
            Rack rack = new(8);

            //Initialize 10 servers
            Server server1 = new("SN001", "Dell PowerEdge T340", 100, 450);
            Server server2 = new("SN002", "HP Proliant DL360", 200, 220);
            Server server3 = new("SN003", "Dell PowerEdge T340", 250, 350);
            Server server4 = new("SN004", "IBM Power System S922", 220, 330);
            Server server5 = new("SN005", "Lenovo ThinkSystem SR650", 250, 550);
            Server server6 = new("SN006", "HPE Synergy 480 Gen10", 80, 180);
            Server server7 = new("SN007", "Fujitsu PRIMERGY RX2530 M5", 120, 250);
            Server server8 = new("SN008", "Dell EMC PowerEdge R740xd", 160, 380);
            Server server9 = new("SN006", "Supermicro SuperServer 1029P-WTR", 150, 280);
            Server server10 = new("SN009", "Cisco UCS B200 M5", 180, 400);

        }
    }
}
