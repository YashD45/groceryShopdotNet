using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroceryShop.Models;
using GroceryShop.ViewModels;

namespace GroceryShop.Models
{
    public class CustomerDBcontext : DbContext
    {
      public CustomerDBcontext(DbContextOptions<CustomerDBcontext> options): base(options)
        {

        }
      public DbSet<GroceryShop.ViewModels.Customer> Customer { get; set; }
     
     
     
      public DbSet<GroceryShop.ViewModels.CartDetail> CartDetail { get; set; }
     
      public DbSet<GroceryShop.ViewModels.MyAccount> MyAccount { get; set; }
     
      public DbSet<GroceryShop.ViewModels.MyOrder> MyOrder { get; set; }
      
     
     
      
    }
}
