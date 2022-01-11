using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewP0
{
    public class Customer
    {
        public List<Customer> customers; //All new customers

        public int CustomerID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string LoginName { get; set; }

        public Customer currentLoggedCustomer;


        public Customer(string first, string last)
        {
            first = FirstName;
            last = LastName;
        }

        internal bool Login()
        {
            throw new NotImplementedException();
        }

        //will see if the logged in customer already exists
        //if so, will assign that player to currentLoggedInPlayer
        

    }
}
