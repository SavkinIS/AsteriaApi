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
    public class TimeSheetsController : ControllerBase
    {
        private readonly Data _context;

        public TimeSheetsController()
        {
            Data context = new Data();
            _context = context;
        }

        // GET: api/TimeSheets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TimeSheets>>> GetSheetcs()
        {
           var res = await Task.Run(()=> _context.GetTimeSheets());
            if (res.Value.Count() == 0)
            {
                return NotFound();
            }
            return res;
        }

        [HttpGet]
        [Route("GetSheets/{date}/SpecID/{specID}")]
        //date в формате дд-мм-гггг
        public async Task<ActionResult<IEnumerable<TimeSheets>>> GetSheetcs(string date, int specID)
        {
          var res = await Task.Run(() => _context.GetTimeSheets(date, specID));
            return res;
        }

        // GET: api/TimeSheets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TimeSheets>> GetTimeSheets(int id)
        {
           var sheet = await Task.Run(() => _context.GetTimeSheets(id));

            if (sheet == null)
            {
                return NotFound();
            }

            return sheet;
        }

        // PUT: api/TimeSheets/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTimeSheets(long id, TimeSheets timeSheets)
        {
            if (id != timeSheets.Id)
            {
                return BadRequest();
            }

            await Task.Run(() => _context.PutTimeSheets(timeSheets, id));

            return CreatedAtAction("GetTimeSheets", new { id = timeSheets.Id }, timeSheets);
        }

        // POST: api/TimeSheets
        [HttpPost]
        public async Task<ActionResult<TimeSheets>> PostTimeSheets(TimeSheets timeSheets)
        {
            
            await Task.Run(()=> _context.AddTimeSheets(timeSheets));

            return CreatedAtAction("GetTimeSheets", new { id = timeSheets.Id }, timeSheets);
        }

        // DELETE: api/TimeSheets/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TimeSheets>> DeleteTimeSheets(int id)
        {
            var sheets = await Task.Run(() => _context.DelSheetcs(id));
            if (sheets == null)
            {
                return NotFound();
            }

            

            return sheets;
        }
              
    }
}
