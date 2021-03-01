using System.ComponentModel.DataAnnotations;

namespace MessageLibrary.Models
{
    public class MessageRecipient
    {
		[Key]
		public int MessageRecipientId { get; set; }
    	public int UserId { get; set; }
		public string MessengerUserGroupId { get; set; }
		public string MessageId { get; set; }
    }
}