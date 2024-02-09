using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LucyCalendar.Converters;

namespace LucyCalendar.Contracts;

public interface IToJdnConvertor
{
    public int Jdn { get; protected set; }
    IToJdnConvertor Convert(Converters.LucyDate date);
    // static abstract int Process(LucyDate date);
}
