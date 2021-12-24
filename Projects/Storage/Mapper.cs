using Domain;
using NewP0;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage
{
    public class Mapper : IMapper
    {

       public int EntitytoActiveCustomer(SqlDataReader dataReader)
        {
            string first = " ";
            string last = " ";
            int CustomerID = 0;
            
            while (dataReader.Read())
            {
                Customer activeCustomer = new Customer(first, last)
                {
                    CustomerID = Convert.ToInt32(dataReader[0].ToString()),

                };
            }
            return CustomerID;
        }



        public List<Products> EntityToProducts(SqlDataReader dataReader)
        {
            List<Products> products = new List<Products>();
            while (dataReader.Read())
            {

                Products product = new Products()
                {
                    productID = Convert.ToInt32(dataReader[0].ToString()),
                    proName = dataReader[1].ToString(),
                    price = Convert.ToDecimal(dataReader[2].ToString()),
                    ProductDescription = dataReader[3].ToString(),
                    ProductQuantity = Convert.ToInt32(dataReader[4].ToString())

                };
                products.Add(product);

            }
            return products;
        }
        
        public List<ShoppingCart> EntityToCart(SqlDataReader dataReader)
        {

            List<ShoppingCart> addCart = new List<ShoppingCart>();
            while (dataReader.Read())
            {

                ShoppingCart cart = new ShoppingCart()
                {
                    CartID = Convert.ToInt32(dataReader[0].ToString()),
                    StoreID = Convert.ToInt32(dataReader[0].ToString()),
                    CustomerID = Convert.ToInt32(dataReader[1].ToString()),
                    CartTotal = Convert.ToDecimal(dataReader[2].ToString()),
                   
                };
                addCart.Add(cart);

            }
            return addCart;


        }
        public List<CartItems> EntityToCartItem(SqlDataReader dataReader)
        {

            List<CartItems> cartItems = new List<CartItems>();
            while (dataReader.Read())
            {

                CartItems item = new CartItems()
                {
                    CartItemID = Convert.ToInt32(dataReader[0].ToString()),
                    LineID = Convert.ToInt32(dataReader[1].ToString()),
                    CartID = Convert.ToInt32(dataReader[2].ToString()),
                    ProductID = Convert.ToInt32(dataReader[3].ToString()),
                    ItemQuantity = Convert.ToInt32(dataReader[4].ToString()),
                    ItemTotal = Convert.ToInt32(dataReader[5].ToString()),
                };
                cartItems.Add(item);
             
             }
            return cartItems;


        }





            
     } 
        
        
        
        
        
 }

