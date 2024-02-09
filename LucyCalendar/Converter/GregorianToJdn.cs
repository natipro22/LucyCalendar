using System.Diagnostics;
using System;
using System.Globalization;
using LucyCalendar.Contracts;

namespace LucyCalendar.Converters
{
    public class GregorianToJdn : Convertor, IGregorianToJdn
    {
        public GregorianToJdn()
        {
            
        }
        public GregorianToJdn(LucyDate date)
        {
            Date = date;
            Convert(date);
        }
        public IToJdnConvertor Convert(LucyDate date)
        {
            // validate date
            Date = date;
            Jdn = Process(date);
            return this;
        }
        public Convertor SetDate(LucyDate date)
        {
            Date = date;
            return this;
        }

        public static int Process(LucyDate date)
        {
            int s = Quotient(date.Year, 4) - Quotient(date.Year - 1, 4) - Quotient(date.Year, 100) + Quotient(date.Year - 1, 100) + Quotient(date.Year, 400) - Quotient(date.Year - 1, 400);

            int t = Quotient(14 - date.Month, 12);

            int n = 31 * t * (date.Month - 1) + (1 - t) * (59 + s + 30 * (date.Month - 3) + Quotient((3 * date.Month - 7), 5)) + date.Day - 1;

            int j = JD_EPOCH_OFFSET_GREGORIAN + 365 * (date.Year - 1) + Quotient(date.Year - 1, 4) - Quotient(date.Year - 1, 100) + Quotient(date.Year - 1, 400) + n;

            return j;
        }
    }
}