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

        public IEnumerable<(int, int)> EmployeesPerMonth()
        {
            var vacationStartMonths = allVacationsRecords.Select(x => x.vacationsStart.Month);

            var vacationsEndMonths = allVacationsRecords.Where(x => x.vacationsStart.Month != x.vacationsEnd.Month)
                                         .Select(x => x.vacationsEnd.Month);

            return vacationStartMonths.Concat(vacationsEndMonths).GroupBy(x => x)
                                    .Select(x => (x.Key, x.Count()))
                                    .OrderBy(x => x.Key);
        }


        public bool AlreadyOnVacation(EmployeeVacations a)
        {
            var r = allVacationsRecords.Where(x => x.Name.Equals(a.Name))
                                       .Where(x => a.vacationsStart <= x.vacationsEnd &&
                                                    a.vacationsEnd >= x.vacationsStart)
                                       .Count();

            return r == 0 ? false : true;
        }

        

        public IEnumerable<DateTime> DatesWithNoVacations()
        {
            DateTime end = new DateTime(2021, 12, 31);
            DateTime start = new DateTime(2021, 01, 01);
            //DateTime until = end;

            List<DateTime> allDays = new List<DateTime>();

            List<DateTime> unavailabeDates = new List<DateTime>();
            //List<(DateTime, DateTime)> unavailabeDates = new List<(DateTime, DateTime)>();
            //List<(DateTime, DateTime)> availabeDates = new List<(DateTime, DateTime)>();

            //var orderedList = allVacationsRecords.OrderBy(x => x.vacationsStart.Month)
                                                 //.ThenBy(x => x.vacationsStart.Day)
                                                 //.Select(x => (x.vacationsStart, x.vacationsEnd)).ToList();

            foreach (var item in allVacationsRecords.Select(x => (x.vacationsStart, x.vacationsEnd)).ToList())
            {
                var start1 = item.vacationsStart;
                var end1 = item.vacationsEnd;
                for (DateTime dt = start1; dt <= end1; dt = dt.AddDays(1))
                {
                    unavailabeDates.Add(dt);
                }
            }

            for (DateTime dt = start; dt <= end; dt = dt.AddDays(1))
            {
                allDays.Add(dt);

            }

            var ad = allDays.Except(unavailabeDates.Distinct());
            //unavailabeDates.Add(orderedList.Where(x => ))
            //Console.WriteLine("-----------");
            //foreach (var item in orderedList)
            //{
            //    Console.WriteLine($"{item.vacationsStart.ToShortDateString()} {item.vacationsEnd.ToShortDateString()}");
            //}
            //Console.WriteLine("-----------");

            //for (DateTime dt = start; dt <= end; dt.AddDays(1))
            //{

            //    //orderedList.Where(x => dt >= x.vacationsStart && dt <= x.vacationsEnd).ToList().ForEach(x => allDays.Add(dt));
            //    foreach (var startFinish in orderedList)
            //    {
            //        if (dt >= startFinish.vacationsStart && dt <= startFinish.vacationsEnd)
            //        {
            //            continue;
            //        }
            //        else
            //        {
            //            allDays.Add(dt);
            //        }
            //    }
            //}
            return ad;

            //foreach (var entry in orderedList)
            //{
            //    int count = unavailabeDates.Count() - 1;

            //    if (unavailabeDates.Count() == 0)
            //    {
            //        unavailabeDates.Add((entry.vacationsStart, entry.vacationsEnd));
            //    }
            //    else
            //    {
            //        if (entry.vacationsStart <= unavailabeDates[count].Item2 && entry.vacationsEnd > unavailabeDates[count].Item2)
            //        {
            //            unavailabeDates[count] = (unavailabeDates[count].Item1, entry.vacationsEnd);
            //        }
            //        else if (entry.vacationsStart > unavailabeDates[count].Item2)
            //        {
            //            unavailabeDates.Add((entry.vacationsStart, entry.vacationsEnd));
            //        }
            //    }
            //}

            //availabeDates.Add(start.AddDays(unavailabeDates.Select(x => x.Item1.Subtract(start).TotalDays)))
            //unavailabeDates.
            //foreach (var item in unavailabeDates)
            //{
            //    if (start == item.Item1)
            //    {
            //        start = item.Item2.AddDays(1);
            //    }
            //    else
            //    {
            //        until = item.Item1.AddDays(-1);
            //    }
            //    if (until != end)
            //    {
            //        availabeDates.Add((start, until));
            //        start = item.Item2.AddDays(1);
            //        until = end;
            //    }
            //    if (item.Equals(unavailabeDates[unavailabeDates.Count() - 1]))
            //    {
            //        availabeDates.Add((start, until));
            //    }
            //}
            //return availabeDates.OrderBy(x => x.Item1).ThenBy(x => x.Item2);
        }
    } 
}
