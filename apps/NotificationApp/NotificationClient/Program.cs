using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using MessageLibrary;

namespace NotificationClient
{
	class Program
	{
		static HttpClient client = new HttpClient();
		static string path = null;
		static int MessageCount = 0;
		//static Messenger Messenger = null;

		static int RoomId = 0;
		static string Name = null;
		//static bool Dirty = false;
		static void DisplayMessages(IEnumerable<Message> messages)
		{
			foreach (Message message in messages)
			{
				Console.WriteLine($"{message.MessageId}. : " +
					$"{message.Body}");
			}
			MessageCount = messages.Count();
            NewPrompt();   
		}   
		static void ShowMessages()
		{
			//Messenger = await GetMessengerAsync();
			//var messages = Messenger.Messages;
			//if (MessageCount < messages.Count())
			//{
			//	int count = messages.Count() - MessageCount;
			//	var newMessages = Messenger.Messages.TakeLast(count);
			//	DisplayMessages(newMessages);
			//}
			//if (Dirty == true && MessageCount == messages.Count()) System.Console.WriteLine("No new messages");
			//Dirty = true;
			//MessageCount = messages.Count();
			System.Console.WriteLine("ShowMEssages");
		}
        
		static void ShowSomeMessages(int num)
		{
			//IEnumerable<Message> messages = Messenger.Messages.TakeLast(num);
			//DisplayMessages(messages);
			System.Console.WriteLine("ShowSomeMessages");
		}
		static void ShowAllMessages()
		{
			//var messages = await GetMessengerMessagesAsync();
			//System.Console.WriteLine(Messenger);
			//DisplayMessages(Messenger.Messages);
			System.Console.WriteLine("ShowAllMessages");
		}
		static async Task CreateMessageAsync(Message message)
		{
			HttpResponseMessage response = await client.PostAsJsonAsync(
				"api/messages", message);
			response.EnsureSuccessStatusCode();
		}
		static async void CreateMessengerAsync(Message message)
		{
			HttpResponseMessage response = await client.PostAsJsonAsync(
				"api/messages", message);
			response.EnsureSuccessStatusCode();
		}
		static async Task<Messenger> GetMessengerAsync()
		{
			Messenger messenger = null;

			HttpResponseMessage response = await client.GetAsync(path.ToString());
			if (response.IsSuccessStatusCode)
			{
				messenger = await response.Content.ReadAsAsync<Messenger>();
			}

			return messenger;
		}
		static void Main(string[] args)
		{
			RunAsync().GetAwaiter().GetResult();
		}

		static async Task RunAsync()
		{
			// Update port # in the following line.
			client.BaseAddress = new Uri("https://localhost:5001/");
			client.DefaultRequestHeaders.Accept.Clear();
			client.DefaultRequestHeaders.Accept.Add(
				new MediaTypeWithQualityHeaderValue("application/json")
			);
			try
			{
				Console.WriteLine("Name:");
				Name = Console.ReadLine();
				Console.WriteLine($"Hello {Name}");
				Console.WriteLine($"Room Id?");
				RoomId = Convert.ToInt32(Console.ReadLine());
				Console.WriteLine($"Entering Room{RoomId}...");
				path = $"{client.BaseAddress}api/Messengers/{RoomId}".ToString();
				// Get the messenger
				Messenger messenger = await GetMessengerAsync();
				//DisplayMessages(messenger.Messages);
				NewPrompt();
			}
			catch (Exception e)
			{
				Console.WriteLine($"ERR: {e}");
			}
		}

		private static async Task<List<Message>> GetMessengerMessagesAsync()
		{

			List<Message> messages = null;

			HttpResponseMessage response = await client.GetAsync(path.ToString());
			if (response.IsSuccessStatusCode)
			{
				messages = await response.Content.ReadAsAsync<List<Message>>();
			}

			return messages;
		}

		static async void NewPrompt()
		{
			Console.WriteLine($"Type your message ($new for new messages. $all for all messages.)");
			string command = Console.ReadLine();
            if (command != "$new" && command != "$all")
            {
                Message message = new Message
                {
                    //UserId = serId,
                    //MessengerId = RoomId,
                    Body = command
                };
				await CreateMessageAsync(message);
                ShowMessages();
                NewPrompt();                    
			}
			if (command == "$all")
			{
				//System.Console.WriteLine("How Many?");
				//int num = Convert.ToInt32(Console.ReadLine());
				ShowAllMessages();
                
			}
                else 
			{
				//System.Console.WriteLine("How Many?");
				//int num = Convert.ToInt32(Console.ReadLine());
				ShowMessages();
                NewPrompt();
			}
			   NewPrompt();
                
		}
		
	}
}
