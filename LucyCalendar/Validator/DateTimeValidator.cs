using System;

namespace LucyCalendar.Validator;
    /**
     * Ethiopian DateValidator.
     */
    public class DateValidator : IntegerValidator, IValidator
    {
        private const int FIRST_DAY = 1;
        private const int FIRST_MONTH = FIRST_DAY;
        private const int LAST_DAY = 30;
        private const int LAST_MONTH = 13;
        private const int PAGUME_LAST_DAY = 5;
        private const int PAGUME_LEAP_YEAR_LAST_DAY = 6;

        private int day;
        private int month;
        private int year;

        /**
         * DateValidator constructor.
         *
         * @param day   int
         * @param month int
         * @param year  int
         */
        public DateValidator(int day, int month, int year)
        {
            this.day = day;
            this.month = month;
            this.year = year;
        }

        /**
         * Validate the Ethiopian date.
         *
         * @return bool true if valid
         */
        public bool IsValid()
        {
            Func<bool>[] validators = {
                IsDateValuesIntegers,
                IsValidDayRange,
                IsValidMonthRange,
                IsValidPagumeDayRange,
                IsValidLeapDay
            };

            return validators.All(validator => validator());
        }

        /**
         * @return bool
         */
        private bool IsValidDayRange()
        {
            return day >= FIRST_DAY && day <= LAST_DAY;
        }

        /**
         * @return bool
         */
        private bool IsValidMonthRange()
        {
            return month >= FIRST_MONTH && month <= LAST_MONTH;
        }

        /**
         * @return bool
         */
        private bool IsValidPagumeDayRange()
        {
            if (month == LAST_MONTH)
            {
                return day <= PAGUME_LEAP_YEAR_LAST_DAY;
            }

            return true;
        }

        /**
         * @return bool
         */
        private bool IsValidLeapDay()
        {
            if (month == LAST_MONTH && day == PAGUME_LEAP_YEAR_LAST_DAY)
            {
                return new LeapYearValidator(year).IsValid();
            }

            return true;
        }

        /**
         * @return bool
         */
        private bool IsDateValuesIntegers()
        {
            return IsValidInteger(day, month, year);
        }
    }