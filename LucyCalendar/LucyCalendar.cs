using System;
using LucyCalendar.Contracts;
using LucyCalendar.Converters;
using LucyCalendar.Format;
using LucyCalendar.Validator;

namespace LucyCalendar;
public class LucyCalendar : ILucyCalendar
{
    public DateTime DateTime { get; set; }
    public int Day { get; set; }
    public int Month { get; set; }
    public int Year { get; set; }
    public bool LeapYear { get; set; }
    public int DayOfYear { get; set; }
    public int DaysInMonth { get; set; }
    public int DayOfWeek { get; set; }
    public string Era { get => Year > 0 ? "ዓ/ም" : "ዓ/ዓ"; }

    private readonly IToJdnConvertor _toJdnConverter;
    private readonly IFromJdnConvertor _fromJdnConverter;
    private readonly IToJdnConvertor _ethiopianToJdn;
    private readonly IFromJdnConvertor _jdnToGregorian;
    private readonly IFormatProvider _formatProvider;

    public LucyCalendar()
    {
        
    }

    public LucyCalendar(IEthiopianToJdn ethiopianToJdn,
                        IJdnToEthiopian jdnToEthiopian,
                        IGregorianToJdn gregorianToJdn,
                        IJdnToGregorian jdnToGregorian,
                        IFormatProvider formatProvider)
    {
        DateTime = DateTime.Now;
        _toJdnConverter = gregorianToJdn;
        _fromJdnConverter = jdnToEthiopian;
        _ethiopianToJdn = ethiopianToJdn;
        _jdnToGregorian = jdnToGregorian;
        this._formatProvider = formatProvider;
        this.Initialize();
    }
    public void Initialize()
    {
        this.UpdateComputedFields();
        this.ComputeFields();
    }

    // public LucyCaledar(int day,
    //                     int month,
    //                     int year,
    //                     IEthiopianToJdn ethiopianToJdn,
    //                     IJdnToEthiopian jdnToEthiopian,
    //                     IGregorianToJdn gregorianToJdn,
    //                     IJdnToGregorian jdnToGregorian) 
    //                     : 
    //                     this(ethiopianToJdn,
    //                         jdnToEthiopian,
    //                         gregorianToJdn,
    //                         jdnToGregorian)
    // {
    //     var jdn = _ethiopianToJdn.Convert(new Converters.LucyDate { Day = day, Month = month, Year = year }).Jdn;
    //     Console.WriteLine(jdn);
    //     var date = _jdnToGregorian.Convert(jdn);
    //     DateTime = new DateTime(date.Date.Year, date.Date.Month, date.Date.Day);
    //     this.UpdateComputedFields();
    //     this.ComputeFields();
    // }
    public ILucyCalendar FromDateTime(DateTime dateTime)
    {
        DateTime = dateTime;
        Initialize();
        return this;
    }

    public ILucyCalendar From(int day, int month, int year)
    {
        (Day, Month, Year) = (day, month, year);
        int jdn = _ethiopianToJdn.Convert(new LucyDate(day, month, year)).Jdn;
        var date = _jdnToGregorian.Convert(jdn).Date;
        DateTime = new DateTime(date.Day, date.Month, date.Year);
        return this;
    }
    public DateTime ToGregorian()
    {
        return DateTime;
    }
    public override string ToString()
    {
        return this.ToString(DateFormat.DEFAULT);
    }
    public string ToString(Func<ILucyCalendar, FormattableString> dateFormat)
    {
        var result = dateFormat?.Invoke(this);
        return result!.ToString(_formatProvider);
    }

    public string MonthName()
        => Constants.MONTHS_NAME[Month - 1];
    public string WeekName()
        => Constants.WEEK_NAME[DayOfWeek - 2];

    public void UpdateComputedFields()
    {
        var jdn = JdnFromDateTime(DateTime);
        var converter = _fromJdnConverter.Convert(jdn);
        SetDateFromConverter(converter);
        ComputeFields();
    }

    private int JdnFromDateTime(DateTime dateTime)
    {
        var date = new Converters.LucyDate 
        {
            Day = dateTime.Day,
            Month = dateTime.Month,
            Year = dateTime.Year
        };
        return _toJdnConverter.Convert(date).Jdn;
    }

    private void SetDateFromConverter(IFromJdnConvertor converter)
    {
        Day = converter.Date.Day;
        Month = converter.Date.Month;
        Year = converter.Date.Year;
    }

    /**
     * Computer the available properties.
     *
     * @return void
     */
    protected void ComputeFields()
    {
        ComputeLeapYear();
        ComputeDayOfYear();
        ComputeDaysInMonth();
        CacheDayOfWeek();
    }

    /**
     * Compute the leapYear property.
     *
     * @return void
     */
    protected void ComputeLeapYear()
    {
        var leapYear = new LeapYearValidator(Year);
        LeapYear = leapYear.IsValid();
    }

    /**
     * Compute the dayOfYear property.
     *
     * @return void
     */
    protected void ComputeDayOfYear()
    {
        DayOfYear = (Month - 1) * 30 + Day;
    }

    /**
     * Compute the daysInMonth property.
     *
     * @return void
     */
    protected void ComputeDaysInMonth()
    {
        DaysInMonth = Month == 13 ? (LeapYear ? 6 : 5) : 30;
    }

    /**
     * Cache the dayOfWeek property.
     *
     * @return void
     */
    protected void CacheDayOfWeek()
    {
        DayOfWeek = (int)DateTime.DayOfWeek + 1;
    }
}