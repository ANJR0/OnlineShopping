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
    public class DeliveriesController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //public DeliveriesController(ApplicationDbContext context)
        public DeliveriesController(IUnitOfWork unitOfWork)
        {
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Deliveries
        [HttpGet]
        public async Task<ActionResult> GetDeliveries()
        {
            //return await _context.Deliveries.ToListAsync();
            var Deliveries = await _unitOfWork.Deliveries.GetAll(includes: q => q.Include(x => x.Staff));
            return Ok(Deliveries);
        }

        // GET: api/Deliveries/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDelivery(int id)
        {
            //var brand = await _context.Brands.FindAsync(id);
            var Delivery = await _unitOfWork.Deliveries.Get(q => q.DeliveryID == id);

            if (Delivery == null)
            {
                return NotFound();
            }

            //return brand;
            return Ok(Delivery);
        }

        // PUT: api/Deliveries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDelivery(int id, Delivery Delivery)
        {
            if (id != Delivery.DeliveryID)
            {
                return BadRequest();
            }

            //_context.Entry(brand).State = EntityState.Modified;
            _unitOfWork.Deliveries.Update(Delivery);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!BrandExists(id))
                if (!await DeliveryExists(id))
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

        // POST: api/Deliveries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Delivery>> PostDelivery(Delivery Delivery)
        {
            //_context.Brands.Add(brand);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Deliveries.Insert(Delivery);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetDelivery", new { id = Delivery.DeliveryID }, Delivery);
        }

        // DELETE: api/Deliveries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDelivery(int id)
        {
            //var brand = await _context.Brands.FindAsync(id);
            var Delivery = await _unitOfWork.Deliveries.Get(q => q.DeliveryID == id);
            if (Delivery == null)
            {
                return NotFound();
            }

            //_context.Brands.Remove(brand);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Deliveries.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> DeliveryExists(int id)
        {
            //return _context.Brands.Any(e => e.BrandID == id);
            var Delivery = await _unitOfWork.Deliveries.Get(q => q.DeliveryID == id);
            return Delivery != null;
        }
    }
}