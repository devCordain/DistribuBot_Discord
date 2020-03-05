namespace DistribuBot_Discord
{
    public class TicketHolder
    {
        public string Name { get; }
        public int Tickets { get; private set; }
        public TicketHolder(string name, int tickets)
        {
            Name = name;
            ModifyNumberOfTickets(tickets);
        }

        public string ModifyNumberOfTickets(int modifier)
        {
            if (Tickets + modifier <= 0)
            {
                Tickets = 0;
                return $"{Name} - All tickets removed";
            }
            else
            {
                Tickets += modifier;
                return $"{Name} - Has {Tickets} tickets";
            }
        }
}
}