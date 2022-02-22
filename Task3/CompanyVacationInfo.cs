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
                .Select(employee => (employee.VacationsEnd.Month, employee))
                .ToList());

            return monthOfVacationAndEmployee.GroupBy(monthAndEmployee => monthAndEmployee.Month)
                .Select(monthAndEmployee => (monthAndEmployee.Key, monthAndEmployee.Select(x => x.employee).Count()));
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
