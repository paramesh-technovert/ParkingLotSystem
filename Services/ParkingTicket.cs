public class ParkingTicket{
    public void IssueTicket(int typeOfVehicle,int SlotNumber){
        Ticket ticket=Data.Tickets[typeOfVehicle][SlotNumber];
        Console.WriteLine("Welcome to Parking Lot Management System ");
        Console.WriteLine("-----------------------------------------");
        Console.WriteLine("Your Ticket ");
        Console.WriteLine("Token Number : "+ticket.TokenNumber);
        Console.WriteLine("Slot Number : "+ticket.SlotNumber+1);
        Console.WriteLine("Vehicle Number : "+ticket.VehicleNumber);
        Console.WriteLine("In Time : "+ticket.InTime);
        if(ticket.Status==0){
            Console.WriteLine("-----------------------------------------");
            ticket.Status=1;
            Data.Tickets[typeOfVehicle][SlotNumber]=ticket;
        }
        else{
            ticket.OutTime=DateTime.Now;
            ticket.Duration=ticket.OutTime.Subtract(ticket.InTime);
            int time=((int)(ticket.Duration.TotalSeconds-3));
            ticket.Amout=time*3;
            Console.WriteLine("Out Time : "+ticket.OutTime);
            Console.WriteLine("Duration : "+ticket.Duration);
            Console.WriteLine("Total Amount to be Paid : "+ticket.Amout);
            Console.WriteLine("---------Thank YoU Visit Again---------");
            if(ticket.VehicleNumber!="")
            Data.ParkedVehicles.Remove(ticket.VehicleNumber!);
            Data.Tokens.Remove(ticket.TokenNumber);
            Data.Tickets[typeOfVehicle][SlotNumber]=null!;
            
        }
    }
}