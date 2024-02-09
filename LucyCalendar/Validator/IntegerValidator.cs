using System;

namespace LucyCalendar.Validator;
public class IntegerValidator
{
    /**
    * @param array $integers a list of integers
    *
    * @return bool returns true if all the elements in the array are integer
    */
    public bool IsValidInteger(params int[] integers)
    {
        return Array.TrueForAll(integers, IsInt);
    }

    private bool IsInt(int number)
    {
        return number.GetType() == typeof(int);
    }
}