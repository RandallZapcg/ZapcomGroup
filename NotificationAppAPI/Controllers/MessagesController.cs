using System.Net.Http;
using System.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using MessageLibrary;
using Microsoft.EntityFrameworkCore;
using NotificationAppAPI.Data;
using Microsoft.Data.SqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NotificationAppAPI.Controllers
{
    [Route("api/[controller]")]
    public class MessagesController : Controller
    {
        private NotificationAppDbContext _context;

		public MessagesController(NotificationAppDbContext context)
        {
			_context = context;
		}

		// GET: api/Messengers
		[HttpGet]
        public IActionResult Get()
        {

            return Ok(_context.Messages);
        }

        [HttpGet("{MessengerId}", Name = "GetMessages")]
        
		public IActionResult GetMessages([FromRoute] int MessengerId)
		{
            SqlParameter param = new SqlParameter("@MessengerId", MessengerId);

			var messages = _context.Messages.FromSqlRaw("EXECUTE dbo.GetMessengerMessages {0}", param);
			return Ok(messages);
		}

        //// GET: api/Messengers/5
        //[HttpGet("{id}", User = "Get")]
        //public Message Get(int id)  
        //{   
        //    var message = _context.Messages.Find(id);
		//	return message;
		//}

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Message Message)
        {
            SqlParameter param = new SqlParameter("@Message", Message);
			 _context.Messages.Add(Message);
			//_context.Messages.FromSqlRaw("EXECUTE dbo.AddMessage {0}", param);
			_context.SaveChanges();
			return StatusCode(StatusCodes.Status201Created);
		}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //    var message = _context.Messages.Find(id);

        //}
    }
}
