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
    public class CategoriesController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //public CategoriesController(ApplicationDbContext context)
        public CategoriesController(IUnitOfWork unitOfWork)
        {
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult> GetCategories()
        {
            //return await _context.Categories.ToListAsync();
            var categories = await _unitOfWork.Categories.GetAll();
            return Ok(categories);
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            //var brand = await _context.Brands.FindAsync(id);
            var category = await _unitOfWork.Categories.Get(q => q.CategoryID == id);

            if (category == null)
            {
                return NotFound();
            }

            //return brand;
            return Ok(category);
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, Category category)
        {
            if (id != category.CategoryID)
            {
                return BadRequest();
            }

            //_context.Entry(brand).State = EntityState.Modified;
            _unitOfWork.Categories.Update(category);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!BrandExists(id))
                if (!await CategoryExists(id))
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

        // POST: api/Categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {
            //_context.Brands.Add(brand);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Categories.Insert(category);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetCateogry", new { id = category.CategoryID }, category);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            //var brand = await _context.Brands.FindAsync(id);
            var category = await _unitOfWork.Categories.Get(q => q.CategoryID == id);
            if (category == null)
            {
                return NotFound();
            }

            //_context.Brands.Remove(brand);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Categories.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> CategoryExists(int id)
        {
            //return _context.Brands.Any(e => e.BrandID == id);
            var category = await _unitOfWork.Categories.Get(q => q.CategoryID == id);
            return category != null;
        }
    }
}
