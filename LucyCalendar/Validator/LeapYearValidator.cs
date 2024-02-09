using System;

namespace LucyCalendar.Validator;
/**
 * Ethiopian Leap Year Validator.
 */
public class LeapYearValidator : IntegerValidator, IValidator
{
    private int year;

    /**
     * Leap Year Validator constructor.
     *
     * @param year int the year
     */
    public LeapYearValidator(int year)
    {
        this.year = year;
    }

    /**
     * @return bool true if valid
     */
    public bool IsValid()
    {
        return IsValidInteger(year) && IsValidLeapYear(year);
    }

    /**
     * @param year int
     *
     * @return bool true if valid
     */
    private bool IsValidLeapYear(int year)
    {
        return (year + 1) % 4 == 0;
    }
}