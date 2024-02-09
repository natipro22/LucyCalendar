using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LucyCalendar.Contracts;

namespace LucyCalendar.Converters;

public class JdnToGregorian : Convertor, IJdnToGregorian
{
    private static readonly int[] _monthDays = { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

    public IFromJdnConvertor Convert(int jdn)
    {
        // validate djn
        Jdn = jdn;
        var date = Process(jdn);
        return SetDate(date);
    }

    public IFromJdnConvertor SetDate(LucyDate date)
    {
        Date = date;
        return this;
    }
    public static LucyDate Process(int jdn)
    {
        int r2000 = Mod((jdn - JD_EPOCH_OFFSET_GREGORIAN), 730485);
        int r400 = Mod((jdn - JD_EPOCH_OFFSET_GREGORIAN), 146097);
        int r100 = Mod(r400, 36524);
        int r4 = Mod(r100, 1461);

        int n = Mod(r4, 365) + 365 * Quotient(r4, 1460);
        int s = Quotient(r4, 1095);

        int aprime = 400 * Quotient((jdn - JD_EPOCH_OFFSET_GREGORIAN), 146097) + 
                    100 * Quotient(r400, 36524) + 
                    4 * Quotient(r100, 1461) + Quotient(r4, 365) - 
                    Quotient(r4, 1460) - Quotient(r2000, 730484);
        int year = aprime + 1;
        int t = Quotient((364 + s - n), 306);
        int month = t * (Quotient(n, 31) + 1) + (1 - t) * (Quotient((5 * (n - s) + 13), 153) + 1);
        //        
        //		int day    = t * ( n - s - 31*month + 32 )
        //		           + ( 1 - t ) * ( n - s - 30*month - quotient((3*month - 2), 5) + 33 )
        //		;
        //		

        // int n2000 = quotient( r2000, 730484 );
        n += 1 - Quotient(r2000, 730484);
        int day = n;

        if ((r100 == 0) && (n == 0) && (r400 != 0))
        {
            month = 12;
            day = 31;
        }
        else
        {
            _monthDays[2] = (IsGregorianLeap(year)) ? 29 : 28;
            for (int i = 1; i <= _monthDays.Count() - 1; ++i)
            {
                if (n <= _monthDays[i])
                {
                    day = n;
                    break;
                }
                n -= _monthDays[i];
            }
        }
        return new LucyDate { Year = year, Month = month, Day = day };
    }

    private static bool IsGregorianLeap(int year)
    {
        return (year % 4 == 0) && ((year % 100 != 0) || (year % 400 == 0));
    }
}
