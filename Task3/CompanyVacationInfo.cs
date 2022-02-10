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
            Dictionary<int, int> a = new Dictionary<int, int>();

            var start = allVacationsRecords.Select(x => x.vacationsStart);

            var end = allVacationsRecords.Where(x => x.vacationsStart.Month != x.vacationsEnd.Month)
                                         .Select(x => x.vacationsEnd);

            start.Concat(end).GroupBy(x => x.Month)
                             .Select(x => (x.Key, x.Count())).ToList().
                             ForEach(x => a.Add(x.Key, x.Item2));

            foreach (var month in Enumerable.Range(1, 12))
            {
                if (a.ContainsKey(month))
                {
                    continue;
                }
                else
                {
                    a.Add(month, 0);
                }
            }
            return a.OrderBy(x => x.Key).Select(x => (x.Key, x.Value));
        }


        public bool AlreadyOnVacation(EmployeeVacations a)
        {
            var r = allVacationsRecords.Where(x => x.Name.Equals(a.Name))
                                       .Where(x => a.vacationsStart <= x.vacationsEnd &&
                                                    a.vacationsEnd >= x.vacationsStart)
                                       .Count();

            return r == 0 ? false : true;
        }
        static DateTime end = new DateTime(2021, 12, 31);

        public IEnumerable<(DateTime, DateTime)> DatesWithNoVacations()
        {   
            DateTime start = new DateTime(2021, 01, 01);
            DateTime until = end;
            List<(DateTime, DateTime)> unavailabeDates = new List<(DateTime, DateTime)>();
            List<(DateTime, DateTime)> availabeDates = new List<(DateTime, DateTime)>();

            var orderedList = allVacationsRecords.OrderBy(x => x.vacationsStart.Month)
                                                 .ThenBy(x => x.vacationsStart.Day)
                                                 .Select(x => (x.vacationsStart, x.vacationsEnd));

            foreach (var entry in orderedList)
            {
                int count = unavailabeDates.Count() - 1;

                if (unavailabeDates.Count() == 0)
                {
                    unavailabeDates.Add((entry.vacationsStart, entry.vacationsEnd));
                }
                else
                {
                    if (entry.vacationsStart <= unavailabeDates[count].Item2 && entry.vacationsEnd > unavailabeDates[count].Item2)
                    {
                        unavailabeDates[count] = (unavailabeDates[count].Item1, entry.vacationsEnd);
                    }
                    else if (entry.vacationsStart > unavailabeDates[count].Item2)
                    {
                        unavailabeDates.Add((entry.vacationsStart, entry.vacationsEnd));
                    }
                }
            }

            foreach (var item in unavailabeDates)
            {
                if (start == item.Item1)
                {
                    start = item.Item2.AddDays(1);
                }
                else
                {
                    until = item.Item1.AddDays(-1);
                }
                if (until != end)
                {
                    availabeDates.Add((start, until));
                    start = item.Item2.AddDays(1);
                    until = end;
                }
            }

            foreach (var item in availabeDates.OrderBy(x => x.Item1).ThenBy(x => x.Item2))
            {
                Console.WriteLine($"{item.Item1.ToShortDateString()} - {item.Item2.ToShortDateString()}");
            }

            return availabeDates.OrderBy(x => x.Item1).ThenBy(x => x.Item2);
        }

        //public override bool Equals(object obj)
        //{
        //    if (obj is EmployeeVacations employee)
        //    {
        //        foreach (var item in AllVacationsRecords)
        //        {
        //            if (employee.Name.Equals(item.Name) &&
        //                employee.vacationsStart.Equals(item.vacationsStart) &&
        //                employee.vacationsEnd.Equals(item.vacationsEnd))
        //            {
        //                return true;
        //            }
        //        }
        //    }
        //    return false;
        //}

        //public override int GetHashCode()
        //{
        //    return base.GetHashCode();
        //}
    } 
}
/*
 using System;
using System.Text.Json;
 
namespace HelloApp
{
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Person tom = new Person { Name = "Tom", Age = 35 };
            string json = JsonSerializer.Serialize<Person>(tom);
            Console.WriteLine(json);
            Person restoredPerson = JsonSerializer.Deserialize<Person>(json);
            Console.WriteLine(restoredPerson.Name);
        }
    }
}
 */