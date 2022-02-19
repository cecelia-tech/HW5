using System;
using System.Collections.Generic;
using System.Linq;

namespace Task3
{
    public class CompanyVacationInfo
    {
        private List<EmployeeVacations> allVacationsRecords = new List<EmployeeVacations>();

        public void AddEmployeeVacations(EmployeeVacations x)
        {
            if (x is null)
            {
                throw new ArgumentNullException();
            }
            
            if (AlreadyOnVacation(x))
            {
                throw new ArgumentException("Employee is already on vacation");
            }

            allVacationsRecords.Add(x);
        }

        public double AverageVacationLength()
        {
            return allVacationsRecords.Distinct()
                                      .Select(x => x.VacationsTaken.TotalDays)
                                      .Average();
        }

        public IEnumerable<(string, double)> GetAverageOfEachEmployee()
        {
            return allVacationsRecords.Distinct().GroupBy(x => x.Name)
                                      .Select(x => ( x.Key, x.Select(c => c.VacationsTaken.TotalDays).Average()))
                                      .ToList();
        }

        //method returns first int as a month, second int as a number of employees
        public IEnumerable<(int, int)> EmployeesPerMonth()
        {
            var vacationStartMonths = allVacationsRecords.Select(x => x.VacationsStart.Month);

            var vacationsEndMonths = allVacationsRecords.Where(x => x.VacationsStart.Month != x.VacationsEnd.Month)
                                         .Select(x => x.VacationsEnd.Month);

            return vacationStartMonths.Concat(vacationsEndMonths).GroupBy(x => x)
                                    .Select(x => (x.Key, x.Count()))
                                    .OrderBy(x => x.Key);
        }


        public bool AlreadyOnVacation(EmployeeVacations a)
        {
            var r = allVacationsRecords.Where(x => x.Name.Equals(a.Name))
                                       .Where(x => a.VacationsStart <= x.VacationsEnd &&
                                                    a.VacationsEnd >= x.VacationsStart)
                                       .Count();

            return r == 0 ? false : true;
        }

        

        public IEnumerable<DateTime> DatesWithNoVacations()
        {
            DateTime end = new DateTime(2021, 12, 31);
            DateTime start = new DateTime(2021, 01, 01);

            List<DateTime> allDays = new List<DateTime>();
            List<DateTime> unavailabeDates = new List<DateTime>();
            
            foreach (var item in allVacationsRecords.Select(x => (x.VacationsStart, x.VacationsEnd)).ToList())
            {
                var itemStart = item.VacationsStart;
                var itemEnd = item.VacationsEnd;
                for (DateTime dt = itemStart; dt <= itemEnd; dt = dt.AddDays(1))
                {
                    unavailabeDates.Add(dt);
                }
            }

            for (DateTime dt = start; dt <= end; dt = dt.AddDays(1))
            {
                allDays.Add(dt);
            }

            var availableDays = allDays.Except(unavailabeDates.Distinct());
            
            return availableDays;
        }
    } 
}
