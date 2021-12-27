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

        public int getOrderIDFromCart(int CartID);

        public decimal calculateCartTotal(int CartID);
        public void updateCartTotal(int CartID, decimal CartTotal);
        public void saveOrder(int CartID);

        public void displayOrderTotal(int OrderID);

        public void saveOrderItems(int CartID, int OrderID);

        public void viewItemsInCart(int CartID);

        public void viewPastOrders(int CustomerID);

        public void viewPastOrdersPerStore(int CustomerID, int StoreNum);
    }
}