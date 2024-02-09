using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LucyCalendar.Converters;

namespace LucyCalendar.Contracts;

public interface IFromJdnConvertor
{
    public Converters.LucyDate Date { get; set; }
    IFromJdnConvertor Convert(int jdn);
    // static abstract LucyDate Process(int jdn);
}
