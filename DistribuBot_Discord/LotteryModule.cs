using System;
using Discord.Commands;
using System.Threading.Tasks;

namespace DistribuBot_Discord
{
    [Group("lottery")]
    public class LotteryModule : ModuleBase<SocketCommandContext>
    {
        [Command("open")]
        public async Task OpenAsync()
        {
            Console.WriteLine("lottery Open");
            Program.lottery = new Lottery();
            await ReplyAsync($"Purchase of tickets is now open! To purchase tickets type '!lottery tickets' followed by the number of tickets you would like (1 gold per ticket)");
        }

        [Command("close")]
        public async Task CloseAsync()
        {
            Console.WriteLine("lottery closed");
            await ReplyAsync(Program.lottery.DrawWinner());
            Program.lottery = null;
        }

        [Command("tickets")]
        [Summary("Purchases tickets")]
        public async Task TicketsAsync([Summary("The number of tickets to buy")] int num = 0)
        {
            if (Program.lottery != null)
            {
                await ReplyAsync(Program.lottery.UpdateNumberOfTickets(Context.User.Username, num));
            }
            else
            {
                await ReplyAsync("No lottery currently running");
            }
        }
    }
}
