using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GoFreightAPI.Models;

namespace GoFreightAPI.Controllers
{
    [Route("api/GoFreightItems")]
    [ApiController]
    public class GoFreightController : ControllerBase
    {
        private readonly GoFreightContext _context;

        public GoFreightController(GoFreightContext context)
        {
            _context = context;
        }

        // GET: api/GoFreightItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GoFreightItem>>> GetItems()
        {
          if (_context.GoFreightItems == null)
          {
              return NotFound();
          }
            return await _context.GoFreightItems.ToListAsync();
        }

        // GET: api/GoFreightItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GoFreightItem>> GetItem(long id)
        {
            var gofreightItem = await _context.GoFreightItems.FindAsync(id);

            if (gofreightItem == null)
            {
                return NotFound();
            }

            return gofreightItem;
        }

        // PUT: api/GoFreightItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItem(long id, GoFreightItem gofreightItem)
        {
            if (id != gofreightItem.CustomerID)
            {
                return BadRequest();
            }

            _context.Entry(gofreightItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemExists(id))
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

        // POST: api/GoFreightItems
        [HttpPost]
        public async Task<ActionResult<GoFreightItem>> PostItem(GoFreightItem gofreightItem)
        {
            //_context.GoFreightItems.Add(gofreightItem);
            await _context.SaveChangesAsync();

            var map = new Dictionary<long, double>
            {
                { 1, 5 },
                { 2, 10 },
                { 3, 7 },
                { 4, 4.25 }
            };

            if (map.TryGetValue(gofreightItem.CustomerID, out double mapValue))
            {
                gofreightItem.SurchargeAmount = mapValue * gofreightItem.Subtotal / 100;
                gofreightItem.Total = gofreightItem.Subtotal + gofreightItem.SurchargeAmount;
            }
            else
            {
                return NotFound();
            }

            return CreatedAtAction(nameof(GetItem), new { id = gofreightItem.CustomerID }, gofreightItem);
        }

        // DELETE: api/GoFreightItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(long id)
        {

            var gofreightItem = await _context.GoFreightItems.FindAsync(id);
            if (gofreightItem == null)
            {
                return NotFound();
            }

            _context.GoFreightItems.Remove(gofreightItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ItemExists(long id)
        {
            return (_context.GoFreightItems?.Any(e => e.CustomerID == id)).GetValueOrDefault();
        }
    }
}
