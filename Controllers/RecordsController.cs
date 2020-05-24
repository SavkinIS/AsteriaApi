using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AsteriaApi.ContextFolder;
using AsteriaApi.Models;
using AsteriaApi.DataFolder;

namespace AsteriaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordsController : ControllerBase
    {
        private readonly Data _context;

        public RecordsController()
        {
            var context = new Data();

            _context = context;
        }
        

        // GET: api/Records
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Record>>> GetRecords()
        {
            return await Task.Run(() =>_context.GetRecords());
        }

        // GET: api/Records/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Record>> GetRecord(int id)
        {
            var record = await Task.Run(() => _context.GetRecords(id));

            if (record == null)
            {
                return NotFound();
            }

            return record;
        }

        // PUT: api/Records/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecord(long id, Record record)
        {
            if (id != record.Id)
            {
                return BadRequest();
            }

            await Task.Run(() => _context.PutRecord(record, id));

            return NoContent();
        }

        // POST: api/Records
        [HttpPost]
        public async Task<ActionResult<Record>> PostRecord(Record record)
        {
            _context.AddRecord(record);
            

            return CreatedAtAction("GetRecord", new { id = record.Id }, record);
        }

        // DELETE: api/Records/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Record>> DeleteRecord(int id)
        {
            var record = await Task.Run(() => _context.DelRecord(id));
            if (record == null)
            {
                return NotFound();
            }

           
            return record;
        }

        
    }
}
