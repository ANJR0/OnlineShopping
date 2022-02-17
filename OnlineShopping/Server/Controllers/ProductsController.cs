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
    public class ProductsController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //public ProductsController(ApplicationDbContext context)
        public ProductsController(IUnitOfWork unitOfWork)
        {
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult> GetProducts()
        {
            //return await _context.Products.ToListAsync();
            var Products = await _unitOfWork.Products.GetAll(includes: q => q.Include(x => x.Brand).Include(x => x.Category));
            return Ok(Products);
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<Product>> GetProduct(int id)
        public async Task<IActionResult> GetProduct(int id)
        {
            //var Product = await _context.Products.FindAsync(id);
            var Product = await _unitOfWork.Products.Get(q => q.ProductID == id);

            if (Product == null)
            {
                return NotFound();
            }

            //return Product;
            return Ok(Product);
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product Product)
        {
            if (id != Product.ProductID)
            {
                return BadRequest();
            }

            //_context.Entry(Product).State = EntityState.Modified;
            _unitOfWork.Products.Update(Product);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!ProductExists(id))
                if (!await ProductExists(id))
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

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product Product)
        {
            //_context.Products.Add(Product);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Products.Insert(Product);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetProduct", new { id = Product.ProductID }, Product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            //var Product = await _context.Products.FindAsync(id);
            var Product = await _unitOfWork.Products.Get(q => q.ProductID == id);
            if (Product == null)
            {
                return NotFound();
            }

            //_context.Products.Remove(Product);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Products.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //private bool ProductExists(int id)
        private async Task<bool> ProductExists(int id)
        {
            //return _context.Products.Any(e => e.ProductID == id);
            var Product = await _unitOfWork.Products.Get(q => q.ProductID == id);
            return Product != null;
        }
    }
}
