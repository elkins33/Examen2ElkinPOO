using Examen2_ElkinBohorquez.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Examen2_ElkinBohorquez.Modelos;
using Examen2_ElkinBohorquez.Database;

[Route("api/[controller]")]
[ApiController]
public class ClientsController : ControllerBase
{
    private readonly DBPrestamoContext _context;

    public ClientsController(DBPrestamoContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Cliente>>> GetClients()
    {
        return await _context.Cliente.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Cliente>> GetClient(int id)
    {
        var client = await _context.Cliente.FindAsync(id);

        if (client == null)
        {
            return NotFound();
        }
        return client;
    }

    [HttpPost]
    public async Task<ActionResult<Cliente>> PostClient(Cliente cliemte)
    {
        _context.Cliente.Add(cliemte);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetClient), new { id = cliemte }, cliemte);
    }
}