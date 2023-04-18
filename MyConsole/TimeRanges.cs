namespace MyConsole;

public class TimeRange
{
    public TimeRange(TimeSpan fromTime, TimeSpan toTime)
    {
        FromTime = fromTime;

        ToTime = toTime;
    }

    public TimeSpan FromTime { get; set; }

    public TimeSpan ToTime { get; set; }

    public override string ToString()
    {
        return $"{this.FromTime} - {this.ToTime}";
    }
}