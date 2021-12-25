using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Orders
    {
        public int OrderID {get; set;}
        
        public int StoreNum { get; set; }

        public int CustomerID { get; set; }

        Decimal OrderTotal { get; set; }
    
    }
}
