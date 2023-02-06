using ParkingLotManagementSystem;

public class ParkingLot
{
    public int twoWheeler, fourWheeler, heavyVehicle;
    public static int TokenNumber = 1;
    public ParkingLot(){}
    public ParkingLot(int twoWheelerSlots, int fourWheelerSlots, int heavyVehicleSlots)
    {
        this.twoWheeler = twoWheelerSlots;
        this.fourWheeler = fourWheelerSlots;
        this.heavyVehicle = heavyVehicleSlots;
    }

    public int InitialSlotCapacity(string typeOfVehicle)
    {
        int flag = 0, slots = 0;
        while (flag == 0)
        {
            flag = 1;
            Console.WriteLine("Enter Number of " + typeOfVehicle + " Slots : ");
            try
            {
                slots = int.Parse(Console.ReadLine()!);
            }
            catch (FormatException)
            {
                Console.WriteLine("Enter Valid Number");
                flag = 0;
            }
        }
        return slots;
    }

    public int Parking(int typeOfVehicle, int userChoice, string vehicleNumber)
    {
        ParkingLotSystem parkingLotSystem = new ParkingLotSystem();

        int slot;
        TicketsData ticketsData = new TicketsData();
        for (slot = 0; slot < TicketsData.Tickets[typeOfVehicle].Length; slot++)
        {
            if (TicketsData.Tickets[typeOfVehicle][slot] == null)
            {
                break;
            }
        }
        if (slot == TicketsData.Tickets[typeOfVehicle].Length)
        {
            return -1;
        }
        else
        {
            Ticket bookTicket = new Ticket();
            bookTicket.InTime = DateTime.Now;
            bookTicket.SlotNumber = slot;
            bookTicket.VehicleNumber = vehicleNumber;
            bookTicket.TokenNumber = TokenNumber++;
            TicketsData.Tickets[typeOfVehicle][slot] = bookTicket;
            ParkedVehicle.Tokens.Add(bookTicket.TokenNumber, typeOfVehicle);
            return slot;
        }

    }
    public int UnParking(int tokenNumber, int typeOfVehicle)
    {
        int index = -1;
        foreach (var i in TicketsData.Tickets[typeOfVehicle])
        {
            if (i != null && i.TokenNumber == tokenNumber)
            {
                index = i.SlotNumber;
            }
        }
        return index;
    }
}