using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Domain;

namespace Storage
{
    public class DataManager : IDataManager
    {
        private readonly DatabaseAccess _databaseAccess;


        public DataManager()
        {
            this._databaseAccess = new DatabaseAccess();
        }
        public void LoadProducts()
        {
            


        }

        public void SaveProducts()
        {



        }
        public List<CartItems> addItemToCart()
        {


            this._databaseAccess.addItemToCart();
            List<CartItems> cartItems = new List<CartItems>();
            return cartItems;

        }

        


    
    
    }

   
}
