using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaquinasController : ControllerBase
    {
        private readonly APIContext _context;

        public MaquinasController(APIContext context)
        {
            _context = context;
        }

        // GET: api/Maquinas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Maquina>>> GetMaquinas_Registradoras()
        {
            return await _context.Maquinas_Registradoras.ToListAsync();
        }

        // GET: api/Maquinas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Maquina>> GetMaquina(int id)
        {
            var maquina = await _context.Maquinas_Registradoras.FindAsync(id);

            if (maquina == null)
            {
                return NotFound();
            }

            return maquina;
        }

        // PUT: api/Maquinas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaquina(int id, Maquina maquina)
        {
            if (id != maquina.Codigo)
            {
                return BadRequest();
            }

            _context.Entry(maquina).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaquinaExists(id))
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

        // POST: api/Maquinas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Maquina>> PostMaquina(Maquina maquina)
        {
            _context.Maquinas_Registradoras.Add(maquina);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMaquina", new { id = maquina.Codigo }, maquina);
        }

        // DELETE: api/Maquinas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Maquina>> DeleteMaquina(int id)
        {
            var maquina = await _context.Maquinas_Registradoras.FindAsync(id);
            if (maquina == null)
            {
                return NotFound();
            }

            _context.Maquinas_Registradoras.Remove(maquina);
            await _context.SaveChangesAsync();

            return maquina;
        }

        private bool MaquinaExists(int id)
        {
            return _context.Maquinas_Registradoras.Any(e => e.Codigo == id);
        }
    }
}
