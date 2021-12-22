using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Domain
{
    public class ShoppingCart
    {

        string database = "Data source = DESKTOP-58I9UJJ\\SQLEXPRESS; initial Catalog = ProjectP0; integrated security = true";
        public SqlConnection connect;
        private readonly Manager _mapper;

        public ShoppingCart()
        {
            this.connect = new SqlConnection(database);
            this._mapper = new Mapper();
        }


        

        
    }
}

