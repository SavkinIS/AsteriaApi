using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsteriaApi.DataFolder;
using AsteriaApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AsteriaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialistsController : ControllerBase
    {
        private readonly Data _context;

        public SpecialistsController()
        {
            Data context = new Data();
            _context = context;
        }

        // GET: api/Specialists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Specialist>>> GetSpecialists()
        {
            return await Task.Run(() =>_context.GetSpecialists());
        }

        // GET: api/Specialists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Specialist>> GetSpecialist(int id)
        {
            var spec = await Task.Run(() => _context.GetSpecialists(id));

            if (spec == null)
            {
                return NotFound();
            }

            return spec;
        }

        // PUT: api/Specialists/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSpecialist(long id, Specialist spec)
        {
            if (id != spec.Id)
            {
                return BadRequest();
            }

            await Task.Run(() => _context.PutSpecialist(spec, id));

            return NoContent();
        }

        // POST: api/Records
        [HttpPost]
        public async Task<ActionResult<Record>> PostSpecialist(Specialist spec)
        {
            _context.AddSpecialist(spec);
            

            return CreatedAtAction("GetSpecialist", new { id = spec.Id }, spec);
        }

        // DELETE: api/Records/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Specialist>> DeleteSpecialist(int id)
        {
            var spec = await Task.Run(() => _context.DelSpecialist(id));
            if (spec == null)
            {
                return NotFound();
            }


            return spec;
        }

    }
}
