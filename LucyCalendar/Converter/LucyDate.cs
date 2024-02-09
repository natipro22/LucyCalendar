using System.IO;
using System;

namespace LucyCalendar.Converters;
public class LucyDate
{
    private int _day;
    private int _month;
    private int _year;

    public LucyDate()
    {
        
    }
    public LucyDate(int day, int month, int year)
    {
        (Day, Month, Year) = (day, month, year);
    }
    public int Day 
    {
        get
        {
            return _day;
        }
        set 
        {
            if (value is < 1 or > 30)
               throw new InvalidDataException("Invalid day value.");
            _day = value;
        } 
    }
    public int Month 
    { 
        get
        {
            return _month;
        }
        set
        {
            if (value is < 1 or > 13)
                throw new InvalidDataException("Invalid month value.");
            _month = value;
        }
    }
    public int Year 
    { 
        get
        {
            return _year;
        }
        set
        {
            if (value is < 1)
                throw new InvalidDataException("Invalid year value.");
            _year = value;
        } 
    }
}