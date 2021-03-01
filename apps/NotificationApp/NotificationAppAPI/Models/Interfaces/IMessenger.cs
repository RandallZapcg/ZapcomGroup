using System.Collections.Generic;
using MessageLibrary;
namespace NotificationAppAPI.Models.Interfaces
{
    public interface IMessenger
    {
        void SendMessage(Message message);
        List<Message> GetMessages();
	}
}