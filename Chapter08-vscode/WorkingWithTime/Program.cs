using static System.Console;
using System.Globalization;

WriteLine("Earliest date/time value is: {0}",
    arg0: DateTime.MinValue);

WriteLine("UNIX epoch date/time value is: {0}",
    arg0: DateTime.UnixEpoch);

WriteLine("Date/Time value Today is: {0}",
    arg0: DateTime.Today);

DateTime christmas = new(year: 2023, month: 12, day: 25);

WriteLine("Christmas: {0}",
    arg0: christmas); //default format

WriteLine("Christmas: {0:dddd, dd MMMM yyyy}",
    arg0: christmas); //custom format

WriteLine("Christmas is in month {0} of the year.",
    arg0: christmas.Month);

WriteLine("Christmas is day {0} of the year.",
    arg0: christmas.DayOfYear);

WriteLine("Christmas {0} is on a {1}",
    arg0: christmas.Year,
    arg1: christmas.DayOfWeek);

DateTime beforeXmas = christmas.Subtract(TimeSpan.FromDays(12));
DateTime afterXmas = christmas.AddDays(12);

WriteLine("12 days before Christmas is: {0}",
    arg0: beforeXmas);

WriteLine("12 days after Christmas is: {0}",
    arg0: beforeXmas);

//Oduzimanje datuma i vremena
TimeSpan untilChristmas = christmas - DateTime.Now;

WriteLine("There are {0} days and {1} hours until Christmas",
    arg0: untilChristmas.Days,
    arg1: untilChristmas.Hours);

WriteLine("There are {0:N0} hours until Christmas",
    arg0: untilChristmas.TotalHours);

DateTime kidsWakeUp = new(
    year: 2023, month: 12, day: 25,
    hour: 6, minute: 30, second: 0);

WriteLine("Kids wake up on Christmas: {0}",
    arg0: kidsWakeUp);

WriteLine("The kids woke me up at {0}",
  arg0: kidsWakeUp.ToShortTimeString());

//Globalizacija pomocu datuma i vremena
WriteLine("Current culture is: {0}",
    arg0: CultureInfo.CurrentCulture.Name);

string textDate = "4 July 2023";
DateTime independenceDay = DateTime.Parse(textDate);
WriteLine("Text: {0}, DateTime: {1:d MMMM}",
    arg0: textDate,
    arg1: independenceDay);

textDate = "7/4/2023";
independenceDay = DateTime.Parse(textDate);
WriteLine("Text: {0}, DateTime: {1:d MMMM}",
    arg0: textDate,
    arg1: independenceDay);

independenceDay = DateTime.Parse(textDate,
    provider: CultureInfo.GetCultureInfo("en-US"));
WriteLine("Text: {0}, DateTime: {1:d MMMM}",
    arg0: textDate,
    arg1: independenceDay);

for (int year = 2020; year < 2030; year++)
{
    WriteLine($"{year} is a leap year: {DateTime.IsLeapYear(year)}.");
    WriteLine("There are {0} days in February {1}.",
        arg0: DateTime.DaysInMonth(year: year, month: 2),
        arg1: year);
}

WriteLine("Is Christmas daylight saving time? {0}",
    arg0: christmas.IsDaylightSavingTime());

WriteLine("Is July 4th daylight saving time? {0}",
    arg0: independenceDay.IsDaylightSavingTime());

//Upotreba samo datuma ili samo vremena
DateOnly myBirthday = new(year: 2023, month: 8, day: 22);
WriteLine($"My next birthday is on {myBirthday}");

TimeOnly partyStarts = new(hour: 20, minute: 30);
WriteLine($"Mine birthday party starts at: {partyStarts}");

DateTime calendarEntry = myBirthday.ToDateTime(partyStarts);
WriteLine($"Add to your calendar: {calendarEntry}");