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
       
        
        public int CartID { get; set; }
        public int StoreID { get; set; }
        public int CustomerID {get; set;}
        public decimal CartTotal { get; set; }
        

        public ShoppingCart()
        {
           
        }


        

        
    }
}

