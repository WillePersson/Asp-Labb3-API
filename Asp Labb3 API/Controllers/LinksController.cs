using Asp_Labb3_API.Data;
using Asp_Labb3_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Asp_Labb3_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinksController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LinksController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("{personId}")]
        public async Task<ActionResult<IEnumerable<InterestLink>>> GetLinksByPerson(int personId)
        {
            var links = await _context.InterestLinks
                                      .Where(l => l.PersonId == personId)
                                      .ToListAsync();
            return links;
        }
        [HttpPost]
        public async Task<ActionResult<InterestLink>> AddLink([FromBody] InterestLink link)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);  
            }

            var personExists = await _context.People.AnyAsync(p => p.PersonId == link.PersonId);
            var interestExists = await _context.Interests.AnyAsync(i => i.InterestId == link.InterestId);
            if (!personExists || !interestExists)
            {
                return NotFound("Person or Interest not found.");  
            }

            try
            {
                _context.InterestLinks.Add(link);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request."); 
            }

            return CreatedAtAction(nameof(GetLinksByPerson), new { personId = link.PersonId }, link);
        }
    }

}
