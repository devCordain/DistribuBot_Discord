using System;
using System.Collections.Generic;

namespace DistribuBot_Discord
{
    public class Lottery
    {
        private List<TicketHolder> ticketHolders;
        public Lottery()
        {
            ticketHolders = new List<TicketHolder>();
        }

        public string UpdateNumberOfTickets(string name, int modifier)
        {
            try
            {
                return ticketHolders.Find(x => x.Name == name).ModifyNumberOfTickets(modifier);
            }
            catch (Exception)
            {
                var newTicketHolder = new TicketHolder(name, modifier);
                ticketHolders.Add(newTicketHolder);
                return $"{newTicketHolder.Name} now has {newTicketHolder.Tickets} tickets";
            }
        }

        public string DrawWinner()
        {
            var random = new Random();
            var numberOfTickets = 0;
            var participants = "";
            foreach (var ticketHolder in ticketHolders)
            {
                participants += ticketHolder.Name + ", Tickets: " + ticketHolder.Tickets;
                numberOfTickets += ticketHolder.Tickets;
            }

            var winningTicketNumber = random.Next(1, numberOfTickets);
            numberOfTickets = 0;

            foreach (var ticketHolder in ticketHolders)
            {
                numberOfTickets += ticketHolder.Tickets;
                if (numberOfTickets >= winningTicketNumber)
                {
                    return participants + $". The winning ticket number was {winningTicketNumber}, belonging to {ticketHolder.Name}"; 
                }
            }
            return "Unable to pick winner";
        }
    }
}
