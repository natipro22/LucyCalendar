using GeezNet;

namespace LucyCalendar.Format;

public class LucyDateFormatter : ICustomFormatter
{
    private readonly IGeez geez;

    public LucyDateFormatter(IGeez geez)
    {
        this.geez = geez;
    }
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
        if (format is "g" or "G")
            return geez.ToGeez(int.Parse(arg?.ToString()!));
        if (format is "d2g" or "D2G" or "D2g" or "d2G")
            return arg?.ToString()?.Length > 2 ? geez.ToGeez(int.Parse(arg?.ToString()?[2..]!)) : geez.ToGeez(int.Parse(string.Format($"{arg:D2}")));

        return arg?.ToString() ?? string.Empty;
    }
}
