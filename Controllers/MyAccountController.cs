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
    public class MyAccountController : ControllerBase
    {
        private readonly CustomerDBcontext _context;

        public MyAccountController(CustomerDBcontext context)
        {
            _context = context;
        }

        // GET: api/MyAccount
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MyAccount>>> GetMyAccount()
        {
            return await _context.MyAccount.ToListAsync();
        }

        // GET: api/MyAccount/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MyAccount>> GetMyAccount(int id)
        {
            var myAccount = await _context.MyAccount.FindAsync(id);

            if (myAccount == null)
            {
                return NotFound();
            }

            return myAccount;
        }

        

        // POST: api/MyAccount
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MyAccount>> PostMyAccount(MyAccount myAccount)
        {
            _context.MyAccount.Add(myAccount);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMyAccount", new { id = myAccount.LoginId }, myAccount);
        }

        // DELETE: api/MyAccount/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MyAccount>> DeleteMyAccount(int id)
        {
            var myAccount = await _context.MyAccount.FindAsync(id);
            if (myAccount == null)
            {
                return NotFound();
            }

            _context.MyAccount.Remove(myAccount);
            await _context.SaveChangesAsync();

            return myAccount;
        }

        private bool MyAccountExists(int id)
        {
            return _context.MyAccount.Any(e => e.LoginId == id);
        }
    }
}
