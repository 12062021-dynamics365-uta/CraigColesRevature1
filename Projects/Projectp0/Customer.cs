using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projectp0
{
    internal class Customer
    {
        public List<Customer> customers; //All new customers

        public string FirstName { get; set; }

        public string LastName { get; set; }

        private Customer currentLoggedCustomer;




        public Customer(string first, string last)
        {
            first = FirstName;
            last = LastName;
        }

        public void saveCustomer(string first, string last)
        {


            List<Customer> customers = new List<Customer>();// the new customer list

           
            Customer newCustomer = new Customer(first, last); //creates new customer
            customers.Add(newCustomer); //this will add the new customer to the list

            foreach (var cust in customers)
            {
                Console.WriteLine($"New User: {first} {last} ");
                //Console.WriteLine($" {cust} ");
                
            }
           
        }

        internal bool Login()
        {
            throw new NotImplementedException();
        }

        //will see if the logged in customer already exists
        //if so, will assign that player to currentLoggedInPlayer
        internal void Login(string custFName, string custLName)
        {
            /*foreach(Customer p in customers)
            {
                if(p.FirstName == custFName && p.LastName == custLName)
                {

                    this.currentLoggedCustomer = p;
                }
            }*/

            //linked library 
            Customer c1 = customers.Where(c1 => c1.FirstName == custFName && c1.LastName == custLName).FirstOrDefault();
            if (c1 == null)
            {
                Customer c = new Customer(custFName, custLName);
                this.currentLoggedCustomer = c;
                customers.Add(c);
            }

        }






    }
}
