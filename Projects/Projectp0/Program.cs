using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Projectp0
{
    class Program
    {
        
        
        static void Main(string[] args)
        {
            
            
            
            
            Console.WriteLine("Hello, customer! What is your first name? ");
            string firstName = Console.ReadLine();
            
            Console.WriteLine("Cool! Last name?");
            string lastName = Console.ReadLine();

            Customer c = new Customer(firstName, lastName);

            List<Customer> shoppers = new List<Customer>();
            Console.WriteLine($"Name stored as: {lastName} {firstName}");
            Console.WriteLine(shoppers);
            
            // this will save the name as a new customer
            StoreLogic newCust = new StoreLogic(firstName, lastName);


           // do
           // {
                Stores stores = new Stores();

                List<string> storeList = new List<string>();
                storeList.Add("1.) Kroger");
                storeList.Add("2.) Best Buy");
                storeList.Add("3.) Guitar Center");

                StoreChoice cusChoice = StoreChoice.invalid;

           // while (cusChoice != StoreChoice.invalid)
            //{

                do
                {
                    Console.WriteLine("Now, " + firstName + " which store would you like to shop from today?");


                    //interate through store list to display to user
                    foreach (string store in storeList)
                    {
                        Console.WriteLine(store);
                    }

                    string cusInput = Console.ReadLine();
                    cusChoice = newCust.storeGetCustomerChoice(cusInput);

                    if (cusChoice == StoreChoice.invalid)
                    {
                        Console.WriteLine("Please select a store option.");
                    }

                    Console.WriteLine($"Customer entered: {cusInput}");
                } while (cusChoice == StoreChoice.invalid);


                if(cusChoice == StoreChoice.Kroger)
                {
                    Console.WriteLine("You choose to shop at Kroger!");
                }
                else if (cusChoice == StoreChoice.BestBuy)
                {


                }
                else if (cusChoice == StoreChoice.GuitarCenter)
                {


                }


           // }
               

                

            //}







        }
    }
}
