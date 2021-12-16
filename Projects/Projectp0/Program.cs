using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Projectp0
{
    class Program
    {
        
        
        static void Main(string[] args)
        {

            StoreLogic checkChoice = new StoreLogic();
            Products p = new Products();
            
            
            Console.WriteLine("Hello, customer! What is your first name? ");
            string firstName = Console.ReadLine();
            
            Console.WriteLine("Cool! Last name?");
            string lastName = Console.ReadLine();

            Customer c = new Customer(firstName, lastName);

            //List<Customer> shoppers = new List<Customer>();
           
            //logging new customer to linked library
            //Console.WriteLine($"Name stored as: {lastName}, {firstName}");

            



            // this will save the name as a new customer
            Customer newCust = new Customer(firstName, lastName);
            newCust.saveCustomer(firstName, lastName);


           /* Console.WriteLine("Hello, customer! What is your first name? ");
            string firstName2 = Console.ReadLine();

            Console.WriteLine("Cool! Last name?");
            string lastName2 = Console.ReadLine();
            Customer newCust2 = new Customer(firstName2, lastName2);
            newCust2.saveCustomer(firstName2, lastName2);*/


            //foreach (var tempCust in )
            // {
            //    Console.WriteLine();
            // }

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
                    cusChoice = checkChoice.storeGetCustomerChoice(cusInput);

                    if (cusChoice == StoreChoice.invalid)
                    {
                        Console.WriteLine("Please select a store option.");
                    }

                    Console.WriteLine($"Customer entered: {cusInput}");
                } while (cusChoice == StoreChoice.invalid);


                if(cusChoice == StoreChoice.Kroger)
                {
                    Console.WriteLine("You choose to shop at Kroger!");
                    p.getProducts();
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
