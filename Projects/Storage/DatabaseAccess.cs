using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Domain;

namespace Storage
{
    public class DatabaseAccess : IDatabaseAccess
    {
        string database = "Data source = DESKTOP-58I9UJJ\\SQLEXPRESS; initial Catalog = ProjectP0; integrated security = true";
        public SqlConnection connect;
        public readonly IMapper _mapper;

        public DatabaseAccess()
        {
            this.connect = new SqlConnection(database);
            //open
            //this._mapper
        }


        public void displayActiveCustomers()
        {
            string query = "SELECT LoginName FROM Customers;";

            using (connect)
            {
                //Opening the SqlConnection
                connect.Open();
                        //Creating SQL command to then read and display to active customers to the current user              
                using (SqlCommand command = new SqlCommand(query, connect))
                {
                    using (SqlDataReader dataRead = command.ExecuteReader())
                    {
                        while (dataRead.Read())
                        {
                            for (int i = 0; i < dataRead.FieldCount; i++)
                            {
                                Console.WriteLine(dataRead.GetValue(i));
                            }
                            Console.WriteLine();
                        }
                    }

                }

            }
        }

        internal List<CartItems> addItemToCart()
        {
            throw new NotImplementedException();
        }

        public int getNextCustomerID()
        {
            int CustomerID = -1;
            //SqlCommand command;
            //command = connect.CreateCommand();
            string query = "SELECT MAX(CustomerID) + 1 as MaxID FROM Customers;";
            //command.ExecuteNonQuery();

            using (connect)
            {
                connect.Open();
                using (SqlCommand command = new SqlCommand(query, connect))
                {
                    using (SqlDataReader dataRead = command.ExecuteReader())
                    {
                        while (dataRead.Read())
                        {
                            for (int i = 0; i < dataRead.FieldCount; i++)
                            {

                                //bool convertBool = false;
                                CustomerID = int.Parse(dataRead["MaxID"].ToString()); 
                                //convertBool = Int32.TryParse((Int32)dr, out CustomerID);

                            }
                        }
                    }

                }

            }
            return CustomerID;
        }
        

        public void addCustomer(int CustomerID, string FirstName, string LastName, string LoginName)
        {

            //passing in new customer id from nextCustomerID method
            //int CustomerID = getNextCustomerID();
            SqlCommand command;
            command = connect.CreateCommand();
            
            if (CustomerID > 0)
            {

                string query = "INSERT INTO Customers(CustomerID, FirstName, LastName, LoginName) values('" + CustomerID + "', '" + FirstName + "', '" + LastName + "', '" + LoginName + "');";
                //command.ExecuteNonQuery();

                using (connect)
                {
                    connect.Open();
                    using (command = new SqlCommand(query, connect))
                    {
                        using (SqlDataReader dataRead = command.ExecuteReader())
                        {
                            while (dataRead.Read())
                            {
                                for (int i = 0; i < dataRead.FieldCount; i++)
                                {
                                    Console.WriteLine(dataRead.GetValue(i));

                                }
                                Console.WriteLine();
                            }
                        }

                    }

                }
            }
            else
            {
                Console.WriteLine("Error creating new customer.");
            }



        }


        public void getStores()
        {
          string query = "SELECT StoreNum, StoreLocation FROM Stores;";

                using (connect)
                {
                    connect.Open();
                    using (SqlCommand command = new SqlCommand(query, connect))
                    {
                        using (SqlDataReader dataRead = command.ExecuteReader())
                        {
                            while (dataRead.Read())
                            {
                                for (int i = 0; i < dataRead.FieldCount; i++)
                                {
                                    Console.WriteLine(dataRead.GetValue(i));
                                }
                                Console.WriteLine();
                            }
                        }

                    }
                
                }

        }

        public void displayProducts1(int StoreNum)
        {
            int productCount = 1;
            
            string query = "SELECT ProductName, 'Cost: ', Price, 'Quantity: ', ProductQuantity  " +
                           "FROM Inventory " +
                           "LEFT OUTER JOIN Stores " +
                           "ON Stores.StoreNum = Inventory.StoreNum " +
                           "LEFT OUTER JOIN Products " +
                           "ON Products.ProductID = Inventory.ProductID " +
                           "WHERE Inventory.StoreNum = " + StoreNum + " ;";

            using (connect)
            {
                connect.Open();
                using (SqlCommand command = new SqlCommand(query, connect))
                {
                    using (SqlDataReader productReader = command.ExecuteReader())
                    {
                        while (productReader.Read())
                        {
                            for(int i = 0; i < productReader.FieldCount; i++)
                            {
                                
                                Console.Write((productReader.GetValue(i)) + "\n");
                            }
                            Console.WriteLine();
                        }
                    }
                }
            }
        }

        public void newCart(int CartID, int StoreID, int CustomerID, float CartTotal)
        {
            string query = "INSERT INTO ShoppingCart(CartID, StoreID, CustomerID, CartTotal) values('" + CartID + "', '" + StoreID + "', '" + CustomerID + "', '" + CartTotal + "')";
        }

        public void deleteCart(int CartID)
        {
            string query = "DELETE ShoppingCart WHERE CartID = " + CartID + " ;";
        }




        public List<CartItems> addItemToCart(int CartItemID, int LineID, int CartID, int ProductID, int ItemQuantity, float ItemTotal)
        {

            
                string query = "INSERT INTO ShoppingCartItems(CartItemID, LineID, CartID, ProductID, ItemQuantity, ItemTotal) values('" + CartItemID + "', '" + LineID + "', '" + CartID + "', '" + ProductID + "', '" + ItemQuantity + "', '" + ItemTotal + "')";
                List<CartItems> cartItems = new List<CartItems>();
                using (SqlCommand command = new SqlCommand(query, this.connect))
                {
                    SqlDataReader dataReader = command.ExecuteReader();
                    cartItems = this._mapper.EntityToCartItem(dataReader);
                    this.connect.Close();
                }
            return cartItems;
            /*if (CartItemID > 0)
            {
                //int CartItemID, int LineID, int CartID, int ProductID, int ItemQuantity, float ItemTota
                using (connect)
                {
                    connect.Open();
                    using (SqlCommand command = new SqlCommand(query, connect))
                    {
                        using (SqlDataReader dataRead = command.ExecuteReader())
                        {
                            while (dataRead.Read())
                            {
                                for (int i = 0; i < dataRead.FieldCount; i++)
                                {

                                    Console.WriteLine(dataRead.GetValue(i));
                                    Console.WriteLine("Your selection has been aded to the cart.");

                                }
                            }
                        }

                    }

                }


            }
            else
            {
                Console.WriteLine("Error");
            }
            return 0;*/



        }

        public void changeQuantityInCart(int CartItemID, int ItemQuantity, float ItemTotal)
        {
            string query = "UPDATE ShoppingCartItems SET ItemQuantity = " + ItemQuantity + ", ItemTotal = " + ItemTotal + " " +
                " WHERE CartItemID = " + CartItemID + " ;";
        }

        //delete foreign keys before primary deleteCart
        public void deleteCartItems(int CartID)
        {
            string query = "DELETE ShoppingCartItems WHERE CartID = " + CartID + " ;";
        }

        public void viewCart(int CartID)
        {


            string query = "SELECT StoreLocation, CustomerName, ' Total: ', CartTotal" +
                           "FROM ShoppingCart " +
                           "LEFT OUTER JOIN Stores " +
                           "ON Stores.StoreNum = ShoppingCart.StoreNum " +
                           "LEFT OUTER JOIN Customers " +
                           "ON Customers.CustomerID = ShoppingCart.CustomerID " +
                           "WHERE CartID = " + CartID + " ;";
        }

        public void viewItemsInCart(int CartID)
        {
            string query = "SELECT LineID, ProductName, ' Quantity: ', ItemQuantity, ' Total: ', ItemTotal" +
                           "FROM ShoppingCartItems " +
                           "LEFT OUTER JOIN Products " +
                           "ON Products.ProductID = ShoppingCartItems.ProductID " +
                           "WHERE CartID = " + CartID +
                           "ORDER BY LineID ;";
        }


    }
    
}
