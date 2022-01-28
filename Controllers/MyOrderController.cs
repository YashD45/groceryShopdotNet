using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GroceryShop.Models;
using GroceryShop.ViewModels;

namespace GroceryShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyOrderController : ControllerBase
    {
        private readonly CustomerDBcontext _context;

        public MyOrderController(CustomerDBcontext context)
        {
            _context = context;
        }

        // GET: api/MyOrder
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MyOrder>>> GetMyOrder()
        {
            return await _context.MyOrder.ToListAsync();
        }

        // GET: api/MyOrder/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MyOrder>> GetMyOrder(int id)
        {
            var myOrder = await _context.MyOrder.FindAsync(id);

            if (myOrder == null)
            {
                return NotFound();
            }

            return myOrder;
        }

        

        // DELETE: api/MyOrder/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MyOrder>> DeleteMyOrder(int id)
        {
            var myOrder = await _context.MyOrder.FindAsync(id);
            if (myOrder == null)
            {
                return NotFound();
            }

            _context.MyOrder.Remove(myOrder);
            await _context.SaveChangesAsync();

            return myOrder;
        }

        private bool MyOrderExists(int id)
        {
            return _context.MyOrder.Any(e => e.OrderDetailId == id);
        }
    }
}
