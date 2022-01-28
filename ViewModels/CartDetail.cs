using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryShop.ViewModels
{
    public class CartDetail
    {

        [Key]
        public int cartId { get; set; }

        public int ProductId { get; set; }
        [Column(TypeName = "varchar(1000)")]
        public string ProductName { get; set; }

    }
}
