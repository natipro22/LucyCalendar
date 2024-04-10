# Lucy Calendar ![From Ethiopia](https://img.shields.io/badge/From-Ethiopia-brightgreen.svg)

Lucy Calendar is a powerful .NET package designed to seamlessly integrate Ethiopian calendrical functionality into your applications. With Lucy Calendar, you can effortlessly convert dates between the Gregorian and Ethiopian calendars, customize date formatting, and leverage advanced features for enhanced user experiences.

## Features:

+ **Bidirectional Conversion:** LucyCalendar effortlessly converts dates between the Gregorian and Ethiopian calendars, ensuring accurate results regardless of the direction of conversion.
+ **Service Integration:** With a simple service-oriented architecture, LucyCalendar seamlessly integrates into your application's service provider, providing easy access to its robust functionality.
+ **Date Formatting:** LucyCalendar offers flexible date formatting options, allowing you to customize the presentation of dates according to your preferences. Whether you need dates in Ethiopian format (ረቡዕ ፣ ሚያዝያ 02 2016 ዓ/ም) or Geez format (ረቡዕ ፣ ሚያዝያ ፪ ፳፻፲፮ ዓ/ም), LucyCalendar has you covered.
+ **Extensibility:** Built with extensibility in mind, LucyCalendar provides a solid foundation for further customization and expansion, allowing you to tailor its functionality to suit your specific requirements.

## Insatllation
### Package Manager
``` 
Insatall-Package LucyCalendar
```
### CLI
``` 
dotnet add package LucyCalendar
```
## Usage
```C#
var lucy = serviceProvider.GetService<ILucyCalendar>();
Console.WriteLine(lucy);										// 02/08/2016
Console.WriteLine(lucy?.FromDateTime(DateTime.Today));			// 02/08/2016
Console.WriteLine(lucy.ToString(DateFormat.DATE_ETHIOPIAN));	// ረቡዕ ፣ ሚያዝያ 02 2016 ዓ/ም
Console.WriteLine(lucy.ToString(DateFormat.DATE_GEEZ));			// ረቡዕ ፣ ሚያዝያ ፪ ፳፻፲፮ ዓ/ም
Console.WriteLine(DateTime.Now.ToEthiopian());					// 02/08/2016
```
# Contributing
Contributions to Lucy Calendar are welcome! Feel free to submit bug reports, feature requests, or pull requests to help improve the package.

