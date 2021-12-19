using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projectp0
{
    internal class StoreLogic : Store_App
    {
        public List<Customer> customers; //All new customers
        List<Stores> stores; //all the stores
        internal Stores store;
        


        public StoreLogic()
        {
            customers = new List<Customer>();

        }
    

       

        //make access modifiers public for interface
        internal StoreChoice storeGetCustomerChoice(string choice)
        {
            int choiceNumber = 0;
            bool isConverted = false;
            isConverted = Int32.TryParse(choice, out choiceNumber);
            if (!isConverted || choiceNumber < 1 || choiceNumber > 3)
            {
                return StoreChoice.invalid;
            }
            return (StoreChoice)choiceNumber;
        }

        public void startNewSession()
        {
            //this.currentSesh = null;
            //this.currentcustomer = null;
        }


        //This will save the current shopping session
        public void SaveOrder()
        {

        }

        

    }

    internal class DataManager
    {
     
        

    }



}
