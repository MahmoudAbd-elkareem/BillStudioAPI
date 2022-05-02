using BillStudio.Domain.Entities;
using BillStudioApplication.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BillStudioAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class StudioController : ControllerBase
    {
        private readonly IRepository<Studio> _context;

        public StudioController(IRepository<Studio> context)
        {
            _context = context;
        }

        [HttpGet("userStudios/{userId}")]
        public async Task<ActionResult> getall(Guid userId)
        {
            return Ok(await _context.GetAllAsync(userId));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Studio>> AmenityById(Guid id)
        {
            Studio p = await _context.GetByIdAsync(id);
            return Ok(p);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAmenity(Guid id)
        {
            await _context.DeleteAsync(id);
            return Ok("deleted");
        }

        [HttpPost]
        public async Task<ActionResult> AddAmenity(Studio studio)
        {
            Guid x = await _context.InsertAsync(studio);
            return Ok(x);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAmenity(Studio studio)
        {
            await _context.UpdateAsync(studio);
            return Ok("Amenity Updated");
        }
    }
}
