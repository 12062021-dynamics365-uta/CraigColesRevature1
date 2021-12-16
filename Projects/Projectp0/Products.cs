using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projectp0
{
    class Products : Stores
    {


        public string proName { get; set; }
        public double price { get; set; }

        public string description { get; set; }


        //List<Products> pro = new List<Products>();


        public void getProducts()
        {
            Dictionary<string, double> krogerProducts = new Dictionary<string, double>();

                //{"1.)", new Products { proName = "Bananas", price = .69 } },
                //{2, new Products { proName = "Bananas", price = .69 } },
            krogerProducts.Add("Bananas", .69);

            krogerProducts.Add("Bread", 1.29);
            krogerProducts.Add("", .69);

            foreach (var p in krogerProducts)
            {
                Console.WriteLine("Product list: " + p);

            }
        }


    }
}





    

