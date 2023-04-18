namespace MyConsole;

public class AvailableTime
{
    public AvailableTime(TimeSpan fromTime, TimeSpan toTime)
    {
        FromTime = fromTime;

        ToTime = toTime;
    }

    public TimeSpan FromTime { get; set; }

    public TimeSpan ToTime { get; set; }
}