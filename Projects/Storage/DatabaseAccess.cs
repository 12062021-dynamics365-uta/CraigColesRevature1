using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Storage
{
    public class DatabaseAccess
    {
        string database = "Data source = DESKTOP-58I9UJJ\\SQLEXPRESS; initial Catalog = ProjectP0; integrated security = true";
        private readonly SqlConnection connect;

        public DatabaseAccess()
        {
            this.connect = new SqlConnection(database);
        }


        public void displayActiveCustomers()
        {
            string query = "SELECT LoginName FROM Customers;";

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

        public void addUser(string FirstName, string LastName, string LoginName)
        {
           
            SqlCommand command;
            command = connect.CreateCommand();
            string query = "INSERT INTO Customers(FirstName, LastName, LoginName) values('" + FirstName + "', '" + LastName + "', '" + LoginName + "');";
            command.ExecuteNonQuery();

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

        public void displayProducts1()
        {
            string query = "SELECT * FROM Products;";

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
                                Console.WriteLine(productReader.GetValue(i));
                            }
                            Console.WriteLine();
                        }
                    }
                }
            }
        }


    }
    
}
