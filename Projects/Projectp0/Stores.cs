using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projectp0
{
    internal class Stores
    {
        public string storeName { get; set; }
        public List<Products> ProductList { get; set; }


        // List<String> storeList = new List<String>();

        public Stores()
        {

            
            ProductList = new List<Products>();


        }

          
        //Dictionary<string, List<string>> storeDic = new Dictionary<string, List<string>>();
    }

        
}
