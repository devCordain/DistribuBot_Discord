using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.IO;
using System.Threading.Tasks;

namespace DistribuBot_Discord
{
	public class Program
	{
		private DiscordSocketClient client;
		private CommandService commandService;
		private CommandHandler commandHandler;
		public static Lottery lottery = null;
		public static void Main(string[] args)
			=> new Program().MainAsync().GetAwaiter().GetResult();

		public async Task MainAsync()
		{
			client = new DiscordSocketClient();
			commandService = new CommandService();
			commandHandler = new CommandHandler(client, commandService);
			
			client.Log += Log;

			var token = File.ReadAllText("botToken.txt");
			await client.LoginAsync(TokenType.Bot, token);
			await client.StartAsync();
			await commandHandler.InstallCommandsAsync();

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
