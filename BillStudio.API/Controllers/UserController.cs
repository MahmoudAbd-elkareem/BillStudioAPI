using BillStudio.Domain.Entities;
using BillStudioApplication.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BillStudioAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRepository<User> _context;

        public UserController(IRepository<User> context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> getall()
        {
           throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> AmenityById(Guid id)
        {
            User p = await _context.GetByIdAsync(id);
            return Ok(p);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAmenity(Guid id)
        {
            await _context.DeleteAsync(id);
            return Ok("deleted");
        }

        [HttpPost]
        public async Task<ActionResult> AddAmenity(User user)
        {
            Guid x = await _context.InsertAsync(user);
            return Ok(x);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAmenity(User user)
        {
            await _context.UpdateAsync(user);
            return Ok("Amenity Updated");
        }

    }
}
