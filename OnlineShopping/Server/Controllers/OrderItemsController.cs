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
    public class OrderItemsController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //public OrderItemsController(ApplicationDbContext context)
        public OrderItemsController(IUnitOfWork unitOfWork)
        {
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/OrderItems
        [HttpGet]
        public async Task<ActionResult> GetOrderItems()
        {
            //return await _context.OrderItems.ToListAsync();
            var OrderItems = await _unitOfWork.OrderItems.GetAll(includes: q => q.Include(x =>x.Product).Include(x => x.ShopOrder));
            return Ok(OrderItems);
        }

        // GET: api/OrderItems/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<OrderItem>> GetOrderItem(int id)
        public async Task<IActionResult> GetOrderItem(int id)
        {
            //var OrderItem = await _context.OrderItems.FindAsync(id);
            var OrderItem = await _unitOfWork.OrderItems.Get(q => q.OrderItemID == id);

            if (OrderItem == null)
            {
                return NotFound();
            }

            //return OrderItem;
            return Ok(OrderItem);
        }

        // PUT: api/OrderItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderItem(int id, OrderItem OrderItem)
        {
            if (id != OrderItem.OrderItemID)
            {
                return BadRequest();
            }

            //_context.Entry(OrderItem).State = EntityState.Modified;
            _unitOfWork.OrderItems.Update(OrderItem);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!OrderItemExists(id))
                if (!await OrderItemExists(id))
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

        // POST: api/OrderItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrderItem>> PostOrderItem(OrderItem OrderItem)
        {
            //_context.OrderItems.Add(OrderItem);
            //await _context.SaveChangesAsync();
            await _unitOfWork.OrderItems.Insert(OrderItem);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetOrderItem", new { id = OrderItem.OrderItemID }, OrderItem);
        }

        // DELETE: api/OrderItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderItem(int id)
        {
            //var OrderItem = await _context.OrderItems.FindAsync(id);
            var OrderItem = await _unitOfWork.OrderItems.Get(q => q.OrderItemID == id);
            if (OrderItem == null)
            {
                return NotFound();
            }

            //_context.OrderItems.Remove(OrderItem);
            //await _context.SaveChangesAsync();
            await _unitOfWork.OrderItems.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //private bool OrderItemExists(int id)
        private async Task<bool> OrderItemExists(int id)
        {
            //return _context.OrderItems.Any(e => e.OrderItemID == id);
            var OrderItem = await _unitOfWork.OrderItems.Get(q => q.OrderItemID == id);
            return OrderItem != null;
        }
    }
}
