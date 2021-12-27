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
            DataManager dm = new DataManager(dbAccess);

            //Welcome Customer

            Console.Write("Hello, Customer! Welcome to Guitar Center Central! Take a moment to log in, will ya? \n");


            //Login
            bool notActiveCustomer = false;
            bool exitLogin = false;
            int CustomerID = 1;
            do
            {
                do
                {
                    Console.WriteLine("Are you any of these rockin' customers? If so Login \n");
                    DatabaseAccess displayCurrentCustomers = new DatabaseAccess();
                    displayCurrentCustomers.displayActiveCustomers();
                    Console.WriteLine("Login or Create? (Type 1 to login, 2 to create) \n");
                    string logCreate = Console.ReadLine();


                    if (logCreate == "1")
                    {

                        Console.Write("Enter first name: ");
                        string customerFirstName = Console.ReadLine();
                        Console.Write("Enter last name: ");
                        string customerLastName = Console.ReadLine();
                        //Save the name as a new customer
                        Customer loginCheck = new Customer(customerFirstName, customerLastName);
                        DatabaseAccess activeCustomer = new DatabaseAccess();
                        CustomerID = activeCustomer.getActiveCustomerID(customerFirstName, customerLastName);
                        Console.WriteLine(CustomerID);

                        if (CustomerID == 0)
                        {
                            Console.WriteLine("That name isn't in our database, please create a new account.");
                            notActiveCustomer = false;
                        }
                        else
                        {
                            //check for customer validation
                            // loginCheck.Login(customerFirstName, customerLastName);
                            exitLogin = true;
                        }
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
            } while (notActiveCustomer);

            bool firstMenu = true;
            while (firstMenu) 
            {
                Console.WriteLine("\n What would you like to do next? \n " +
                                  "1.) Start shopping! \n " +
                                  "2.) View orders per store \n " +
                                  "3.) View all past orders \n ");
                string customerStart = (Console.ReadLine().ToString());

                if (customerStart == "1")
                {
                    break;

                }
                else if (customerStart == "2")
                {
                    
                    Console.WriteLine("Pick a location to look up past orders: " +
                                       "(Enter the store ID#)");
                    dbAccess.getStores();
                    //customer's choice of store to view past orders
                    string CustomerStorePastOrders = (Console.ReadLine().ToString());
                   
                    if (CustomerStorePastOrders == "1") 
                    {
                        
                        //past orders of store location 1.
                        dbAccess.viewPastOrdersPerStore(CustomerID, 1);
                    }
                    else if (CustomerStorePastOrders == "2")
                    {
                        
                        //past orders of store location 2.
                        dbAccess.viewPastOrdersPerStore(CustomerID, 2);
                    }
                    else if (CustomerStorePastOrders == "3")
                    {
                        
                        //past orders of store location 3.
                        dbAccess.viewPastOrdersPerStore(CustomerID, 3);
                    }
                    else
                    {
                        Console.WriteLine("Enter a valid StoreID number,");
                    }

                }
                else if (customerStart == "3")
                {
                    dbAccess.viewPastOrders(CustomerID); 
                }
            } 




            bool exitStoreLocationSelection = false;
            int storeConfirm = 0;
            do
            {
                //Ask user which location
                Console.WriteLine("Welcome, which location would you like to shop from? \n" +
                                  "{Enter the Store ID#)");
                DatabaseAccess storeLocation = new DatabaseAccess();
                
                //calls stores from database access to display to the customer
                storeLocation.getStores();

                //user location input
                string storeSelect = Console.ReadLine();
                int convertNumber = -1;
                bool convertBool = false;
                convertBool = Int32.TryParse(storeSelect, out convertNumber);

                storeConfirm = Convert.ToInt32(storeSelect);
                if (storeSelect == "1" || storeSelect == "2" || storeSelect == "3")
                {
                    DatabaseAccess displayProducts1 = new DatabaseAccess();
                    
                    //The currentstore from datamanager being set as the customer's input 
                    
                    dm.currentStore.StoreNum = convertNumber;
                    Console.WriteLine("A new cart has been created for you \n");
                    //Loads products from DataManager
                    dm.LoadProducts();
                    
                    foreach(Products p in dm.currentStore.products)
                    {
                        //prints products from selected store to customer
                        Console.WriteLine($"Item ID#: {p.productID} \nProduct: {p.proName} \nCost: ${p.price} \nDescription: {p.ProductDescription} \nQuantity: {p.ProductQuantity} \n");
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

            bool addMoreToCart = false;
            do
            {
                //Ask user what item they would like to add to their cart
                Console.Write("Select an item to add to your cart: (Type the corresponding Item ID number)");
                int itemSelect = Convert.ToInt32(Console.ReadLine());
                Console.Write("How many would you like to add? ");
                int itemQuantity = Convert.ToInt32(Console.ReadLine());



                //List<CartItems> cartItems = dm.addItemToCart();
                if (itemSelect == 0 || itemSelect > 5)
                {
                    Console.WriteLine("Invalid input.");
                }


                


                //ShoppingCart.addItemToCart(cartItemID, LineID, CartID, ProductID, ItemQuantity, ItemTotal);
                int itemCount = 0;
                foreach (Products p in dm.currentStore.products)
                {

                    //if the customers input matches a specific product ID
                    if (itemSelect == p.productID)
                    {
                        //if the customer attemps to order more products than aviable
                        if (itemQuantity <= p.ProductQuantity)
                        {
                            //adds item to cart  //passing productID
                            List<CartItems> cartItems = dm.addItemToCart(CartID, itemSelect, itemQuantity);
                            
                            

                        }
                    }
                }

                

            bool mainMenu = true;
                do
                {
                    //Ask the customer if they would like to add more items to their cart, view cart, delete products
                    Console.WriteLine("What would you like to do next with your order? \n " +
                                       "1.) Add Item \n " +
                                       "2.) View cart \n " +
                                       "3.) Checkout \n " +
                                       "4.) Delete whole cart \n "); //deleteCartItems

                    string nextCartAction = (Console.ReadLine().ToString());

                    if (nextCartAction == "1")
                    {
                        addMoreToCart = false;
                        mainMenu = false;
                        dm.LoadProducts();

                        foreach (Products p in dm.currentStore.products)
                        {
                            //prints products from selected store to customer
                            Console.WriteLine($"ID: {p.productID} \nProduct: {p.proName} \nCost: ${p.price} \nQuantity: {p.ProductQuantity} \n \n ");
                        }
                        Console.WriteLine("Your cart's total: " + dbAccess.calculateCartTotal(CartID) + "\n ");

                        //break;

                    }
                    else if (nextCartAction == "2")
                    {

                        DatabaseAccess viewItems = new DatabaseAccess();
                        viewItems.viewItemsInCart(CartID);
                        Console.WriteLine("\n \nYour cart's total: " + dbAccess.calculateCartTotal(CartID) + "\n ");

                    }
                    else if (nextCartAction == "3")
                    {
                        DatabaseAccess checkout = new DatabaseAccess();
                        //Calculates the cart total
                        decimal CartTotal = checkout.calculateCartTotal(CartID);
                        Console.WriteLine(CartTotal);
                        checkout.updateCartTotal(CartID, CartTotal);
                        //Will save the customer's order
                        checkout.saveOrder(CartID);
                        //Gets the new OrderID 
                        int OrderID = checkout.getOrderIDFromCart(CartID);
                        //Save's the customers ordered items
                        checkout.saveOrderItems(CartID, OrderID);
                        Console.WriteLine($"Order: {OrderID} has been successfully placed. \n ");
                        checkout.displayOrderTotal(OrderID);
                        mainMenu = false;
                        addMoreToCart = true;
                        
                    }
                    else if (nextCartAction == "4")
                    {
                        dbAccess.deleteCartItems(CartID);
                        Console.WriteLine("Cart Wipe out!");
                        dbAccess.deleteCart(CartID);  
                    }
                  
                    else
                    {
                        Console.WriteLine("Invalid option. Try again");

                    }
                }
                while (mainMenu);

            } while (!  addMoreToCart);

                        

                        
                        
                        
                        
                        








        } //main method
                

                        


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










        }//block end of class
    }//end of namespace

