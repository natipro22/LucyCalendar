using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LucyCalendar.Contracts;
using LucyCalendar.Format;

namespace LucyCalendar.Extensions;

public static class FormatExtensions
{
    public static string ToString(this ILucyCalendar datetime, Func<ILucyCalendar,FormattableString>? formattable = null)
    {
        formattable = formattable ?? DateFormat.DEFAULT;
        var result = formattable?.Invoke(datetime);
        return result!.ToString(new LucyDateFormatProvider());
    }

    public static LucyCaledar ToEthiopian(this DateTime gregorianDate)
    {
        return new LucyCaledar { DateTime = gregorianDate };
    }
}
