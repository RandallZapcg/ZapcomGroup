using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MessageLibrary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NotificationAppAPI.Data;

namespace NotificationAppAPI.Controllers
{
	[Route("api/[controller]")]
	public class MessengersController : ControllerBase
	{
		private NotificationAppDbContext _context;

		public MessengersController(NotificationAppDbContext context)
		{
			_context = context;
		}

		//// GET: api/Messengers
		[HttpGet]
		public IActionResult GetMessengers()
		{
			var messengers = 
				_context
				.Messengers
				.FromSqlRaw("EXECUTE dbo.GetMessengers").ToList();

			return Ok(messengers);
		}

		//[HttpGet("{MessengerId}", Name = "dbo.GetMessengerMessages")]
		//public IActionResult GetMessengerMessages([FromBody] int messengerId)
		//{
            
		//	SqlParameter param = new SqlParameter("@MessengerId", messengerId);
        //    //var messages = _context.GetMessengerMessages(messengerId);
		//	//var messages = _context.Database.ExecuteSqlRaw("EXECUTE dbo.GetMessengerMessages {0}", messengerId);
		//	var messages = _context.Messages.FromSqlRaw("EXECUTE dbo.GetMessengerMessages {0}", messengerId);

		//	return Ok(messages);
		//}

		
		// GET: api/Messengers/5
		//[HttpGet("{id}", Name = "GetMessenger")]
		//public Messenger GetMessenger(int id)
		//{
		//	var messenger = _context.Messengers.Where(m => m.Id == id).Include(m => m.Messages).Include(m => m.Names).AsSplitQuery();
		//	return messenger.FirstOrDefault();
		//}

		// POST: api/Messengers
		[HttpPost]
		public IActionResult Post([FromBody] Messenger messenger)
		{
			_context.Messengers.Add(messenger);
			_context.SaveChanges();
			return StatusCode(StatusCodes.Status201Created);
		}

		// PUT: api/Messengers/5
		[HttpPut]
		public IActionResult Put([FromBody] Messenger messenger)
		{
			_context.Messengers.Update(messenger);
			_context.SaveChanges();
			return StatusCode(StatusCodes.Status202Accepted);
		}
		// DELETE: api/Messengers/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
			
		}
	}
}
