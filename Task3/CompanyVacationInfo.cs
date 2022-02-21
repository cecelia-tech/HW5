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
            List<(int Month, EmployeeVacations employee)> monthOfVacationAndEmployee;

            monthOfVacationAndEmployee = allVacationsRecords.Select(employee =>
                                            (employee.VacationsStart.Month, employee))
                                            .ToList();

            monthOfVacationAndEmployee.AddRange(allVacationsRecords
                .Where(employee => employee.VacationsStart.Month != employee.VacationsEnd.Month)
                .Select(x => (x.VacationsEnd.Month, x)).ToList());

            return monthOfVacationAndEmployee.GroupBy(x => x.Month)
                .Select(employee => (employee.Key, employee.Count()));

            //var q = allVacationsRecords.Select(x =>
            //new { MonthStart = x.VacationsStart.Month, MonthEnd = x.VacationsEnd.Month, Employee = x })
            //    .Where(x => x.MonthStart != x.MonthEnd).Select(x => x.MonthEnd);

            
            //var e = allVacationsRecords.(x => x.VacationsStart == x.VacationsEnd? x.VacationsStart.Month: x.VacationsEnd)
            //epm.Add(allVacationsRecords.Select(x => ))
            //List<(int, int)> epm = new List<(int, int)>();

            //epm.Add(allVacationsRecords.Select(x => (x.VacationsStart.Month == x.VacationsEnd.Month ? )))
            //var a = allVacationsRecords.Select(x => (x.VacationsStart.Month, ))
            //var so = allVacationsRecords.Select(x => (x.VacationsStart.Month == x.VacationsEnd.Month? (x.VacationsStart.Month, x) : x.))
            //var vacationStartMonths = allVacationsRecords.Select(x => (allVacationsRecords.GroupBy(x => x.VacationsStart)
            //.Select(x => (x.Key, x.Count(), allVacationsRecords.Where(x => x.VacationsStart.Month != x.VacationsEnd.Month)
            //.GroupBy(x => x.VacationsEnd).Select(x => (x.Key, x.Count()))));

            //var vacationStartMonths = allVacationsRecords.Select(x => (allVacationsRecords.GroupBy(x => x.VacationsStart.Month)
            //.Select(x => (x.Key, x.Count()))));

            //var vacationsEndMonths = allVacationsRecords.Where(x => x.VacationsStart.Month != x.VacationsEnd.Month)
            //    .GroupBy(x => x.VacationsEnd.Month)
            //                             .Select(x => (x.Key, x.Count()));
            //var vacationStartMonths = allVacationsRecords.GroupBy(x => x.VacationsStart).Select(x => (x, x.Count()));

            //var vacationsEndMonths = allVacationsRecords.Where(x => x.VacationsStart.Month != x.VacationsEnd.Month)
            //.Select(x => x);
            //
            //return vacationStartMonths.Concat(vacationsEndMonths).GroupBy(x => x.)
            //                        .Select(x => (x.Key, x.Count()))
            //                        .OrderBy(x => x.Key);
        }


        public bool AlreadyOnVacation(EmployeeVacations employee)
        {
            var result = allVacationsRecords.Where(x => x.Name.Equals(employee.Name))
                                       .Where(x => employee.VacationsStart <= x.VacationsEnd &&
                                                    employee.VacationsEnd >= x.VacationsStart)
                                       .Count();

            return result == 0 ? false : true;
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
