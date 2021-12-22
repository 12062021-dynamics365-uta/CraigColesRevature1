using System;
using System.Data.SqlClient;
using Domain;
using Storage;
using System.Collections.Generic;


namespace NewP0
{
    internal class Program 
    {
        public static int CartItemID { get; set; }
        public static int LineID { get; set; }
        public static int CartID { get;  set; }
        public static int ProductID { get; set; }
        public static int ItemQuantity { get; set; }
        public static float ItemTotal { get; set; }
        
        
        
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

                    //Must be worked on for p1 project
                    //ConnectionString is being lost?
                    DatabaseAccess newCustID = new DatabaseAccess();
                    int CustomerID = newCustID.getNextCustomerID();
                    DatabaseAccess newLogin = new DatabaseAccess();
                    newLogin.addCustomer(CustomerID, newFirstName, newLastName, newLoginName);

                    exitLogin = true;
                    
                }
                else
                {
                    Console.WriteLine("Please type a valid response");
                    exitLogin = false;
                }

             } while (!exitLogin);


            bool exitStoreLocationSelection = false;

            do
            {
                //Ask user which location
                Console.WriteLine("Welcome, which location would you like to shop from?\n");
                DatabaseAccess storeLocation = new DatabaseAccess();
                storeLocation.getStores();

                //user location input
                string storeSelect = Console.ReadLine();
                int convertNumber = -1;
                bool convertBool = false;
                convertBool = Int32.TryParse(storeSelect, out convertNumber);

                if (convertNumber > 0)
                {
                    
                    DatabaseAccess displayProducts1 = new DatabaseAccess();
                    //Display products to customer
                    displayProducts1.displayProducts1(convertNumber);
                }
                else
                {
                    Console.WriteLine("Invalid input. Try again!");
                }
            } while (exitStoreLocationSelection);



            //Asking user what items they would like to add to their cart.



            DataManager dm = new DataManager();
            do
            {
                //Ask user what item they would like to add to their cart
                Console.Write("Select items to add to your cart: (Type the corresponding numeric value)");
                int itemSelect = Convert.ToInt32(Console.ReadLine());
                
                List<CartItems> cartItems = dm.addItemToCart();
               
                //ShoppingCart.addItemToCart(cartItemID, LineID, CartID, ProductID, ItemQuantity, ItemTotal);

                if (itemSelect == 1)
                {
                    //create new cart
                    //ShoppingCart.newCart();
                    //add item to cart

                    


                }
                else if (itemSelect == 2)
                {
                    
                }
                else if (itemSelect == 3)
                {
                    
                }
                else
                {
                    Console.WriteLine("Invalid input.");
                }

                

            } while (cart.Count <= 50);
            ShoppingCart addItem = new ShoppingCart();
           
            

            //do
           // {
                
                
                
                
                


           // if (itemSelect == itemID)?
           // {
               // selectItem.addItemToCart();
              //  itemSelect = itemID;
           // }
            //else
            // }
            // while ();










        }
    }
}
