using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Data.SqlClient;

namespace Projectp0
{
    class Program
    {
        
        
        static void Main(string[] args)
        {

            Class1 test = new Class1();
            test.connectSQL();
            test.something();

            StoreLogic checkChoice = new StoreLogic();
            Products p = new Products(1);
            bool logout = false;


            //log in here?? 
            //do
            logout = false;
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
                storeList.Add("1.) Saginaw, MI ");
                storeList.Add("2.) Southfield, MI");
                storeList.Add("3.) Detroit, MI");

                StoreChoice cusChoice = StoreChoice.invalid;

           // while (cusChoice != StoreChoice.invalid)
            //{

                do
                {
                    Console.WriteLine("Now, " + firstName + " which Guitar Center location would you like to shop from today?");
                    

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


                if(cusChoice == StoreChoice.Saginaw)
                {
                    Console.WriteLine("You choose to shop at the Saginaw Location!");
                    p.getSaginawProducts();
                }
                else if (cusChoice == StoreChoice.Southfield)
                {
                    Console.WriteLine("Best Buy it is!");
                    

                }
                else if (cusChoice == StoreChoice.Detriot)
                {
                    

                }


           // }
               

                

            //}







        }
    }
}
