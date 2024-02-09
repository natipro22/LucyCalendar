using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LucyCalendar.Contracts;

namespace LucyCalendar.Format;

public class DateFormat
{
    public static Func<ILucyCalendar, FormattableString> DEFAULT = (d) => $"{d.Day:D2}/{d.Month:D2}/{d.Year}";
    public static Func<ILucyCalendar, FormattableString> DATE_ETHIOPIAN = (d) => $"{d.DayOfWeek:wn} ፣ {d.Month:mn} {d.Day:D2} {d.Year} ዓ/ም";

    // public static Func<LucyDateTime, FormattableString> DATE_GEEZ = (d) => $"{d.DayOfWeek:wn} ፣ {d.Month:mn} {d.Day:g} {d.Year:g} ዓ/ም";
}
