using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projectp0
{
    internal class Products : Stores
    {
        public string proName { get; set; }
        public decimal price { get; set; }
        public int quantity { get; set; }
        public int productNum { get; set; }


        //List<Products> pro = new List<Products>();
        public Products(int productNum)
        {
             productNum = 1;
        }

        public void getSaginawProducts()
        {
            Dictionary<string, double> saginawProducts = new Dictionary<string, double>();

            //{"1.)", new Products { proName = "Bananas", price = .69 } },
            //{2, new Products { proName = "Bananas", price = .69 } },
            saginawProducts.Add("Roland 4-piece drumkit", 499.00 );

            saginawProducts.Add("Squire Fender Guitar", 350.00);
            saginawProducts.Add("Guitar picks", 1.69);

            foreach (var p in saginawProducts)
            {
                Console.WriteLine($"Product {1 + productNum++}: {p}");

            }
        }

        public void getSouhtfieldProducts()
        {
            Dictionary<string, double> southfieldProducts = new Dictionary<string, double>();

            southfieldProducts.Add("Roland 4-piece drumkit", 499.00);

            southfieldProducts.Add("Squire Fender Guitar", 350.00);
            southfieldProducts.Add("", 1.69);

            foreach (var s in southfieldProducts)
            {
                Console.WriteLine($"Product {1 + productNum++}: {s}");

            }




        }

    }

    internal static class Inventory
    {
        public static List<Products> products;
        public static List<Products> Products
        {
            get
            {
                if (products.Count == 0)
                {
                    Load();
                }

                return products;
            }
            set { products = value; }
        }

        static Inventory()
        {
            Products = new List<Products>();
        }

        private static void Load()
        {
           // Products = DataManager.LoadProducts();
        }

        private static void Save()
        {
           // DataManager.SaveProducts(Products);
        }

        public static void RemoveProduct(int productId)
        {
           // Inventory.Products.RemoveAll(x => x.Id == productId);
            Save();
        }

        public static void Add(Products product)
        {
            Products.Add(product);
            Save();
        }
        public static int GetProductCount()
        {
            return Inventory.Products.Count();
        }

        public static int GetUnitCount()
        {
            return Inventory.Products.Select(x => x.quantity).Sum();
        }

        public static decimal GetInventoryValue()
        {
            return Inventory.Products.Select(x => (x.price * x.quantity)).Sum();
        }
        public static void ClearInventory()
        {
            Inventory.Products.Clear();
            Save();
        }
    }




}





    

