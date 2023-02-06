public class Ticket
{
    public int Status
    {
        get; set;
    }
    public int TokenNumber
    {
        get; set;
    }
    public int SlotNumber
    {
        get; set;
    }
    public int Amout
    {
        get; set;
    }
    public DateTime InTime
    {
        get; set;
    }
    public DateTime OutTime
    {
        get; set;
    }
    public string? VehicleNumber
    {
        get; set;
    }

    public TimeSpan Duration
    {
        get; set;
    }
}