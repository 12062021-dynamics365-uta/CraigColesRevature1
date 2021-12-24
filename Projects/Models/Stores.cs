using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Stores
    {
        
        public int StoreNum { get; set; }
        public string storeName { get; set; }

        public string StoreLocation { get; set; }

        public List<Stores> StoreList { get; set; }

        public List<Products> products { get; set; }

        public Stores()
        {
            products = new List<Products>();
            StoreList = new List<Stores>();
        }

    
    }
}
