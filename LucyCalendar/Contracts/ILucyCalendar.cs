using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LucyCalendar.Contracts;

public interface ILucyCalendar
{
    public DateTime DateTime { get; set; }
    public int Day { get; set; }
    public int Month { get; set; }
    public int Year { get; set; }
    public bool LeapYear { get; set; }
    public int DayOfYear { get; set; }
    public int DaysInMonth { get; set; }
    public int DayOfWeek { get; set; }
    DateTime ToGregorian();
    ILucyCalendar FromDateTime(DateTime dateTime);
    ILucyCalendar From(int day, int month, int year);
    string ToString();
    string MonthName();
    string WeekName();
}
