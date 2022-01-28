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
    public class CartDetailController : ControllerBase
    {
        private readonly CustomerDBcontext _context;

        public CartDetailController(CustomerDBcontext context)
        {
            _context = context;
        }

        // GET: api/CartDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CartDetail>>> GetCartDetail()
        {
            return await _context.CartDetail.ToListAsync();
        }

        // GET: api/CartDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CartDetail>> GetCartDetail(int id)
        {
            var cartDetail = await _context.CartDetail.FindAsync(id);

            if (cartDetail == null)
            {
                return NotFound();
            }

            return cartDetail;
        }

        // PUT: api/CartDetail/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCartDetail(int id, CartDetail cartDetail)
        {
            if (id != cartDetail.cartId)
            {
                return BadRequest();
            }

            _context.Entry(cartDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CartDetail
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CartDetail>> PostCartDetail(CartDetail cartDetail)
        {
            _context.CartDetail.Add(cartDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCartDetail", new { id = cartDetail.cartId }, cartDetail);
        }

        // DELETE: api/CartDetail/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CartDetail>> DeleteCartDetail(int id)
        {
            var cartDetail = await _context.CartDetail.FindAsync(id);
            if (cartDetail == null)
            {
                return NotFound();
            }

            _context.CartDetail.Remove(cartDetail);
            await _context.SaveChangesAsync();

            return cartDetail;
        }

        private bool CartDetailExists(int id)
        {
            return _context.CartDetail.Any(e => e.cartId == id);
        }
    }
}
