using Discord;
using Discord.WebSocket;
using System;
using System.IO;
using System.Threading.Tasks;

namespace DistribuBot_Discord
{
	public class Program
	{
		private DiscordSocketClient client;
		public static void Main(string[] args)
			=> new Program().MainAsync().GetAwaiter().GetResult();

		public async Task MainAsync()
		{
			client = new DiscordSocketClient();

			client.Log += Log;

			var token = File.ReadAllText("botToken.txt");

			await client.LoginAsync(TokenType.Bot, token);
			await client.StartAsync();

			// Block this task until the program is closed.
			await Task.Delay(-1);
		}
		private Task Log(LogMessage msg)
		{
			Console.WriteLine(msg.ToString());
			return Task.CompletedTask;
		}
	}
}
