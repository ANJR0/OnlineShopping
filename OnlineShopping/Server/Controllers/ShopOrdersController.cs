using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShopping.Server.Data;
using OnlineShopping.Shared.Domain;
using OnlineShopping.Server.IRepository;

namespace OnlineShopping.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopOrdersController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //public ShopOrdersController(ApplicationDbContext context)
        public ShopOrdersController(IUnitOfWork unitOfWork)
        {
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/ShopOrders
        [HttpGet]
        public async Task<ActionResult> GetShopOrders()
        {
            //return await _context.ShopOrders.ToListAsync();
            var ShopOrders = await _unitOfWork.ShopOrders.GetAll(includes: q => q.Include(x => x.Customer).Include(x => x.Staff).Include(x => x.Delivery));
            return Ok(ShopOrders);
        }

        // GET: api/ShopOrders/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<ShopOrder>> GetShopOrder(int id)
        public async Task<IActionResult> GetShopOrder(int id)
        {
            //var ShopOrder = await _context.ShopOrders.FindAsync(id);
            var ShopOrder = await _unitOfWork.ShopOrders.Get(q => q.ShopOrderID == id);

            if (ShopOrder == null)
            {
                return NotFound();
            }

            //return ShopOrder;
            return Ok(ShopOrder);
        }

        // PUT: api/ShopOrders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShopOrder(int id, ShopOrder ShopOrder)
        {
            if (id != ShopOrder.ShopOrderID)
            {
                return BadRequest();
            }

            //_context.Entry(ShopOrder).State = EntityState.Modified;
            _unitOfWork.ShopOrders.Update(ShopOrder);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!ShopOrderExists(id))
                if (!await ShopOrderExists(id))
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

        // POST: api/ShopOrders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ShopOrder>> PostShopOrder(ShopOrder ShopOrder)
        {
            //_context.ShopOrders.Add(ShopOrder);
            //await _context.SaveChangesAsync();
            await _unitOfWork.ShopOrders.Insert(ShopOrder);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetShopOrder", new { id = ShopOrder.ShopOrderID }, ShopOrder);
        }

        // DELETE: api/ShopOrders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShopOrder(int id)
        {
            //var ShopOrder = await _context.ShopOrders.FindAsync(id);
            var ShopOrder = await _unitOfWork.ShopOrders.Get(q => q.ShopOrderID == id);
            if (ShopOrder == null)
            {
                return NotFound();
            }

            //_context.ShopOrders.Remove(ShopOrder);
            //await _context.SaveChangesAsync();
            await _unitOfWork.ShopOrders.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //private bool ShopOrderExists(int id)
        private async Task<bool> ShopOrderExists(int id)
        {
            //return _context.ShopOrders.Any(e => e.ShopOrderID == id);
            var ShopOrder = await _unitOfWork.ShopOrders.Get(q => q.ShopOrderID == id);
            return ShopOrder != null;
        }
    }
}
