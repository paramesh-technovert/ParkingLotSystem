using System;
namespace ParkingLotManagementSystem
{
    public class ParkingLotSystem
    {

        public static void Main(string[] args)
        {
            int twoWheelerSlots, fourWheelerSlots, heavyVehicleSlots, typeOfVehicle = 0, userChoice = 0, slotNumber, tokenNumber = 0;
            ParkingLotSystem parkingLotSystem = new ParkingLotSystem();
            Data data = new Data();
            SlotBooking slotBooking = new SlotBooking();
            ParkingTicket parkingTicket = new ParkingTicket();
            Validation validation = new Validation();
            Console.WriteLine("Welcome to Parking Lot Management System");
            Console.WriteLine("-----------------------------------------\n");
            twoWheelerSlots = slotBooking.InitialSlotCapacity("Two Wheeler");
            fourWheelerSlots = slotBooking.InitialSlotCapacity("Four Wheeler");
            heavyVehicleSlots = slotBooking.InitialSlotCapacity("Heavy Vehicle");
            data.slotsInitialisation(twoWheelerSlots, fourWheelerSlots, heavyVehicleSlots);
            while (userChoice != 4)
            {
                string input;
                Console.WriteLine("Enter a choice :\n\n1. Parking\n2. Unparking\n3. Display All Empty Slots\n4. Exit\n");

                input = Console.ReadLine()!;
                if (validation.IsNumeric(input))
                {
                    try
                    {
                        userChoice = int.Parse(input);
                    }
                    catch (FormatException)
                    {
                        userChoice = 0;
                    }
                }
                else
                {
                    Console.WriteLine("Enter valid input!\n");
                    userChoice = 0;
                }

                switch (userChoice)
                {
                    case 1:

                        Console.WriteLine("\nEnter the type of vehicle :\n1. Two Wheeler\n2.Four Wheeler\n3.Heavy Vehicle");
                        input = Console.ReadLine()!;
                        if (validation.IsNumeric(input))
                        {
                            try
                            {
                                typeOfVehicle = int.Parse(input);
                            }
                            catch (FormatException)
                            {
                                typeOfVehicle = 0;
                                Console.WriteLine("Enter valid input\n");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Enter valid input!\n");
                            typeOfVehicle = 0;
                        }
                        string vehicleNumber = "";
                        bool valid = false;
                        if (typeOfVehicle != 0 && (typeOfVehicle > 0 && typeOfVehicle < 4))
                        {

                            Console.WriteLine("Enter Your Vehicle Number : ");
                            vehicleNumber = Console.ReadLine()!;
                            if (validation.IsValidVehicle(vehicleNumber) && !Data.ParkedVehicles.Contains(vehicleNumber))
                            {
                                if (vehicleNumber != "")
                                {
                                    Data.ParkedVehicles.Add(vehicleNumber);

                                }
                                valid = true;
                            }
                        }
                        if (valid)
                        {
                            slotNumber = slotBooking.Parking(typeOfVehicle, userChoice, vehicleNumber);
                            if (slotNumber == -1)
                                Console.WriteLine("No slot Available");
                            else
                            {
                                parkingTicket.IssueTicket(typeOfVehicle, slotNumber);
                            }
                        }

                        else
                        {
                            Console.WriteLine("Invalid Vehicle");
                        }

                        break;
                    case 2:
                        int flag = 0;
                        if (Data.Tokens.Count == 0)
                        {
                            tokenNumber = -1;
                        }
                        Console.WriteLine("Enter Token Number");
                        try
                        {
                            tokenNumber = int.Parse(Console.ReadLine()!);
                            if (Data.Tokens.ContainsKey(tokenNumber))
                            {
                                flag = 1;
                            }
                            else
                            {
                                Console.WriteLine("Token Number is not found");
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Invalid Input");
                        }

                        if (tokenNumber == -1)
                        {
                            Console.WriteLine("No Vehicle to Unpark");
                        }
                        else if (flag == 0 && tokenNumber != -1)
                        {
                            Console.WriteLine("Enter Valid Input");
                        }
                        else
                        {
                            typeOfVehicle = Data.Tokens[tokenNumber];
                            slotNumber = slotBooking.UnParking(tokenNumber, typeOfVehicle);
                            parkingTicket.IssueTicket(typeOfVehicle, slotNumber);
                        }
                        break;
                    case 3:
                        slotBooking.DisplayEmptySlots(); break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            }
        }
    }
}