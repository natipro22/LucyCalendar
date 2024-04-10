using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using GeezNet;
using LucyCalendar.Contracts;
using LucyCalendar.Converters;
using LucyCalendar.Format;
using Microsoft.Extensions.DependencyInjection;

namespace LucyCalendar;

public static class Startup
{
    public static IServiceCollection AddLucyCalendar(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();
        services.AddGeezNet();
        services.AddTransient<IFormatProvider, LucyDateFormatProvider>();
        services.AddTransient<ICustomFormatter, LucyDateFormatter>();
        services.AddScoped<IEthiopianToJdn, EthiopianToJdn>();
        services.AddScoped<IJdnToEthiopian, JdnToEthiopian>();
        services.AddScoped<IGregorianToJdn, GregorianToJdn>();
        services.AddScoped<IJdnToGregorian, JdnToGregorian>();
        services.AddScoped<ILucyCalendar, LucyCalendar>();
        return services;
    }
}