public class TicketsData
{
    public static Dictionary<int, Ticket[]> Tickets = new Dictionary<int, Ticket[]>();
    public void slotsInitialisation(int twoWheelerSlots, int fourWheelerSlots, int heavyVehicleSlots)
    {
        Tickets.Add(1, new Ticket[twoWheelerSlots]);
        Tickets.Add(2, new Ticket[fourWheelerSlots]);
        Tickets.Add(3, new Ticket[heavyVehicleSlots]);
    }

}