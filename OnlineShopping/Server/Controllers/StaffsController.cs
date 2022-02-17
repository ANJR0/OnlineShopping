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
    public class StaffsController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //public StaffsController(ApplicationDbContext context)
        public StaffsController(IUnitOfWork unitOfWork)
        {
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Staffs
        [HttpGet]
        public async Task<ActionResult> GetStaffs()
        {
            //return await _context.Staffs.ToListAsync();
            var Staffs = await _unitOfWork.Staffs.GetAll();
            return Ok(Staffs);
        }

        // GET: api/Staffs/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<Staff>> GetStaff(int id)
        public async Task<IActionResult> GetStaff(int id)
        {
            //var Staff = await _context.Staffs.FindAsync(id);
            var Staff = await _unitOfWork.Staffs.Get(q => q.StaffID == id);

            if (Staff == null)
            {
                return NotFound();
            }

            //return Staff;
            return Ok(Staff);
        }

        // PUT: api/Staffs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStaff(int id, Staff Staff)
        {
            if (id != Staff.StaffID)
            {
                return BadRequest();
            }

            //_context.Entry(Staff).State = EntityState.Modified;
            _unitOfWork.Staffs.Update(Staff);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!StaffExists(id))
                if (!await StaffExists(id))
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

        // POST: api/Staffs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Staff>> PostStaff(Staff Staff)
        {
            //_context.Staffs.Add(Staff);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Staffs.Insert(Staff);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetStaff", new { id = Staff.StaffID }, Staff);
        }

        // DELETE: api/Staffs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStaff(int id)
        {
            //var Staff = await _context.Staffs.FindAsync(id);
            var Staff = await _unitOfWork.Staffs.Get(q => q.StaffID == id);
            if (Staff == null)
            {
                return NotFound();
            }

            //_context.Staffs.Remove(Staff);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Staffs.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //private bool StaffExists(int id)
        private async Task<bool> StaffExists(int id)
        {
            //return _context.Staffs.Any(e => e.StaffID == id);
            var Staff = await _unitOfWork.Staffs.Get(q => q.StaffID == id);
            return Staff != null;
        }
    }
}
