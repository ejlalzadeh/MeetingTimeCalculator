using System.Collections;

namespace MyConsole;

public class MockProvider
{
    public static List<AvailableTime> GetMockAvailableTime(int randomSeed)
    {
        if (randomSeed == 0)
        {
            return new List<AvailableTime>
            {
                new AvailableTime(new TimeSpan(08, 0, 0),
                    new TimeSpan(08, 45, 0)),

                new AvailableTime(new TimeSpan(10, 0, 0),
                    new TimeSpan(11, 00, 0)),

                new AvailableTime(new TimeSpan(12, 0, 0),
                    new TimeSpan(13, 0, 0)),

                new AvailableTime(new TimeSpan(15, 45, 0),
                    new TimeSpan(16, 30, 0)),
            };
        }

        if (randomSeed == 1)
        {
            return new List<AvailableTime>
            {
                new AvailableTime(new TimeSpan(10, 0, 0),
                    new TimeSpan(11, 30, 0)),

                new AvailableTime(new TimeSpan(13, 0, 0),
                    new TimeSpan(14, 0, 0)),

                new AvailableTime(new TimeSpan(16, 15, 0),
                    new TimeSpan(17, 30, 0)),
            };
        }

        if (randomSeed == 2)
        {
            return new List<AvailableTime>
            {
                new AvailableTime(new TimeSpan(09, 0, 0),
                    new TimeSpan(10, 15, 0)),

                new AvailableTime(new TimeSpan(13, 00, 0),
                    new TimeSpan(18, 30, 0)),
            };
        }

        if (randomSeed == 3)
        {
            return new List<AvailableTime>
            {
                new AvailableTime(new TimeSpan(11, 0, 0),
                    new TimeSpan(12, 45, 0)),

                new AvailableTime(new TimeSpan(13, 15, 0),
                    new TimeSpan(16, 0, 0)),

                new AvailableTime(new TimeSpan(17, 00, 0),
                    new TimeSpan(18, 30, 0)),
            };
        }

        throw new ArgumentOutOfRangeException("randomSeed is not valid");

    }

    public static List<Event> GetMockEvents(int randomSeed)
    {
        if (randomSeed == 0)
        {
            return new List<Event>
            {
                new Event(new DateTime(2023, 04, 18, 10, 15, 00),
                    new DateTime(2023, 04, 18, 11, 00, 00)),

                new Event(new DateTime(2023, 04, 18, 12, 00, 00),
                    new DateTime(2023, 04, 18, 12, 30, 00)),

                new Event(new DateTime(2023, 04, 18, 15, 30, 00),
                    new DateTime(2023, 04, 18, 17, 00, 00)),
            };
        }

        if (randomSeed == 1)
        {
            return new List<Event>
            {
                new Event(new DateTime(2023, 04, 18, 07, 00, 00),
                    new DateTime(2023, 04, 18, 08, 30, 00)),

                new Event(new DateTime(2023, 04, 18, 10, 00, 00),
                    new DateTime(2023, 04, 18, 12, 30, 00)),

                new Event(new DateTime(2023, 04, 18, 15, 30, 00),
                    new DateTime(2023, 04, 18, 17, 00, 00)),

                new Event(new DateTime(2023, 04, 18, 17, 30, 00),
                    new DateTime(2023, 04, 18, 19, 00, 00)),
            };
        }

        if (randomSeed == 2)
        {
            return new List<Event>
            {
                new Event(new DateTime(2023, 04, 18, 09, 00, 00),
                    new DateTime(2023, 04, 18, 11, 00, 00)),

                new Event(new DateTime(2023, 04, 18, 12, 00, 00),
                    new DateTime(2023, 04, 18, 12, 30, 00)),

                new Event(new DateTime(2023, 04, 18, 15, 30, 00),
                    new DateTime(2023, 04, 18, 17, 30, 00)),
            };
        }

        if (randomSeed == 3)
        {
            return new List<Event>
            {
                new Event(new DateTime(2023, 04, 18, 10, 00, 00),
                    new DateTime(2023, 04, 18, 17, 00, 00)),

                new Event(new DateTime(2023, 04, 18, 19, 00, 00),
                    new DateTime(2023, 04, 18, 20, 0, 00)),
            };
        }

        throw new ArgumentOutOfRangeException("randomSeed is not valid");
    }

    public static BitArray GetEmptyDay()
    {
        return new BitArray(96, false);
    }
}