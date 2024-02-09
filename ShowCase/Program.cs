// See https://aka.ms/new-console-template for more information
using System.Text;
using LucyCalendar;
using LucyCalendar.Contracts;
using LucyCalendar.Extensions;
using LucyCalendar.Format;
using Microsoft.Extensions.DependencyInjection;
Console.OutputEncoding = Encoding.UTF8;
var service = new ServiceCollection();
service.AddLucyCalendar();
var serviceProvider = service.BuildServiceProvider();
Console.WriteLine("Hello, World!");
var lucy = serviceProvider.GetService<ILucyCalendar>();
Console.WriteLine(lucy);
// Console.WriteLine(lucy?.FromDateTime(DateTime.Today));