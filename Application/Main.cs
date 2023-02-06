using System;
namespace ParkingLotManagementSystem
{
    public class ParkingLotSystem
    {

        public static void Main(string[] args)
        {
            int twoWheelerSlots, fourWheelerSlots, heavyVehicleSlots, slotNumber, tokenNumber = 0, slots;
            ActionPerformed userChoice = ActionPerformed.Parking;
            TypeOfVehicle typeOfVehicle = TypeOfVehicle.TwoWheeler;
            ParkingLotSystem parkingLotSystem = new ParkingLotSystem();
            TicketsData ticketsData = new TicketsData();
            ParkingTicket parkingTicket = new ParkingTicket();
            Validation validation = new Validation();
            ParkingLot parkingLot1=new ParkingLot();
            Console.WriteLine("Welcome to Parking Lot Management System");
            Console.WriteLine("-----------------------------------------\n");
            twoWheelerSlots = parkingLot1.InitialSlotCapacity("Two Wheeler");
            fourWheelerSlots = parkingLot1.InitialSlotCapacity("Four Wheeler");
            heavyVehicleSlots = parkingLot1.InitialSlotCapacity("Heavy Vehicle");
            ParkingLot parkingLot = new ParkingLot(twoWheelerSlots, fourWheelerSlots, heavyVehicleSlots);
            ticketsData.slotsInitialisation(twoWheelerSlots, fourWheelerSlots, heavyVehicleSlots);
            while (userChoice != ActionPerformed.Exit)
            {
                string input;
                Console.WriteLine("Enter a choice :\n\n1. Parking\n2. Unparking\n3. Display All Empty Slots\n4. Exit\n");

                input = Console.ReadLine()!;
                if (validation.IsNumeric(input))
                {
                    try
                    {
                        userChoice = (ActionPerformed)int.Parse(input);
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
                    case ActionPerformed.Parking:

                        Console.WriteLine("\nEnter the type of vehicle :\n1. Two Wheeler\n2.Four Wheeler\n3.Heavy Vehicle");
                        input = Console.ReadLine()!;
                        if (validation.IsNumeric(input))
                        {
                            try
                            {
                                typeOfVehicle = (TypeOfVehicle)int.Parse(input);
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Enter valid input\n");
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Enter valid input!\n");
                            break;
                        }
                        if ("TwoWheeler" == typeOfVehicle.ToString())
                        {
                            slots = parkingLot.twoWheeler;
                        }
                        else if ("FourWheeler" == typeOfVehicle.ToString())
                        {
                            slots = parkingLot.fourWheeler;
                        }
                        else
                        {
                            slots = parkingLot.heavyVehicle;
                        }
                        if (slots == 0)
                        {
                            Console.WriteLine("No Empty Slots");
                            break;
                        }
                        string vehicleNumber = "";
                        bool valid = false;
                        if (typeOfVehicle != 0)
                        {

                            Console.WriteLine("Enter Your Vehicle Number : ");
                            vehicleNumber = Console.ReadLine()!;
                            if (validation.IsValidVehicle(vehicleNumber) && !ParkedVehicle.ParkedVehicles.Contains(vehicleNumber))
                            {
                                if (vehicleNumber != "")
                                {
                                    ParkedVehicle.ParkedVehicles.Add(vehicleNumber);

                                }
                                valid = true;
                            }
                        }
                        if (valid)
                        {
                            slotNumber = parkingLot.Parking((int)typeOfVehicle, (int)userChoice, vehicleNumber);
                            if (slotNumber == -1)
                                Console.WriteLine("No slot Available");
                            else
                            {
                                parkingTicket.IssueTicket((int)typeOfVehicle, slotNumber);
                                if ("TwoWheeler" == typeOfVehicle.ToString())
                                {
                                    parkingLot.twoWheeler--;
                                }
                                else if ("FourWheeler" == typeOfVehicle.ToString())
                                {
                                    parkingLot.fourWheeler--;
                                }
                                else
                                {
                                    parkingLot.heavyVehicle--;
                                }
                            }
                        }

                        else
                        {
                            Console.WriteLine("Invalid Vehicle");
                        }

                        break;
                    case ActionPerformed.Unparking:
                        if (ParkedVehicle.Tokens.Count == 0)
                        {
                            Console.WriteLine("No Vehicle to unpark");
                            break;
                        }
                        Console.WriteLine("Enter Token Number");
                        try
                        {
                            tokenNumber = int.Parse(Console.ReadLine()!);
                            if (!ParkedVehicle.Tokens.ContainsKey(tokenNumber))
                            {
                                Console.WriteLine("Token Number is not found");
                                break;
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Invalid Input");
                            break;

                        }
                        typeOfVehicle = (TypeOfVehicle)ParkedVehicle.Tokens[tokenNumber];
                        slotNumber = parkingLot.UnParking(tokenNumber, (int)typeOfVehicle);
                        parkingTicket.IssueTicket((int)typeOfVehicle, slotNumber);
                        if ("TwoWheeler" == typeOfVehicle.ToString())
                        {
                            parkingLot.twoWheeler++;
                        }
                        else if ("FourWheeler" == typeOfVehicle.ToString())
                        {
                            parkingLot.fourWheeler++;
                        }
                        else
                        {
                            parkingLot.heavyVehicle++;
                        }
                        break;
                    case ActionPerformed.DisplayEmptySlots:
                        Console.WriteLine("Empty two wheeler slots are : \n Two wheeler : {0} \n Four Wheeler : {1}\n Heavy Vehicle : {2}\n", parkingLot.twoWheeler, parkingLot.fourWheeler, parkingLot.heavyVehicle); break;
                    default:
                        break;
                }
            }
        }
    }
}