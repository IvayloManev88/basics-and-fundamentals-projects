using BlackFriday.Models.Contracts;
using BlackFriday.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackFriday.Models
{
    public abstract class User : IUser
    {

        private string userName;

        public string UserName
        {
            get { return userName; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException(ExceptionMessages.UserNameRequired);
                userName = value;
            }
        }



        private bool hasDataAccess;

        public bool HasDataAccess
        {
            get { return hasDataAccess; }
            private set { hasDataAccess = value; }
        }




        private string email;

        public string Email
        {
            get 
            {
                if (!HasDataAccess)
                    return email;
                else return "hidden";
            }
            //here
            private set
            {
                if (string.IsNullOrWhiteSpace(value)&&!HasDataAccess)
                    throw new ArgumentException(ExceptionMessages.EmailRequired);
                
                else  email = value; 

            }
        }



        public User(string userName, string email, bool hasDataAccess)
        {
            
            UserName = userName;

         
                Email = email;

            HasDataAccess = hasDataAccess;

        }



        public override string ToString()

        {
            string userType = this.GetType().Name;
            return $"{UserName} - Status: {userType}, Contact Info: {Email}";
        }

    }
}
