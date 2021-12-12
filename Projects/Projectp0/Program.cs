using System;
using System.Collections.Generic;

namespace Projectp0
{
    class Program
    {
        
        
        static void Main(string[] args)
        {
            
            Console.WriteLine("Hello, customer! What is your name? ");
            string firstName = Console.ReadLine();
            string Name = firstName;

            List<Customer> shoppers = new List<Customer>();
            Customer c = new Customer(Name);
            shoppers.Add(c);

            Console.WriteLine("Hello, " + firstName + " which store would you like to shop from today?");
            
            string storeName = Console.ReadLine();



           

            

        }
    }
}
