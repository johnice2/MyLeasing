using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyLeasing.Web.Data;
using MyLeasing.Web.Data.Entities;

namespace MyLeasing.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyTypesController : ControllerBase
    {
        private readonly DataContext _context;

        public PropertyTypesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/PropertyTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PropertyType>>> GetPropertyTypes()
        {
            return await _context.PropertyTypes.ToListAsync();
        }

        // GET: api/PropertyTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PropertyType>> GetPropertyType(int id)
        {
            var propertyType = await _context.PropertyTypes.FindAsync(id);

            if (propertyType == null)
            {
                return NotFound();
            }

            return propertyType;
        }

        // PUT: api/PropertyTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPropertyType(int id, PropertyType propertyType)
        {
            if (id != propertyType.Id)
            {
                return BadRequest();
            }

            _context.Entry(propertyType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PropertyTypeExists(id))
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

        // POST: api/PropertyTypes
        [HttpPost]
        public async Task<ActionResult<PropertyType>> PostPropertyType(PropertyType propertyType)
        {
            _context.PropertyTypes.Add(propertyType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPropertyType", new { id = propertyType.Id }, propertyType);
        }

        // DELETE: api/PropertyTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PropertyType>> DeletePropertyType(int id)
        {
            var propertyType = await _context.PropertyTypes.FindAsync(id);
            if (propertyType == null)
            {
                return NotFound();
            }

            _context.PropertyTypes.Remove(propertyType);
            await _context.SaveChangesAsync();

            return propertyType;
        }

        private bool PropertyTypeExists(int id)
        {
            return _context.PropertyTypes.Any(e => e.Id == id);
        }
    }
}
