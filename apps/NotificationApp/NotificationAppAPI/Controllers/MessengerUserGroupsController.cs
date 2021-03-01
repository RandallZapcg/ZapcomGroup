using System.Collections.Generic;
using System.Data;  

using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

using MessageLibrary;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace NotificationAppAPI
{
    
    [Route("api/[controller]")]
    public class MessengerUserGroupsController : Controller
    {    
        static SqlConnection conn = new SqlConnection("Server=tcp:127.0.0.1,1433;Database=NotificationsApi;UID=sa;PWD=SqlExpr@ss;");

        // GET: api/values
        [HttpGet]
        public IActionResult GetMessengerUserGroups()
        {
            List<MessengerUserGroup> messengerUserGroupsList = new List<MessengerUserGroup>();
            SqlCommand GetAllMessengerUserGroups = new SqlCommand("GetMessengerUserGroups", conn);
            conn.Open();
            messengerUserGroupsList = ReadSqlData(GetAllMessengerUserGroups, messengerUserGroupsList);
            conn.Close();
            return Ok(messengerUserGroupsList);
		}

        // GET api/values/5
        [HttpGet("{MessengerId}", Name = "GetMessengerUsers")]
        public IActionResult GetMessengerUsers([FromRoute] int MessengerId)
        {
            
            List<MessengerUserGroup> messengerUserGroupList = new List<MessengerUserGroup>();
            SqlCommand GetMessengerUsers = new SqlCommand("GetMessengerUsers", conn);
			GetMessengerUsers.CommandType = CommandType.StoredProcedure;
            GetMessengerUsers.Parameters.Add(new SqlParameter("@MessengerId", MessengerId));
			conn.Open();
			messengerUserGroupList = ReadSqlData(GetMessengerUsers, messengerUserGroupList);
			conn.Close();
			return Ok(messengerUserGroupList);
        }

        // POST api/values
        [HttpPost]
        public void PostUser([FromBody] MessengerUserGroup messengerUserGroup)
        {
			SqlCommand InsertMessengerUserGroup = new SqlCommand("InsertMessengerUserGroup", conn);
            AddUserSqlParameters(InsertMessengerUserGroup, messengerUserGroup);
            conn.Open();            
			InsertMessengerUserGroup.ExecuteNonQuery();
            conn.Close();
			Ok("MessengerUserGroup Created");
		}

        // PUT api/values/5
        //[HttpPut("{id}")]
        //public MessengerUserGroup PutUser(int id, [FromBody] MessengerUserGroup updatedUser)
        //{
            //SqlCommand UpdateUser = new SqlCommand("UpdateUser", conn);
            //updatedUser.UserId = id;
            //AddUserSqlParameters(UpdateUser, updatedUser);
            //conn.Open();
            //UpdateUser.ExecuteNonQuery();
            //MessengerUserGroup messengerUserGroup = ReadSqlData(UpdateUser, updatedUser);
            //conn.Close();
			//Ok("MessengerUserGroup Created");
			//return messengerUserGroup;
		//}

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
			SqlCommand DeleteUser = new SqlCommand("DeleteUser", conn);
            DeleteUser.CommandType = CommandType.StoredProcedure;
            DeleteUser.Parameters.Add(new SqlParameter("@UserId", id));
			conn.Open();
			DeleteUser.ExecuteNonQuery();
			conn.Close();
			Ok("MessengerUserGroup Deleted");
		}

        private static void AddUserSqlParameters(SqlCommand command, MessengerUserGroup messengerUserGroup)
        {
            command.CommandType = CommandType.StoredProcedure;
			InsertParam(command, "@MessengerId", messengerUserGroup.MessengerId);
			InsertParam(command, "@UserId", messengerUserGroup.UserId);
			InsertParam(command, "@ChannelName", messengerUserGroup.ChannelName);
			InsertParam(command, "@UserEmail", messengerUserGroup.UserEmail);
		}
        private static void InsertParam(SqlCommand command, string name, dynamic value) {
			command
                .Parameters
                .Add(new SqlParameter(name, SqlDbType.VarChar))
                .Value = value;
		}

        private static List<MessengerUserGroup> ReadSqlData(SqlCommand command, List<MessengerUserGroup> messengerUserGroups) 
        {
            MessengerUserGroup messengerUserGroup = null;
            
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
				messengerUserGroup = new MessengerUserGroup((SqlDataReader)reader);
				messengerUserGroups.Add(messengerUserGroup);
			}
			return messengerUserGroups;
		}
    }
}
