using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    class Stores
    {
        
        public int StoreNum { get; set; }
        public string storeName { get; set; }

        public string StoreLocation { get; set; }

        public List<Stores> StoreList { get; set; }

        public Stores()
        {
            StoreList = new List<Stores>();
        }

    
    }
}
