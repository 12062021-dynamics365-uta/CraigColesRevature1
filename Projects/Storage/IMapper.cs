using Domain;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Storage
{
    public interface IMapper
    {
        List<CartItems> EntityToCartItem(SqlDataReader dataReader);
    }
}