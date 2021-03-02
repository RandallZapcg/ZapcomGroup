using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MessageLibrary.Models;
using NotificationAppAPI.Data;
using Microsoft.Data.SqlClient;
using MessageLibrary;

namespace NotificationAppAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageRecipientsController : ControllerBase
    {
        private readonly NotificationAppDbContext _context;

        public MessageRecipientsController(NotificationAppDbContext context)
        {
            _context = context;
        }

        // GET: api/MessageRecipients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MessageRecipient>>> GetMessageRecipient()
        {
            return await _context.MessageRecipients.ToListAsync();
        }

        // GET: api/MessageRecipients/5
        [HttpGet("{MessageId}")]
        public async Task<ActionResult<List<MessageRecipient>>> GetMessageRecipients(int MessageId)
        {
            var messageRecipient = new MessageRecipient();
            List<MessageRecipient> messageRecipients = new List<MessageRecipient>();
            SqlParameter param = new SqlParameter("@MessengerId", MessageId);
			messageRecipients = await _context.MessageRecipients.FromSqlRaw("EXECUTE dbo.GetMessageRecipients {0}", param).ToListAsync();

            if (messageRecipients == null)
            {
                return NotFound();
            }

            return messageRecipients;
        }

        // PUT: api/MessageRecipients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMessageRecipient(int id, MessageRecipient messageRecipient)
        {
            if (id != messageRecipient.MessageRecipientId)
            {
                return BadRequest();
            }

            _context.Entry(messageRecipient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MessageRecipientExists(id))
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

        // POST: api/MessageRecipients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MessageRecipient>> PostMessageRecipient(MessageRecipient messageRecipient)
        {
            _context.MessageRecipients.Add(messageRecipient);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMessageRecipient", new { id = messageRecipient.MessageRecipientId }, messageRecipient);
        }

        // DELETE: api/MessageRecipients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMessageRecipient(int id)
        {
            var messageRecipient = await _context.MessageRecipients.FindAsync(id);
            if (messageRecipient == null)
            {
                return NotFound();
            }

            _context.MessageRecipients.Remove(messageRecipient);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MessageRecipientExists(int id)
        {
            return _context.MessageRecipients.Any(e => e.MessageRecipientId == id);
        }
    }
}
