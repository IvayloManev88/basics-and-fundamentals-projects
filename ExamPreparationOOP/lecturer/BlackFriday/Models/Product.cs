using BlackFriday.Models.Contracts;
using BlackFriday.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackFriday.Models
{
    public abstract class Product : IProduct
    {
        private string productName;
        private double basePrice;
        private  double blackFridayPrice;
        public string ProductName
        {
            get { return productName; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(ExceptionMessages.ProductNameRequired);

                productName = value; 
            }
        }

       

        public double BasePrice
        {
            get { return basePrice; }
            private  set 
            {
                if (value <= 0)
                    throw new ArgumentException(ExceptionMessages.ProductPriceConstraints);
                basePrice = value; 
            }  
        }


        public virtual double BlackFridayPrice
        {
            get { return blackFridayPrice; }
            protected set { blackFridayPrice = value; }
            
        }

        private bool isSold;

        public bool IsSold
        {
            get { return isSold; }
            
        }

       
        public Product(string productName, double basePrice)
        {
            

           ProductName = productName;
            

            BasePrice = basePrice;
            isSold = false;
        }

        public void ToggleStatus() => isSold = !isSold;
        

        public void UpdatePrice(double newPriceValue)
        {
            this.BasePrice = newPriceValue;
        }

        public override string ToString() => $"Product: {this.ProductName}, Price: {this.BasePrice:F2}, You Save: {(this.BasePrice - this.BlackFridayPrice):F2}";

    }
}
