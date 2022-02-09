using System;
using System.Collections.Generic;

namespace Task3
{
    public class EmployeeVacations
    {
        public string Name { get; set; }
        public TimeSpan VacationsTaken { get; set; }
        public DateTime vacationsStart { get; set; }
        public DateTime vacationsEnd { get; set; }

        public EmployeeVacations(string name, DateTime firstVacationDay, DateTime lastVacationDay)
        {
            if (name is null)
            {
                throw new ArgumentNullException("Name is null");
            }
            else if (name.Equals(string.Empty))
            {
                throw new ArgumentException("Name can't be empty");
            }
            else
            {
                Name = name;
            }

            if ((firstVacationDay.Year != 2021 && lastVacationDay.Year != 2021) ||
                firstVacationDay.CompareTo(lastVacationDay) == 1)
            {
                throw new ArgumentException("Dates are not correct");
            }
            else
            {
                vacationsStart = firstVacationDay;
                vacationsEnd = lastVacationDay;

                VacationsTaken = lastVacationDay.Subtract(firstVacationDay);
            }
        }
    }
}
