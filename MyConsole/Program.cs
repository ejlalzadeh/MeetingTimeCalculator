using System.Collections;
using MyConsole;

var dayOfAli = GetPersonDay(0);
PrintDayTimeRanges(dayOfAli, "Ali");

var dayOfNima = GetPersonDay(1);
PrintDayTimeRanges(dayOfNima, "Nima");

var dayOfYaser = GetPersonDay(2);
PrintDayTimeRanges(dayOfYaser, "Yaser");

var dayOfAmir = GetPersonDay(3);
PrintDayTimeRanges(dayOfAmir, "Amir");

var finalDay = CalculateCommonTime(dayOfAli, dayOfAmir, dayOfYaser, dayOfNima);
PrintDayTimeRanges(finalDay, "Final");


static BitArray GetPersonDay(int randomSeed)
{
    var availableTimes = MockProvider.GetMockAvailableTime(randomSeed);
    var events = MockProvider.GetMockEvents(randomSeed);
    var day = MockProvider.GetEmptyDay();

    day = AddAvailableTimesToDay(day, availableTimes);
    day = AddEventsToDay(day, events);

    return day;
}

static void PrintDayTimeRanges(BitArray day, string title)
{
    Console.WriteLine(title);

    var timeRanges = ConvertBitArrayToTimeRanges(day);

    foreach (var item in timeRanges)
    {
        Console.WriteLine(item.ToString());
    }

    Console.WriteLine("--------------------------------------------");
}

static void PrintDayElements(BitArray day, string title)
{
    Console.WriteLine(title);

    for (int i = 0; i < day.Length; i++)
        Console.WriteLine($"{i} - {day[i]}");

    Console.WriteLine("--------------------------------------------");
}

#region MainAlgorithmFunctions

static BitArray AddEventsToDay(BitArray day, List<Event> events)
{
    foreach (var @event in events)
    {
        var startTime = @event.StartDateTime.TimeOfDay;

        var endTime = @event.EndDateTime.TimeOfDay;

        day = AddTimeSpanToDay(day, false, startTime, endTime);
    }

    return day;
}

static BitArray AddAvailableTimesToDay(BitArray day, List<AvailableTime> availableTimes)
{
    foreach (var availableTime in availableTimes)
    {
        day = AddTimeSpanToDay(day, true,
            availableTime.FromTime, availableTime.ToTime);
    }

    return day;
}

static List<TimeRange> ConvertBitArrayToTimeRanges(BitArray day)
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

static BitArray AddTimeSpanToDay(BitArray day, bool changeTo, TimeSpan start, TimeSpan end)
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

static BitArray CalculateCommonTime(params BitArray[] days)
{
    var result = days.First();

    foreach (var day in days)
    {
        result.And(day);
    }

    return result;
}

#endregion

