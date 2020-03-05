using System;
using Discord.Commands;
using System.Threading.Tasks;

namespace DistribuBot_Discord
{
    [Group("lottery")]
    [Alias("lot", "Lot", "lo", "Lottery", "bid")]
    public class LotteryModule : ModuleBase<SocketCommandContext>
    {
        [Command("open")]
        [Alias("op", "Open", "OP", "start", "go")]
        public async Task OpenAsync([Summary("Lottery item name")] string name = "THAT ITEM YOU SPOKE ABOUT ON DISCORD")
        {

            Program.lottery = new Lottery(name);
            await ReplyAsync($"Purchase of tickets for {Program.lottery.Name} is now open! To purchase tickets type '!lottery ticket' followed by the number of tickets you would like (1 gold per ticket)");
            Console.WriteLine($"Lottery for {Program.lottery.Name} is open");
        }

        [Command("close")]
        [Alias("cl", "CL", "end")]
        public async Task CloseAsync()
        {
            await ReplyAsync(Program.lottery.DrawWinner());
            Console.WriteLine($"Lottery for {Program.lottery.Name} is closed");
            Program.lottery = null;
        }

        [Command("ticket")]
        [Alias("tickets","tick", "Ticket", "Tickets","Tick", "ti")]
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
