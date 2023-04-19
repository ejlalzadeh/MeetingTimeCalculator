using System.Collections;
using BenchmarkDotNet.Attributes;

namespace MyConsole;

[MemoryDiagnoser]
[RankColumn]
public class Calculator
{
    [Benchmark]
    public List<TimeRange> CalculateTimeRanges()
    {
        var dayOfAli = GetPersonDay(0);

        var dayOfNima = GetPersonDay(1);

        var dayOfYaser = GetPersonDay(2);

        var dayOfAmir = GetPersonDay(3);

        var finalDay = CalculateCommonTime(dayOfAli, dayOfAmir, dayOfYaser, dayOfNima);

        var timeRanges = ConvertBitArrayToTimeRanges(finalDay);

        return timeRanges;
    }

    [Benchmark]
    public BitArray CalculateFinalDay()
    {
        var dayOfAli = GetPersonDay(0);

        var dayOfNima = GetPersonDay(1);

        var dayOfYaser = GetPersonDay(2);

        var dayOfAmir = GetPersonDay(3);

        var finalDay = CalculateCommonTime(dayOfAli, dayOfAmir, dayOfYaser, dayOfNima);

        return finalDay;
    }




    public static BitArray GetPersonDay(int randomSeed)
    {
        var availableTimes = MockProvider.GetMockAvailableTime(randomSeed);
        var events = MockProvider.GetMockEvents(randomSeed);
        var day = MockProvider.GetEmptyDay();

        day = AddAvailableTimesToDay(day, availableTimes);
        day = AddEventsToDay(day, events);

        return day;
    }

    public static BitArray AddEventsToDay(BitArray day, List<Event> events)
    {
        foreach (var @event in events)
        {
            var startTime = @event.StartDateTime.TimeOfDay;

            var endTime = @event.EndDateTime.TimeOfDay;

            day = AddTimeSpanToDay(day, false, startTime, endTime);
        }

        return day;
    }

    public static BitArray AddAvailableTimesToDay(BitArray day, List<AvailableTime> availableTimes)
    {
        foreach (var availableTime in availableTimes)
        {
            day = AddTimeSpanToDay(day, true,
                availableTime.FromTime, availableTime.ToTime);
        }

        return day;
    }

    public static List<TimeRange> ConvertBitArrayToTimeRanges(BitArray day)
    {
        var result = new List<TimeRange>();

        var counter = 0;
        int startElement = 0;

        for (int i = 0; i < day.Length; i++)
        {
            if (day[i])
            {
                if (startElement == 0)
                    startElement = i;

                counter++;
            }
            else
            {
                if (startElement != 0)
                {
                    TimeSpan start = TimeSpan.FromHours(startElement / 4D).Subtract(TimeSpan.FromMinutes(15));

                    TimeSpan end = TimeSpan.FromHours((startElement + counter - 1) / 4D);

                    var timeRange = new TimeRange(start, end);

                    result.Add(timeRange);

                    startElement = 0;
                    counter = 0;
                }
            }
        }

        return result;
    }

    public static BitArray AddTimeSpanToDay(BitArray day, bool changeTo, TimeSpan start, TimeSpan end)
    {
        var subtract = end.Subtract(start);

        var elementCount = subtract.Divide(new TimeSpan(0, 15, 0));

        var startElement = (start.Hours * 4) + (start.Minutes / 15) + 1;

        for (int i = startElement; i < (elementCount + startElement); i++)
        {
            day[i] = changeTo;
        }

        return day;
    }

    public static BitArray CalculateCommonTime(params BitArray[] days)
    {
        var result = days.Aggregate((a, b) => a.And(b));

        return result;
    }
}