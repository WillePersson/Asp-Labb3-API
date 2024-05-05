using Asp_Labb3_API.Data;
using Asp_Labb3_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Asp_Labb3_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterestsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public InterestsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("{personId}")]
        public async Task<ActionResult<IEnumerable<Interest>>> GetInterestsByPerson(int personId)
        {
            var interests = await _context.PersonInterests
                                          .Where(pi => pi.PersonId == personId)
                                          .Select(pi => pi.Interest) 
                                          .Distinct() 
                                          .ToListAsync();
            return interests;
        }



        [HttpPost("connect")]
        public async Task<ActionResult> ConnectPersonToInterest([FromBody] PersonInterest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool personExists = await _context.People.AnyAsync(p => p.PersonId == model.PersonId);
            bool interestExists = await _context.Interests.AnyAsync(i => i.InterestId == model.InterestId);

            if (!personExists || !interestExists)
            {
                return NotFound("Person or Interest not found.");
            }

            bool connectionExists = await _context.PersonInterests.AnyAsync(pi => pi.PersonId == model.PersonId && pi.InterestId == model.InterestId);
            if (connectionExists)
            {
                return BadRequest("This connection already exists.");
            }

            _context.PersonInterests.Add(model);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }

            return CreatedAtAction(nameof(GetInterestsByPerson), new { personId = model.PersonId }, model);
        }
    }

}
