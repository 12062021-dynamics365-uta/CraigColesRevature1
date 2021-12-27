using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Domain;
using Models;

namespace Storage
{
    public class DatabaseAccess : IDatabaseAccess
    {
        string database = "Data source = DESKTOP-58I9UJJ\\SQLEXPRESS; initial Catalog = ProjectP0; integrated security = true";
        public readonly SqlConnection connect;
        public readonly IMapper _mapper;

        public DatabaseAccess()
        {
            this.connect = new SqlConnection(this.database);
            connect.Open();
            this._mapper = new Mapper();
            
        }

      

        public void displayActiveCustomers()
        {
            string query = "SELECT LoginName FROM Customers;";

            //using (connect)
            //{
                //Opening the SqlConnection
                //connect.Open();
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
                        dataRead.Close();
                    }

                }

            //}
        }

        public int getActiveCustomerID(string FirstName, string LastName)
        {
            int CustomerID = 0;
            string query = $"SELECT CustomerID FROM Customers WHERE FirstName = '{FirstName}' AND LastName = '{LastName}';";
           
            using (SqlCommand command = new SqlCommand(query, this.connect))
            {
                SqlDataReader dataReader = command.ExecuteReader();
                //CustomerID = this._mapper.EntitytoActiveCustomer(dataReader);
                while (dataReader.Read())
                {
                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        CustomerID = Convert.ToInt32(dataReader[0].ToString());

                    };
                }

                dataReader.Close();
            }
            return CustomerID;


        }
       

        public int getNextCustomerID()
        {
            int CustomerID = -1;
            //SqlCommand command;
            //command = connect.CreateCommand();
            string query = "SELECT MAX(CustomerID) + 1 as MaxID FROM Customers;";
            //command.ExecuteNonQuery();

            //using (connect)
            //{
                //connect.Open();
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
                        dataRead.Close();
                    }

                }
                

           // }
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

                //using (connect)
               // {
                    //connect.Open();
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
                            dataRead.Close();
                        }

                    }

                //}
            }
            else
            {
                Console.WriteLine("Error creating new customer.");
            }



        }


        public void getStores()
        {
          string query = "SELECT StoreNum, StoreLocation FROM Stores;";

                //using (connect)
                //{
                   // connect.Open();
                    using (SqlCommand command = new SqlCommand(query, connect))
                    {
                        using (SqlDataReader dataRead = command.ExecuteReader())
                        {
                            Console.WriteLine("\n ID# " + " Store Location ");
                            while (dataRead.Read())
                            {
                                for (int i = 0; i < dataRead.FieldCount; i++)
                                {
                                    Console.Write("   " + (dataRead.GetValue(i)));
                                }
                                Console.WriteLine();
                            }
                        dataRead.Close();
                        }

                    }
                
                //}

        }
        public List<Products> displayProducts1(int StoreNum)
        {
            int productCount = 1;
            
            string query = "SELECT p.ProductID, ProductName, Price, ProductDescription, ProductQuantity " +
                           "FROM Inventory " +
                           "LEFT OUTER JOIN Stores " +
                           "ON Stores.StoreNum = Inventory.StoreNum " +
                           "LEFT OUTER JOIN Products p " +
                           "ON p.ProductID = Inventory.ProductID " +
                           "WHERE Inventory.StoreNum = " + StoreNum + " ;";

            List<Products> products = new List<Products>();
            using (SqlCommand command = new SqlCommand(query, this.connect))
            {
                SqlDataReader dataReader = command.ExecuteReader();
                products = this._mapper.EntityToProducts(dataReader);
                dataReader.Close();
            }
            return products;

            /*using (connect)
            {
                //connect.Open();
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
            }*/
        }

        public int newCart(int StoreNum, int CustomerID, decimal CartTotal)
        {
            int CartID = 0;
            string query = "INSERT INTO ShoppingCart(StoreNum, CustomerID, CartTotal) values('" + StoreNum + "', '" + CustomerID + "', '" + CartTotal + "')";
            List<ShoppingCart> cart = new List<ShoppingCart>();
            using (SqlCommand command = new SqlCommand(query, this.connect))
            {
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {

                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        Console.WriteLine(dataReader.GetValue(i));

                    };
                }
                //cart = this._mapper.EntityToCart(dataReader);
                dataReader.Close();
            }

                    


            string query2 = "SELECT CartID FROM ShoppingCart;";
            using (SqlCommand command = new SqlCommand(query2, this.connect))
            {
                SqlDataReader dataReader = command.ExecuteReader();
                //cart = this._mapper.EntityToCart(dataReader);
                while (dataReader.Read())
                {
                    CartID = (Convert.ToInt32(dataReader[0].ToString()));
                    //Console.WriteLine(CartID);
                }
                dataReader.Close();
            }
            return CartID;
            

        }
        public void  addItemToCart(Guid LineID, int CartID, int ProductID, int ItemQuantity, decimal ItemTotal)
        {
            string query = $"INSERT INTO ShoppingCartItems(LineID, CartID, ProductID, ItemQuantity, ItemTotal) values('{LineID} ',' {CartID} ', ' {ProductID} ', ' {ItemQuantity} ', ' {ItemTotal} ');";
            List<CartItems> cartItems = new List<CartItems>();
            SqlCommand command = new SqlCommand(query, this.connect);
                //{
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        for (int i = 0; i < dataReader.FieldCount; i++)
                        {
                            Console.WriteLine(dataReader.GetValue(i));
                        };

                    }
                //cartItems = this._mapper.EntityToCartItem(dataReader);
                dataReader.Close();
                //}
        }


        //delete foreign keys before primary deleteCart
        public void deleteCartItems(int CartID)
        {
            string query = "DELETE ShoppingCartItems WHERE CartID = " + CartID + " ;";

            using (SqlCommand command = new SqlCommand(query, this.connect))
            {
                SqlDataReader dataReader = command.ExecuteReader();

                dataReader.Close();
            }
        }

        public void deleteCart(int CartID)
        {
            
            string query = "DELETE ShoppingCart WHERE CartID = " + CartID + ";";
            
            using (SqlCommand command = new SqlCommand(query, this.connect))
            {
                SqlDataReader dataReader = command.ExecuteReader();
                
                dataReader.Close();
            }
        }



        public void saveOrder(int CartID)
        {
            string query = $"INSERT INTO Orders (CartID, StoreNum, CustomerID, OrderTotal) " +
                            "SELECT CartID, StoreNum, CustomerID, CartTotal FROM ShoppingCart WHERE CartID = " + CartID + ";";
            
            SqlCommand command = new SqlCommand(query, this.connect);
            
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                for (int i = 0; i < dataReader.FieldCount; i++)
                {
                    Console.WriteLine(dataReader.GetValue(i));
                };

            }
            dataReader.Close();
           
        }

            
            
                
        public int getOrderIDFromCart(int CartID)
        {
            string query = "SELECT OrderID FROM Orders WHERE CartID = " + CartID + ";";
            int OrderID = 0;
            SqlCommand command = new SqlCommand(query, this.connect);
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
               // for (int i = 0; i < dataReader.FieldCount; i++)
                //{
                    OrderID = (Convert.ToInt32(dataReader[0].ToString()));
                //};

            }
            dataReader.Close();
            return OrderID;
        } 
        
        public decimal calculateCartTotal(int CartID)
        {
            decimal CartTotal = 0;
            string query = $"SELECT SUM(ItemTotal) FROM ShoppingCartItems WHERE CartID = '{CartID}';";
            SqlCommand command = new SqlCommand(query, this.connect);
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                for (int i = 0; i < dataReader.FieldCount; i++)
                {
                   CartTotal = Convert.ToDecimal(dataReader[0].ToString());

                };

            }
            dataReader.Close();
            return CartTotal;
            
        }

        public void updateCartTotal(int CartID, decimal CartTotal)
        {
            string query = $"UPDATE ShoppingCart SET CartTotal = '{CartTotal}' WHERE CartID = '{CartID}';";
            SqlCommand command = new SqlCommand(query, this.connect);
            SqlDataReader dataReader = command.ExecuteReader();
            dataReader.Close();

        }





        public void displayOrderTotal(int OrderID)
        {
            string query = $"SELECT SUM(OrderTotal) FROM Orders WHERE OrderID = '{OrderID}';";
            SqlCommand command = new SqlCommand(query, this.connect);
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                for (int i = 0; i < dataReader.FieldCount; i++)
                {
                    Console.WriteLine("Your total is: " + dataReader.GetValue(i));
                    
                };

            }
            dataReader.Close();
        }
            


        public void saveOrderItems(int CartID, int OrderID)
        {
            
            string query = "INSERT INTO OrderItems (LineID, OrderID, ProductID, ItemQuantity, ItemTotal) " +
                            "SELECT LineID, " + OrderID + ", ProductID, ItemQuantity, ItemTotal FROM ShoppingCartItems WHERE CartID = " + CartID + ";";
            
            SqlCommand command = new SqlCommand(query, this.connect);
            //{
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                for (int i = 0; i < dataReader.FieldCount; i++)
                {
                    Console.WriteLine(dataReader.GetValue(i));
                };

            }
            dataReader.Close();
        }


        



        public void changeQuantityInCart(int CartItemID, int ItemQuantity, float ItemTotal)
        {
            string query = "UPDATE ShoppingCartItems SET ItemQuantity = " + ItemQuantity + ", ItemTotal = " + ItemTotal + " " +
                " WHERE CartItemID = " + CartItemID + " ;";
        }

        
        
        
        
        
        

        
        
        
        
        
        
        
        
        
        public void viewCart(int CartID)
        {

            string query = "SELECT StoreLocation, CustomerName, ' Total: ', CartTotal" +
                           "FROM ShoppingCart " +
                           "LEFT OUTER JOIN Stores " +
                           "ON Stores.StoreNum = ShoppingCart.StoreNum " +
                           "LEFT OUTER JOIN Customers " +
                           "ON Customers.CustomerID = ShoppingCart.CustomerID " +
                           "WHERE CartID = " + CartID + ";";


        }

        public void viewItemsInCart(int CartID)
        {
            string query = "SELECT '\n LineID: ', LineID, '\n Product: ', ProductName, '\n Quantity: ', ItemQuantity, '\n Item total: ', ItemTotal, '\n'" +
                           "FROM ShoppingCartItems " +
                           "LEFT OUTER JOIN Products " +
                           "ON Products.ProductID = ShoppingCartItems.ProductID " +
                           "WHERE CartID = " + CartID +
                           "ORDER BY LineID ;";
            List<CartItems> itemsInCart = new List<CartItems>();
            SqlCommand command = new SqlCommand(query, this.connect);
            
            SqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                for (int i = 0; i < dataReader.FieldCount; i++)
                {
                    Console.Write(dataReader.GetValue(i));
                };

            }
            dataReader.Close();
        }

        public void viewPastOrdersPerStore(int CustomerID, int StoreNum)
        {

            SqlConnection c = new SqlConnection(this.database);
            c.Open();
             string query = "SELECT Orders.OrderID, '\n', ProductName, '--------', 'Quantity: ', ItemQuantity, '\n Price: $', ItemTotal " +
                           "FROM Orders " +
                           "INNER JOIN OrderItems " +
                           "ON OrderItems.OrderID = Orders.OrderID " +
                           "LEFT OUTER JOIN Products " +
                           "ON Products.ProductID = OrderItems.ProductID " +
                           "WHERE CustomerID = " + CustomerID + " AND StoreNum = " + StoreNum +
                           "ORDER BY OrderID, ProductName;";
            
                SqlCommand command = new SqlCommand(query, c);
           

                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Console.Write("\nOrder# : ");
                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        Console.Write(dataReader.GetValue(i));
                    };
                    Console.WriteLine();

                }
                dataReader.Close();
            
        }

        public void viewPastOrders(int CustomerID)
        {
            string query = "SELECT Orders.OrderID, '\n', ProductName, '--------', 'Quantity: ', ItemQuantity, '\n Price: $', ItemTotal " +
                           "FROM Orders " +
                           "INNER JOIN OrderItems " +
                           "ON OrderItems.OrderID = Orders.OrderID " +
                           "LEFT OUTER JOIN Products " +
                           "ON Products.ProductID = OrderItems.ProductID " +
                           "WHERE CustomerID = " + CustomerID + 
                           "ORDER BY Orders.OrderID, ProductName;";
           
            SqlCommand command = new SqlCommand(query, this.connect);

            SqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                Console.Write("\nOrder# : ");
                for (int i = 0; i < dataReader.FieldCount; i++)
                {
                    Console.Write(dataReader.GetValue(i));
                };
                Console.WriteLine();

            }
            dataReader.Close();
        }

        

           




    }
    
}
