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
    public class DataManager : IDataManager
    {
        public Stores currentStore { get; set; }
        
        public Orders currentOrder { get; set; }
     
       // public ShoppingCart CartID { get; set; }
        
        List<ShoppingCart> cart;
        public CartItems productID { get; set; }
        
        
        List<CartItems> cartItems;
        private readonly IDatabaseAccess _databaseAccess;



        public DataManager(IDatabaseAccess dba)
        {
            productID = new CartItems();
            currentStore = new Stores();
           // CartID = new ShoppingCart();
            cart = new List<ShoppingCart>();
            cartItems = new List<CartItems>();
            currentOrder = new Orders();
            this._databaseAccess = dba;
        }

        public void getActiveCustomer(string FirstName, string LastName)
        {
            int CustomerID = 0;
            CustomerID = this._databaseAccess.getActiveCustomerID(FirstName, LastName);
        }



        public void LoadProducts()
        {
            
            currentStore.products = this._databaseAccess.displayProducts1(currentStore.StoreNum);
            
            

        }

        public void SaveProducts()
        {



        }

        //make a cart method

        public int addCart(int StoreID, int CustomerID)
        {
            decimal CartTotal = 0;
            

            //List<ShoppingCart> newCart = new List<ShoppingCart>();
            int CartID = this._databaseAccess.newCart(StoreID, CustomerID, CartTotal);
            return CartID;
            
        }

        //adding item to cart
        public List<CartItems> addItemToCart(int CartID, int productID, int ItemQuantity)
        {
            
            decimal ItemTotal = 0;
            Guid LineID = Guid.NewGuid();
            List<CartItems> cartItems = new List<CartItems>();
            Products p;
            foreach (Products prod in currentStore.products)
            {

                if (prod.productID == productID)
                {

                    p = prod;
                    //gets the total of selected product
                    ItemTotal = ItemQuantity * p.price; 
                }
            }

           // cartItems.Add(p);
           this._databaseAccess.addItemToCart(LineID, CartID, productID, ItemQuantity, ItemTotal);
            return cartItems;
        }

        public void viewCart()
        {

        }

        public void getOrder(int CartID, int StoreNum, int CustomerID, decimal OrderTotal)
        {
            //decimal OrderTotal = 0;
            List<Orders> order = new List<Orders>();
            Orders o;
            int ItemQuantity = 0;
            ItemQuantity++;

            foreach (Orders orders in order)
            {
                o = orders;
                
            }

            this._databaseAccess.getOrder(CartID, StoreNum, CustomerID, OrderTotal);
            //
        }




        


    
    
    }

   
}
