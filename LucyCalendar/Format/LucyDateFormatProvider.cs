using GeezNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LucyCalendar.Format;

public class LucyDateFormatProvider : IFormatProvider
{
    public LucyDateFormatProvider(ICustomFormatter formatter)
    {
        this._formatter = formatter;
    }
    private readonly ICustomFormatter _formatter;

    public object? GetFormat(Type? formatType)
    {
        if (formatType == typeof(ICustomFormatter))
            return _formatter;
        return new();
    }
}
