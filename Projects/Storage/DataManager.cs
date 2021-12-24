﻿using System;
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
        public Stores currentStore { get; set; }
     
       // public ShoppingCart CartID { get; set; }
        
        List<ShoppingCart> cart;
        public CartItems productID { get; set; }
        
        
        List<CartItems> cartItems;
        private readonly DatabaseAccess _databaseAccess;



        public DataManager()
        {
            productID = new CartItems();
            currentStore = new Stores();
           // CartID = new ShoppingCart();
            cart = new List<ShoppingCart>();
            cartItems = new List<CartItems>();
            this._databaseAccess = new DatabaseAccess();
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




        


    
    
    }

   
}
