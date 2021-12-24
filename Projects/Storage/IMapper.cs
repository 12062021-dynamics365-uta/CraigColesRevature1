using Domain;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Storage
{
    public interface IMapper
    {
        public int EntitytoActiveCustomer(SqlDataReader dataReader);
        List<CartItems> EntityToCartItem(SqlDataReader dataReader);
        List<ShoppingCart> EntityToCart(SqlDataReader dataReader);
        List<Products> EntityToProducts(SqlDataReader dataReader);
    }
}