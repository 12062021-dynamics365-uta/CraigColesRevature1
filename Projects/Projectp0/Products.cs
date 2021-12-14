using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projectp0
{
    class Products : Stores
    {
        public List<string> ProductList { get; set; }
        
        public string proName { get; set; }
        public double price { get; set; }

        public string description { get; set; }

        //List<Products> pro = new List<Products>();

        Products Pro1 = new Products()
        {
            proName = "Bananas",
            price = .69
        };
    
    }
}
