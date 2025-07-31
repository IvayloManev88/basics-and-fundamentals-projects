using System.Text;

namespace EstateAgency
{
    public class EstateAgency
    {
        private int _capacity;
        private readonly List<RealEstate> _realEstates;
       


        public EstateAgency(int capacity)
        {
            _capacity = capacity;
            _realEstates = new List<RealEstate>();
        }

        public int Count
        {
            get { return _realEstates.Count; }
           
        }


        public List<RealEstate> RealEstates
        {
            get { return _realEstates; }

        }


        public int Capacity
        {
            get { return _capacity; }
            set { _capacity = value; }
        }
        public void AddRealEstate(RealEstate realEstate)
        {
            if (Count < Capacity)
            {
                if (!_realEstates.Any(re => re.Address == realEstate.Address)) _realEstates.Add(realEstate);

            }
        }
        public bool RemoveRealEstate(string address)
        {
            RealEstate removedRealestate = _realEstates.FirstOrDefault(re => re.Address == address);
            if (removedRealestate != null)
            {
                _realEstates.Remove(removedRealestate);
                return true;

            }
            return false;
        }
        public List<RealEstate> GetRealEstates(string postalCode)
        {
            return _realEstates.Where(re=>re.PostalCode == postalCode).ToList();
        }

        public RealEstate GetCheapest()
        {
            return _realEstates.OrderBy(re=> re.Price).First();
        }

        public double GetLargest()
        {
            return _realEstates.Max(re => re.Size);
        }
        public string EstateReport()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Real estates available:");
            foreach (RealEstate realEstate in _realEstates)
            {
                stringBuilder.AppendLine(realEstate.ToString());
            }
            return stringBuilder.ToString().Trim();
        }

    }
}
