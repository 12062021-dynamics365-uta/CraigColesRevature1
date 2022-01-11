using SweetnSaltyModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetnSaltyBusiness
{
    public class Mapper : IMapper
    {
        public Flavor EntityToFlavor(SqlDataReader dr)
        {
            return new Flavor()
            {
                //FlavorID = Convert.ToInt32(dr[0].ToString()),
                FlavorID = dr.GetInt32(0),
                FlavorName = dr[1].ToString(),
            };
        }

        public Person EntityToPerson(SqlDataReader dr)
        {
            return new Person()
            {
                PersonID = dr.GetInt32(0),
                FirstName = dr[1].ToString(),
                LastName = dr[2].ToString(),
            };
        
        }

        public PersonFlavorJunction EntityToPerFlav(SqlDataReader dr)
        {
            return new PersonFlavorJunction()
            {
                PersonFlavorID = dr.GetInt32(0),
                PersonID = dr.GetInt32(1),
                FlavorID = dr.GetInt32(2),

            };
        }
    }
}


    
