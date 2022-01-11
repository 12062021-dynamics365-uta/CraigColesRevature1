using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetnSaltyModels
{
    public class PersonFlavorJunction
    {
        public int PersonFlavorID { get; set; }
        public int PersonID { get; set; }
        
        public int FlavorID { get; set; }
    }
}
