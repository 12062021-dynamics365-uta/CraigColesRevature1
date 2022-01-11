using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace SweetnSaltyDbAccess
{
    public class SweetnSaltyDbAccessClass : ISweetnSaltyDbAccessClass
    {
        private readonly string str = "Data source = DESKTOP-58I9UJJ\\SQLEXPRESS; initial Catalog = SweetnSalty; integrated security = true";
        private readonly SqlConnection _con;

        //constructor
        public SweetnSaltyDbAccessClass()
        {
            this._con = new SqlConnection(this.str);
            _con.Open();
        }

        public async Task<SqlDataReader> PostFlavor(string flavor)
        {
            string sqlQuery = $"INSERT INTO Flavor VALUES (@FlavorName);";

            using (SqlCommand command = new SqlCommand(sqlQuery, this._con))
            {
                command.Parameters.AddWithValue("@FlavorName", flavor);
                
                try
                {
                    await command.ExecuteNonQueryAsync();

                    string retrieveFlavor = "SELECT TOP 1 * FROM Flavor ORDER BY FlavorID DESC;";
                    using (SqlCommand command1 = new SqlCommand(retrieveFlavor, this._con))
                    {
                        SqlDataReader dr = await command1.ExecuteReaderAsync();
                        return dr;
                    }
                }
                catch (DbException ex)
                {
                    Console.WriteLine($"There was an exception in SweetnSaltyBusinessClass.PostFlavor");
                    return null;
                }
            
            }
        }


        public async Task<SqlDataReader> PostPerson(string fname, string lname)
        {
            string sqlQuery = $"INSERT INTO Person (FirstName, LastName) VALUES (@FirstName, @LastName);";

            using (SqlCommand command = new SqlCommand(sqlQuery, this._con))
            {
                command.Parameters.AddWithValue("@FirstName", fname);
                command.Parameters.AddWithValue("@LastName", lname);

                try
                {
                    await command.ExecuteNonQueryAsync();
                    string retrievePerson = "SELECT TOP 1 * FROM Person ORDER BY PersonID DESC;";
                    using (SqlCommand command0 = new SqlCommand(retrievePerson, this._con))
                    {
                        SqlDataReader dr = await command0.ExecuteReaderAsync();
                        return dr;
                    }

                }
                catch (DbException ex)
                {
                    Console.WriteLine($"There was an exception in SweetnSaltyBusinessClass.PostPerson");
                    return null;
                }


                //try
                //{
                //    await command.ExecuteNonQueryAsync();
                //    string getFlavId = "SELECT TOP 1 FlavorID FROM Flavor WHERE flavor = @FlavorName;";
                //    using (SqlCommand command2 = new SqlCommand(getFlavId, this._con))
                //    {
                //        SqlDataReader dr = await command2.ExecuteReaderAsync();
                //        FlavId = dr.GetInt32(0);
                //    }
                //}
                //catch (DbException ex)
                //{
                //    Console.WriteLine($"Flavor not found.");
                //    return null;
                //}

                /*try
                {
                    //Only if a FlavorId and PersonID is found
                   
                        //await command.ExecuteNonQueryAsync();
                        string PerFlavQuery = $"INSERT INTO PersonFlavorJunction (PersonID, FlavorID) " +
                                         $"SELECT TOP 1 p.PersonID, f.FlavorID " +
                                         $"FROM Person p LEFT OUTER JOIN Flavor f " +
                                         $"ON f.FlavorName = @flavor " +
                                         $"ORDER BY PersonID DESC;";

                        using (SqlCommand command1 = new SqlCommand(PerFlavQuery, this._con))
                        {
                            
                            command1.Parameters.AddWithValue("@flavor", flavor);
                            try
                            {

                                //await command1.ExecuteNonQueryAsync();
                                string retrievePerson = "SELECT TOP 1 * FROM PersonFlavorJunction ORDER BY PersonFlavorID DESC;";
                                using (SqlCommand command2 = new SqlCommand(retrievePerson, this._con))
                                {
                                SqlDataReader dr = command2.ExecuteNonQuery();
                                   //
                                   return dr;
                                }
                            }
                            catch (DbException ex)
                            {
                                Console.WriteLine($"There was an exception in SweetnSaltyBusinessClass.PostPerson");
                                return null;
                            }
                        }
                    
                }
                catch (DbException ex)
                {
                    Console.WriteLine($"There was an exception in SweetnSaltyBusinessClass.PostPerson");
                    return null;
                }
                */

            }
        }



        public async Task<SqlDataReader> GetPerson(string fname, string lname)
        {
            string sqlQuery = $"SELECT TOP 1 * FROM Person WHERE FirstName = @fname and LastName = @lname;";

            using (SqlCommand cmd = new SqlCommand(sqlQuery, this._con))
            {
                cmd.Parameters.AddWithValue("@fname", fname);
                cmd.Parameters.AddWithValue("@lname", lname);
                
                SqlDataReader dr = await cmd.ExecuteReaderAsync();
                return dr;
            }
        }

        public async Task<SqlDataReader> GetPersonAndFlavors(int id)
        {

            //was a bit confused on how to the user will be entering a favorite flavor.
            //I tried...


            string PerFlavQuery = $"SELECT PersonFlavorID FROM PersonFlavorJunction " +
                                         $"SELECT p.FirstName, f.FlavorName " +
                                         $"FROM Person p LEFT OUTER JOIN Flavor f " +
                                         $"ON p.FlavorName = p.FirstName" +
                                         $"ORDER BY PersonID = {id} DESC;";

            using (SqlCommand command = new SqlCommand(PerFlavQuery, this._con))
            {
                command.Parameters.AddWithValue("@id", id);

                SqlDataReader dr = await command.ExecuteReaderAsync();
                return dr;

            }

        }

        public async Task<SqlDataReader> GetAllFlavors()
        {
            string query = "SELECT * FROM Flavor";
            
            
            using (SqlCommand command = new SqlCommand(query, this._con))
            {
                SqlDataReader dr = await command.ExecuteReaderAsync();
                return dr;
            }
            

        }
    }//End of class
}//End of namespace
