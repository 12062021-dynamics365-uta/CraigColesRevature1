using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projectp0
{
    internal class Stores
    {
        public string storeName1 { get; set; }

        public string storeName2 { get; set; }

        public string storeName3 { get; set; }

        public List<Stores> StoreList { get; set; }
        public List<Products> ProductList { get; set; }


        

        public Stores()
        {
            //contructing store list
            StoreList = new List<Stores>();
            

            //constructtion product list
           // ProductList = new List<Products>();


        }

       

        

        
        

          
        
    }

        
}
