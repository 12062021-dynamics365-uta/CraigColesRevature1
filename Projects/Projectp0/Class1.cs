using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Projectp0
{
    class Class1
    {

        public void connectSQL() {
            String str = "Data source =DESKTOP-58I9UJJ\\SQLEXPRESS; initial Catalog=Sjinook; integrated security = true";
            SqlConnection con = new SqlConnection(str);
            string querystring = "SELECT * FROM Artist;";
            con.Open();
            SqlCommand cmd = new SqlCommand(querystring, con);
            SqlDataReader dr = cmd.ExecuteReader();

            List<Stores> s = new List<Stores>();

            while (dr.Read())

            {

                //number of rows
                Console.WriteLine(dr[0].ToString());
                
            }
            con.Close();
        }

        public void something()
        {
            try
            {
                string str = "Data source =DESKTOP-58I9UJJ\\SQLEXPRESS; initial Catalog=Sjinook; integrated security = true";
                using (SqlConnection con = new SqlConnection(str))
                {
                    SqlCommand cmd = new SqlCommand("Insert into StoresTest values('Kroger', 'bananas')", con);
                    con.Open();
                    int row = cmd.ExecuteNonQuery();
                    Console.WriteLine("Insert rows" + row);
                    cmd.CommandText = "update StoresTest set StoreName = 'Kroger'";
                    row = cmd.ExecuteNonQuery();
                    Console.WriteLine("Updated rows" + row);
                    //cmd.CommandText = "DELETE FROM Stores WHERE StoreName = 'Kroger'";
                    //row = cmd.ExecuteNonQuery();
                    //Console.WriteLine("Rows deleted: " + row);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Oops, something went wrong" + e);
            }
        }

        public void dataTable()
        {
            try
            {
                DataTable dt = new DataTable("Products");
                DataColume id = new DataColumn("ID");
                id.DataType = typeof(int);
                id.Unique = true;
                id.AlloDBNull = false;
                id.Caption = "Product ID";
            
            
            }

        }
         

    }
}
