using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseLibrary.API.Helpers
{
    public static class DateTimeOffsetExtensions
    {
        public static int GetCurrentAge(this DateTimeOffset dateTimeOffset,
            DateTimeOffset? dateOfDeath)
        {
            var dateToCalculateTo = DateTime.UtcNow;

            if (dateOfDeath != null)
            {
                dateToCalculateTo = dateOfDeath.Value.UtcDateTime;
            }

            var age = dateToCalculateTo.Year - dateTimeOffset.Year;

            if (dateToCalculateTo < dateTimeOffset.AddYears(age))
            {
                age--;
            }

            return age;           
        }

        public static int GetReBornAge(this DateTimeOffset? dateReborn  , 
            DateTimeOffset dateOfBirth, DateTimeOffset? dateOfDeath)
        {
            if (dateReborn == null)
            {
                return 0;
            }

            if (dateReborn < dateOfBirth)
            {
                return 0;
            }
            var dateToCalculateTo = DateTime.UtcNow;

            if (dateOfDeath != null)
            {
                dateToCalculateTo = dateOfDeath.Value.UtcDateTime;
            }
            var rebornAge = 1;

            if (dateReborn != null)
            {
                dateOfBirth = (DateTimeOffset)dateReborn;
                rebornAge = dateToCalculateTo.Year - dateOfBirth.Year;
            }

            if (dateToCalculateTo < dateOfBirth.AddYears(rebornAge))
            {
                rebornAge--;
            }

            return rebornAge;          
        }

      
    }
}
