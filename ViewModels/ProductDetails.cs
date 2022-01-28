using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryShop.ViewModels
{
    public class ProductDetails
    {
        [Key]
        public int ProductId { get; set; }
        
        public string ProductName { get; set; }
        public string ProductPrize { get; set; }
        public int Stock { get; set; }
        
        public string ProductUnit { get; set; }
      
        public string PhotoFileName { get; set; }
    }
}
