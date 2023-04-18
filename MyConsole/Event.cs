namespace MyConsole;

public class Event
{
    public Event(DateTime startDateTime, DateTime endDateTime)
    {
        StartDateTime = startDateTime;

        EndDateTime = endDateTime;
    }

    public DateTime StartDateTime { get; set; }

    public DateTime EndDateTime { get; set; }
}