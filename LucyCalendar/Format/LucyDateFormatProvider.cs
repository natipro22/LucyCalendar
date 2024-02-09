using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LucyCalendar.Format;

public class LucyDateFormatProvider : IFormatProvider
{
    private LucyDateFormatter _formatter = new();
    public object? GetFormat(Type? formatType)
    {
        if (formatType == typeof(ICustomFormatter))
            return _formatter;
        return new();
    }

    class LucyDateFormatter : ICustomFormatter
    {
        public string Format(string? format, object? arg, IFormatProvider? formatProvider)
        {
            if (arg == null)
                return string.Empty;
            if (format is "mn" or "MN")
                return Constants.MONTHS_NAME[int.Parse(arg?.ToString()!) - 1];
            if (format is "wn" or "WN")
                return Constants.WEEK_NAME[int.Parse(arg?.ToString()!) - 1];
            if (format == "D2")
                return arg?.ToString()?.Length > 2 ? arg?.ToString()?[2..]! : string.Format($"{arg:D2}");

            return arg?.ToString() ?? string.Empty;
        }
    }
}
