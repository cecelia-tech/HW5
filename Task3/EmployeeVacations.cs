using System;

namespace Task3
{
    public class EmployeeVacations
    {
        public string Name { get; private set; }
        public TimeSpan VacationsTaken { get; private set; }
        public DateTime vacationsStart { get; private set; }
        public DateTime vacationsEnd { get; private set; }

        public EmployeeVacations(string name, DateTime firstVacationDay, DateTime lastVacationDay)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Name entry is not valid");
            }
            else
            {
                Name = name;
            }

            if ((firstVacationDay.Year != 2021 && lastVacationDay.Year != 2021) ||
                firstVacationDay >= lastVacationDay)
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
