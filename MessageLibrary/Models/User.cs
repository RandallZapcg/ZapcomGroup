using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;

namespace MessageLibrary
{
	public class User
	{
		public User(){}
		public User(IDataReader reader)
		{
			this.UserId = (int)reader["UserId"];
			this.FirstName = reader["FirstName"].ToString();
			this.LastName = reader["LastName"].ToString();
			this.Email = reader["Email"].ToString();
		}
		public int UserId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
  }
}