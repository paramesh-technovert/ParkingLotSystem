using System.Text.RegularExpressions;
public class Validation
{
    public bool IsNumeric(string input)
    {
        if (Regex.IsMatch(input, @"^[0-9]*$"))
        {
            return true;
        }
        return false;
    }
    public bool IsValidVehicle(string vehicleNumber)
    {
        if ((Regex.IsMatch(vehicleNumber, @"^[a-zA-Z]{2}[0-9]{2}[a-zA-Z]{2}[0-9]{4}") || vehicleNumber == ""))
        {
            return true;
        }
        return false;
    }
}