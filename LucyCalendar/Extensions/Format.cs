using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeezNet;
using GeezNet.Convertor;
using LucyCalendar.Contracts;
using LucyCalendar.Converters;
using LucyCalendar.Format;

namespace LucyCalendar.Extensions;

public static class FormatExtensions
{
    //public static string ToString(this ILucyCalendar datetime, Func<ILucyCalendar,FormattableString>? formattable = null)
    //{
    //    formattable = formattable ?? DateFormat.DEFAULT;
    //    var result = formattable?.Invoke(datetime);
    //    return result!.ToString();
    //}

    public static ILucyCalendar ToEthiopian(this DateTime gregorianDate)
    {
        return new LucyCalendar(
            new EthiopianToJdn(),
                        new JdnToEthiopian(),
                        new GregorianToJdn(),
                        new JdnToGregorian(),
                        new LucyDateFormatProvider(
                            new LucyDateFormatter(
                                new Geez(
                                    new GeezConvertor(), 
                                    new AsciiConvertor())
                                )
                            )
                        ) { DateTime = gregorianDate };
    }
}
