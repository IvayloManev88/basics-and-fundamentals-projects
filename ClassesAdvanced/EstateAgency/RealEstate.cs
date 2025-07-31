namespace EstateAgency
{
    public class RealEstate
    {
		private string _address;
		private string _postalCode;
		private decimal _price;
		private double _size;

        public RealEstate(string address, string postalCode, decimal price, double size)
        {
            _address = address;
            _postalCode = postalCode;
            _price = price;
            _size = size;
        }

        public double Size
		{
			get { return _size; }
			set { _size = value; }
		}


		public decimal Price
		{
			get { return _price; }
			set { _price = value; }
		}


		public string PostalCode 
		{
			get { return _postalCode; }
			set { _postalCode = value; }
		}

		public string Address 
		{
			get { return _address; }
			set { _address = value; }
		}


		public override string ToString() => $"Address: {this._address}, PostalCode: {this._postalCode}, Price: ${this._price}, Size: {this._size} sq.m.";


    }
}
