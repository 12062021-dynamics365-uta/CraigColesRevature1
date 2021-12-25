using Domain;
using System;
using System.Collections.Generic;

namespace Storage
{
    public interface IDatabaseAccess
    {
        //methods here
        public void displayActiveCustomers();
        public int getActiveCustomerID(string FirstName, string LastName);
        public int getNextCustomerID();

        public void addCustomer(int CustomerID, string FirstName, string LastName, string LoginName);
        public void getStores();
        public List<Products> displayProducts1(int StoreNum);
        public int newCart(int StoreNum, int CustomerID, decimal CartTotal);
        public void addItemToCart(Guid LineID, int CartID, int ProductID, int ItemQuantity, decimal ItemTotal);
        public void deleteCart(int CartID);
        public decimal getOrder(int CartID, int StoreNum, int CustomerID, decimal OrderTotal);

        public void getOrderItems(int CartID);

        public void viewItemsInCart(int CartID);
    }
}