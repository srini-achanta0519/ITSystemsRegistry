using BackEnd.Data;
using BackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ItSystemsController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<ItSystemsController> _logger;

    public ItSystemsController(ApplicationDbContext context, ILogger<ItSystemsController> logger)
    {
        _context = context;
        _logger = logger;
    }

    // GET: api/ItSystems
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ItSystem>>> GetItSystems()
    {
        return await _context.ItSystems.ToListAsync();
    }

    // GET: api/ItSystems/5
    [HttpGet("{id}")]
    public async Task<ActionResult<ItSystem>> GetItSystem(int id)
    {
        var itSystem = await _context.ItSystems.FindAsync(id);

        if (itSystem == null)
        {
            return NotFound();
        }

        return itSystem;
    }

    // PUT: api/ItSystems/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutItSystem(int id, ItSystem itSystem)
    {
        if (id != itSystem.Id)
        {
            return BadRequest();
        }

        _context.Entry(itSystem).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ItSystemExists(id))
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

    // POST: api/ItSystems
    [HttpPost]
    public async Task<ActionResult<ItSystem>> PostItSystem(ItSystem itSystem)
    {
        _context.ItSystems.Add(itSystem);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetItSystem), new { id = itSystem.Id }, itSystem);
    }

    // DELETE: api/ItSystems/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteItSystem(int id)
    {
        var itSystem = await _context.ItSystems.FindAsync(id);
        if (itSystem == null)
        {
            return NotFound();
        }

        _context.ItSystems.Remove(itSystem);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ItSystemExists(int id)
    {
        return _context.ItSystems.Any(e => e.Id == id);
    }
}
