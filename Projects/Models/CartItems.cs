using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class CartItems
    {
        [Key]
        public int CartItemID { get; set; }

        public int LineID { get; set; }

        public int CartID { get; set; }

        public int ProductID { get; set; }

        public System.DateTime DateCreated { get; set; }

        public int ItemQuantity { get; set; }

        public decimal ItemTotal { get; set; }

        


    }

    
}
