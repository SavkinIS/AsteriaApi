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
using Microsoft.AspNetCore.Authorization;

namespace AsteriaApi.Controllers
{

    
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClientsController : ControllerBase
    {
        private readonly Data _context;

        public ClientsController()
        {
            var context  = new Data();

            _context = context;
        }

        // GET: api/Clients
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Client>>> GetAClients()
        {
            var x = Task.Run (()=>_context.GetClients());
           
            return await x;
        }

        // GET: api/Clients/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Client>> GetClient(int id)
        {
            var client = Task.Run(() => _context.GetClients(id));



            return await client;
        }

        // PUT: api/Clients/5
        [HttpPut("{id}")]
        
        public async Task<IActionResult> PutClient( Client client, long id)
        {
            var res = await Task.Run(() => _context.PutClient(client, id));

            if (res == "BadRequest") return BadRequest();
            else if (res == "NotFound") return NotFound();
            else if (res == "Cant Change Clients ID") return BadRequest("Cant Change Clients ID");

            return NoContent();
        }

        // POST: api/Clients
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<Client>> PostClient(Client client)
        {

            await Task.Run(()=> _context.AddClient(client));

            return CreatedAtAction("GetClient", new { id = client.Id }, client);
        }

        
        // DELETE: api/Clients/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Client>> DeleteClient(int id)
        {
            var client = await Task.Run(() =>  _context.DelClient(id));
            if (client == null)
            {
                return NotFound();
            }
            return client;
        }
        
        
        
    }
}


