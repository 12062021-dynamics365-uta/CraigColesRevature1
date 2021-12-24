using System;
using System.Data.SqlClient;
using Domain;
using Storage;
using System.Collections.Generic;


namespace NewP0
{
    public class Program 
    {
        public static int CartItemID { get; set; }
        public static int LineID { get; set; }
        public static int CartID { get;  set; }
        public static int ProductID { get; set; }
        public static int ItemQuantity { get; set; }
        public static float ItemTotal { get; set; }

        
        
        
        static void Main(string[] args)
        {
            Mapper mapper = new Mapper();
            DatabaseAccess dbAccess = new DatabaseAccess();
            DataManager dm = new DataManager();

            //Welcome Customer

            Console.Write("Hello, Customer!");


            //Login
            bool exitLogin = false;
            int CustomerID = 1;
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
                    DatabaseAccess activeCustomer = new DatabaseAccess(); 
                    CustomerID = activeCustomer.getActiveCustomerID(customerFirstName, customerLastName);
                    Console.WriteLine(CustomerID);
                    
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
                    CustomerID = newCustID.getNextCustomerID();
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
            int storeConfirm = 0;
            do
            {
                //Ask user which location
                Console.WriteLine("Welcome, which location would you like to shop from?\n");
                DatabaseAccess storeLocation = new DatabaseAccess();
                
                //calls stores from database access to display to the customer
                storeLocation.getStores();

                //user location input
                string storeSelect = Console.ReadLine();
                int convertNumber = -1;
                bool convertBool = false;
                convertBool = Int32.TryParse(storeSelect, out convertNumber);

                storeConfirm = Convert.ToInt32(storeSelect);
                if (convertNumber > 0)
                {
                    DatabaseAccess displayProducts1 = new DatabaseAccess();
                    
                    //The currentstore from datamanager being set as the customer's input 
                    
                    dm.currentStore.StoreNum = convertNumber;
                    Console.WriteLine("A new cart has been created for you");
                    //Loads products from DataManager
                    dm.LoadProducts();
                    
                    foreach(Products p in dm.currentStore.products)
                    {
                        //prints products from selected store to customer
                        Console.WriteLine($"{p.productID} \n {p.proName} \n {p.price} \n {p.ProductQuantity}");
                    }
                }
                    
                else
                {
                    Console.WriteLine("Invalid input. Try again!");
                }
            } while (exitStoreLocationSelection);


            //adds a cart after the customer selects a location
           
            CartID = dm.addCart(storeConfirm, CustomerID);
            //checking current cartID
            Console.WriteLine($"Your cart ID is: {CartID}");

            //int CartID = Convert.ToInt32(Console.ReadLine());


            // do
            // {
            //Ask user what item they would like to add to their cart
            Console.Write("Select items to add to your cart: (Type the corresponding numeric value)");
                int itemSelect = Convert.ToInt32(Console.ReadLine());
            Console.Write("How many would you like to add? ");
                int itemQuantity = Convert.ToInt32(Console.ReadLine());
                

                
                //List<CartItems> cartItems = dm.addItemToCart();

                

                //ShoppingCart.addItemToCart(cartItemID, LineID, CartID, ProductID, ItemQuantity, ItemTotal);
                int itemCount = 0;
                foreach (Products p in dm.currentStore.products) {

                    //if the customers input matches a specific product ID
                    if (itemSelect == p.productID)
                    {
                        //if the customer attemps to order more products than aviable
                        if (itemQuantity <= p.ProductQuantity)
                        {
                            //adds item to cart  //passing productID
                            List<CartItems> cartItems = dm.addItemToCart(CartID, itemSelect, itemQuantity);
                            itemCount++;
                        }
                    }
                }

                    if(itemCount == 0)
                    {
                        Console.WriteLine("Invalid input.");
                    }
                    DatabaseAccess viewItems = new DatabaseAccess();
                    viewItems.viewItemsInCart(CartID);
                        


            //} while (cartItems.Count <= 50);
            
                    











           
            

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
