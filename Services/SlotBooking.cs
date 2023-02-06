using ParkingLotManagementSystem;
public class SlotBooking{
    public static int TokenNumber=1;
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

    public int Parking(int typeOfVehicle,int userChoice,string vehicleNumber){
        ParkingLotSystem parkingLotSystem=new ParkingLotSystem();

        int slot;
        Data data=new Data();
        for(slot=0;slot< Data.Tickets[typeOfVehicle].Length;slot++){
            if(Data.Tickets[typeOfVehicle][slot]==null){
                break;
            }
        }
            if(slot==Data.Tickets[typeOfVehicle].Length){
                return -1;
            }
            else{
                Ticket bookTicket=new Ticket();
                bookTicket.InTime=DateTime.Now;
                bookTicket.SlotNumber=slot;
                bookTicket.VehicleNumber = vehicleNumber;
                bookTicket.TokenNumber=TokenNumber++;
                Data.Tickets[typeOfVehicle][slot]=bookTicket;
                Data.Tokens.Add(bookTicket.TokenNumber,typeOfVehicle);
                return slot;
            }
        
    }
    public int UnParking(int tokenNumber,int typeOfVehicle){
        int index=-1;
        foreach(var i in Data.Tickets[typeOfVehicle]){
            if(i!=null && i.TokenNumber==tokenNumber){
                index=i.SlotNumber;
            }
        }
        return index;
    }
    public void DisplayEmptySlots(){
        int twoWheelerSlots=Data.Tickets[1].Count(x=>x==null);
        int fourWheelerSlots=Data.Tickets[2].Count(x=>x==null);
        int heavyVehicleSlots=Data.Tickets[3].Count(x=>x==null);
        Console.WriteLine("Empty two wheeler slots are : \n Two wheeler : {0} \n Four Wheeler : {1}\n Heavy Vehicle : {2}\n",twoWheelerSlots,fourWheelerSlots,heavyVehicleSlots);
    }
}