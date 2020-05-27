using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationTask.Business.Business;
using WebApplicationTask.Business.IBusiness;
using WebApplicationTask.Entity;
using WebApplicationTask.Entity.Models;

namespace WebApplicationTask.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Base_UserController : ControllerBase
    {
        private readonly BaseDbContext _context;

        public Base_UserController(BaseDbContext context)
        {
            _context = context;
        }
        //public IRepositoryWrapper RepositoryWrapper { get; }
        //public IMapper Mapper { get; }
        //public Base_UserController(IRepositoryWrapper repositoryWrapper,IMapper mapper)
        //{
        //    RepositoryWrapper = repositoryWrapper;
        //    Mapper = mapper;
        //}

        // GET: api/Base_User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Base_User>>> GetBase_User()
        {
            return await _context.Base_User.ToListAsync();
        }

        // GET: api/Base_User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Base_User>> GetBase_User(int id)
        {
            var base_User = await _context.Base_User.FindAsync(id);

            if (base_User == null)
            {
                return NotFound();
            }

            return base_User;
        }

        // PUT: api/Base_User/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBase_User(int id, Base_User base_User)
        {
            if (id != base_User.Id)
            {
                return BadRequest();
            }

            _context.Entry(base_User).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Base_UserExists(id))
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

        // POST: api/Base_User
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Base_User>> PostBase_User(Base_User base_User)
        {
            _context.Base_User.Add(base_User);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBase_User", new { id = base_User.Id }, base_User);
        }

        // DELETE: api/Base_User/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Base_User>> DeleteBase_User(int id)
        {
            var base_User = await _context.Base_User.FindAsync(id);
            if (base_User == null)
            {
                return NotFound();
            }

            _context.Base_User.Remove(base_User);
            await _context.SaveChangesAsync();

            return base_User;
        }

        private bool Base_UserExists(int id)
        {
            return _context.Base_User.Any(e => e.Id == id);
        }
    }
}
