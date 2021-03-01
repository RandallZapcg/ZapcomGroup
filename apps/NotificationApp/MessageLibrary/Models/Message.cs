using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MessageLibrary
{
	public class Message
	{
		[Key]
		public int MessageId { get; set; }
		public int CreatorId { get; set; }
    	public string Body { get; set; }
		public string CreatorFirstName { get; set; }
		public string CreatorLastName { get; set; }
		public bool IsActive { get; set; }
    public string Channel { get; set; }
	}
}