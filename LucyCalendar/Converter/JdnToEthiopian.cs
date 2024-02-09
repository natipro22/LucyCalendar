using System.Diagnostics;
using System;
using LucyCalendar.Contracts;

namespace LucyCalendar.Converters
{
    public class JdnToEthiopian : Convertor, IJdnToEthiopian
    {

        public JdnToEthiopian()
        {
            
        }
        public JdnToEthiopian(int jdn)
        {
            Jdn = jdn;
            Convert(jdn);
        }
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
            var r = (jdn - JD_EPOCH_OFFSET_AMETE_MIHRET) % 1461;
            var n = (r % 365) + 365 * (int) (r / 1460);

            var year = 4 * (int) ((jdn - JD_EPOCH_OFFSET_AMETE_MIHRET) / 1461) +
                (int) (r / 365) - (int) (r / 1460);
            var month = (int) (n / 30) + 1;
            var day = (n % 30) + 1;

            return new LucyDate { Day = day, Month = month, Year = year };
        }
    }
}