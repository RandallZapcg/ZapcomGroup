using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MessageLibrary;
using NotificationAppAPI.Data;
using Microsoft.Data.SqlClient;

namespace NotificationAppAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessengerUsersAsyncController : ControllerBase
    {
        private readonly NotificationAppDbContext _context;

        public MessengerUsersAsyncController(NotificationAppDbContext context)
        {
            _context = context;
        }

        // GET: api/MessengerUsersAsync
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MessengerUserGroup>>> GetMessengerUserGroups()
        {
            
            return await _context.MessengerUserGroups.FromSqlRaw("EXECUTE dbo.GetMessengerUserGroups").ToListAsync();
        }

        // GET: api/MessengerUsersAsync/5
        [HttpGet("{MessengerId}", Name = "GetMessengerUserGroup")]
        public async Task<ActionResult<List<MessengerUserGroup>>> GetMessengerUserGroup(int MessengerId)
        {
            SqlParameter param = new SqlParameter("@MessengerId", MessengerId);
			List<MessengerUserGroup> messengerUsers = await _context.MessengerUserGroups.FromSqlRaw("EXECUTE dbo.GetMessengerUsers {0}", param).ToListAsync();
        
            if (messengerUsers == null)
            {
                return NotFound();
            }

            return messengerUsers;
        }

        // PUT: api/MessengerUsersAsync/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMessengerUserGroup(int id, MessengerUserGroup messengerUserGroup)
        {
            if (id != messengerUserGroup.MessengerUserGroupId)
            {
                return BadRequest();
            }

            _context.Entry(messengerUserGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MessengerUserGroupExists(id))
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

        // POST: api/MessengerUsersAsync
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MessengerUserGroup>> PostMessengerUserGroup(MessengerUserGroup MessengerUserGroup)
        {
            SqlParameter param = new SqlParameter("@MessengerUserGroup", MessengerUserGroup);
			//_context.Messages.FromSqlRaw("EXECUTE dbo.AddMessage {0}", param);
			
            _context.MessengerUserGroups.Add(MessengerUserGroup);
            await _context.SaveChangesAsync();

            return StatusCode(StatusCodes.Status201Created);
        }

        // DELETE: api/MessengerUsersAsync/5    
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMessengerUserGroup(int id)
        {
            var messengerUserGroup = await _context.MessengerUserGroups.FindAsync(id);
            if (messengerUserGroup == null)
            {
                return NotFound();
            }

            _context.MessengerUserGroups.Remove(messengerUserGroup);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MessengerUserGroupExists(int id)
        {
            return _context.MessengerUserGroups.Any(e => e.MessengerUserGroupId == id);
        }
    }
}
