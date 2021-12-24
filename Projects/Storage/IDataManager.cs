using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage
{
    interface IDataManager
    {

        public void getActiveCustomer(string FirstName, string LastName);
        int addCart(int StoreID, int CustomerID);
        List<CartItems> addItemToCart(int CartID, int productID, int ItemQuantity);


    }
}
