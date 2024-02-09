using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LucyCalendar.Contracts;

namespace LucyCalendar.Converters;

public class EthiopianToJdn : Convertor, IEthiopianToJdn
{
    public IToJdnConvertor Convert(LucyDate date)
    {
        Date = date;
        Jdn = Process(date);
        return this;
    }
    public static int Process(LucyDate date)
    {
        return
        (JD_EPOCH_OFFSET_AMETE_MIHRET + 365) + 
        365 * (date.Year - 1) + Quotient(date.Year, 4) + 
        30 * date.Month + date.Day - 31;
    }
}
