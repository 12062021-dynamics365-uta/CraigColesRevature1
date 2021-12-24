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
        public void Login(string first, string last)
        {
            /*foreach(Customer p in customers)
            {
                if(p.FirstName == custFName && p.LastName == custLName)
                {

                    this.currentLoggedCustomer = p;
                }
            }*/

            //linked library 
            Customer c1 = customers.Where(c1 => c1.FirstName == first && c1.LastName == last).FirstOrDefault();
            if (c1 == null)
            {
                Customer c = new Customer(first, last);
                this.currentLoggedCustomer = c;
                customers.Add(c);

            }
            else
            {
                this.currentLoggedCustomer = c1;
            }

        }

    }
}
