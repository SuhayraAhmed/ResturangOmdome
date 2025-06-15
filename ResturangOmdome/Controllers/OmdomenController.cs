using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResturangOmdome.Models;

namespace ResturangOmdome.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OmdomenController : ControllerBase
    {
        private readonly APIDbContext _context;

        public OmdomenController(APIDbContext context)
        {
            _context = context;
        }

        // GET: api/omdomen
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Omdome>>> GetAllaOmdomen()
        {
            return await _context.Omdomen.ToListAsync();
        }

        // GET: api/omdomen/restaurang/5
        [HttpGet("restaurang/{restaurangId}")]
        public async Task<ActionResult<IEnumerable<Omdome>>> GetOmdomenForRestaurang(int restaurangId)
        {
            return await _context.Omdomen
                .Where(o => o.RestaurangId == restaurangId)
                .ToListAsync();
        }

        // POST: api/omdomen
        [HttpPost]
        public async Task<IActionResult> AddOmdome([FromBody] Omdome omdome)
        {
            if (omdome.Betyg < 1 || omdome.Betyg > 5)
                return BadRequest("Betyg måste vara mellan 1 och 5.");

            _context.Omdomen.Add(omdome);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOmdomenForRestaurang), new { restaurangId = omdome.RestaurangId }, omdome);
        }
    }
}
