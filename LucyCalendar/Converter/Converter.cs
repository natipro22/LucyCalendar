using System;
using LucyCalendar.Contracts;

namespace LucyCalendar.Converters;
public abstract class Convertor : IConvertor
{
    public LucyDate Date { get; set; }
    public int Jdn { get; set; }

    public const int JD_EPOCH_OFFSET_GREGORIAN = 1721426;
    public const int JD_EPOCH_OFFSET_AMETE_MIHRET = 1723856; // ዓ/ም

    protected static int Quotient(long i, long j)
    {
        return (int)Math.Floor((decimal)i / j);
    }
    protected static int Mod(long i, long j)
    {
        return (int)(i - (j * Quotient(i, j)));
    }

}