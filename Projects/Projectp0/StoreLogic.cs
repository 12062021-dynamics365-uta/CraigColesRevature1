using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projectp0
{
    internal class StoreLogic : Store_App
    {
        List<Customer> customers; //All new customers
        List<Stores> stores; //all the stores
        internal Stores store;
        private Customer currentLoggedCustomer;


        public StoreLogic()
        {
            customers = new List<Customer>();
        }
        public StoreLogic(string fname, string lname)
        {
            
            
            this.customers = new List<Customer>();// the new customer
            
            this.store = new Stores();//current store 
            Customer newCustomer = new Customer(fname, lname); //creates new customer
            this.customers.Add(newCustomer); //this will add the new customer to the list
            store.storeName1 = "Kroger";
            store.storeName1 = "Best Buy";
            store.storeName1 = "Guitar Center";
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

        //make access modifiers public for interface
        internal StoreChoice storeGetCustomerChoice(string choice)
        {
            int choiceNumber = 0;
            bool isConverted = false;



        }

    }

    
}
