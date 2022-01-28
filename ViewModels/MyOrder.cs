using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryShop.ViewModels
{
    public class MyOrder
    {
        [Key]
        public int OrderDetailId { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public int Quantity { get; set; }
        public string ProductPrize { get; set; }
    }
}
