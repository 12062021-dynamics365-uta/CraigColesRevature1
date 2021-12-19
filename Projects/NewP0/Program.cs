using System;
using System.Data.SqlClient;
using Domain;
using Storage;


namespace NewP0
{
    internal class Program 
    {
        static void Main(string[] args)
        {
            
            
            //Welcome Customer

            Console.Write("Hello, Customer!");


            //Login
            bool exitLogin = false;

            do
            {
                Console.WriteLine("Are you any of these individuals? If so Login");
                DatabaseAccess displayCurrentCustomers = new DatabaseAccess();
                displayCurrentCustomers.displayActiveCustomers();
                Console.WriteLine("Login or Create? (Type 1 to login, 2 to create)");
                string logCreate = Console.ReadLine();

                

                if (logCreate == "1")
                {

                    Console.WriteLine("Enter first name");
                    string customerFirstName = Console.ReadLine();
                    Console.WriteLine("Enter last name");
                    string customerLastName = Console.ReadLine();
                    //Save the name as a new customer
                    Customer loginCheck = new Customer(customerFirstName, customerLastName);
                    //check for customer validation
                   // loginCheck.Login(customerFirstName, customerLastName);
                    exitLogin = true;
                }
                else if (logCreate == "2")
                {
                    Console.WriteLine("Enter first name to create anew: ");
                    string newFirstName = Console.ReadLine();
                    Console.WriteLine("Enter last name to create anew: ");
                    string newLastName = Console.ReadLine();

                    string newLoginName = newFirstName + newLastName;
                    DatabaseAccess newLogin = new DatabaseAccess();
                    newLogin.addUser(newFirstName, newLastName, newLoginName);

                    exitLogin = true;
                    
                }
                else
                {
                    Console.WriteLine("Please type a valid response");
                    exitLogin = false;
                }

             } while (!exitLogin);



            //Ask user which location
            Console.WriteLine("Welcome, which location would you like to shop from?\n");
            DatabaseAccess storeLocation = new DatabaseAccess();
            storeLocation.getStores();

            string storeSelect = Console.ReadLine();

            if(storeSelect == "1")
            {
                DatabaseAccess displayProducts1 = new DatabaseAccess();
                displayProducts1.displayProducts1();
            }
            else if(storeSelect == "2")
            {

            }
            else if(storeSelect == "3")
            {

            }

            //Stores stores = new Stores();





            //
            
        }
    }
}
