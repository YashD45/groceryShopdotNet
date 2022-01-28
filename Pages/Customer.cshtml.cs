using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroceryShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GroceryShop.Pages
{
    public class CustomerModel : PageModel
    {
        public Customer Model { get; set; }
        public void OnGet()
        {
        }
    }
}
