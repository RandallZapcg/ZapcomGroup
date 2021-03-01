using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace MessageLibrary
{
    public class MessengerUserGroup
    {
        public MessengerUserGroup(){}
        public MessengerUserGroup(IDataReader reader)
        {
            this.MessengerId = (int)reader["MessengerId"];
            this.UserId = (int)reader["UserId"];
            this.MessengerUserGroupId = (int)reader["MessengerUserGroupId"];
            this.ChannelName = (string)reader["ChannelName"];
            this.UserEmail = (string)reader["User"];
    }
        [Key]
        public int MessengerUserGroupId { get; set; }
        public string ChannelName { get; set; }
        public string UserEmail { get; set; }
		public int MessengerId { get; set; }
        public int UserId { get; set; }
	}
}