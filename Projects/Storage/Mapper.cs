using Domain;
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

