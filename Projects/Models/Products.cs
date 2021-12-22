using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Products 
    {
        
        
        public string proName { get; set; }
        public decimal price { get; set; }
        public int quantity { get; set; }
        public int productID { get; set; }

        public string CartItemID { get; set; }
        public string CartID { get; set; }

        

        public Products(int productID)
        {

           

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

        public static void RemoveItem(int productId)
        {
            Inventory.Products.RemoveAll(x => x.productID == productId);
            Save();
        }

        public static void AddItem(Products product)
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

        public static decimal GetOrderValue()
        {
            return Inventory.Products.Select(x => (x.price * x.quantity)).Sum();
        }
        public static void ClearOrder()
        {
            Inventory.Products.Clear();
            Save();
        }

        public static void lookUpPastOrders()
        {
            
        }
    }
}
