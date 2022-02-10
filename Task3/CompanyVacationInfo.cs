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

        public void DatesWithNoVacations()
        {
            //IEnumerable<(DateTime, DateTime)>

            List<(DateTime, DateTime)> unavailabeDates = new List<(DateTime, DateTime)>() {
            };
            //(allVacationsRecords.First().vacationsStart, allVacationsRecords.First().vacationsEnd)
            var orderedList = allVacationsRecords.OrderBy(x => x.vacationsStart.Month)
                                                 .ThenBy(x => x.vacationsStart.Day)
                                                 .Select(x => (x.vacationsStart, x.vacationsEnd));


            var start = new DateTime(2021, 01, 01);
            var until = DateTime.MinValue;
            
            //var duration = until.Subtract(start).TotalDays + 1;

            //Console.WriteLine(duration);

            //DateTime s = allVacationsRecords.First().vacationsStart;

            //DateTime f = allVacationsRecords.First().vacationsEnd ;


            //unavailabeDates.Add((s, f));
            

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


                    //for (int i = 0; i < count; i++)
                    //{
                    //    if (entry.vacationsStart <= unavailabeDates[i].Item2 && entry.vacationsEnd > unavailabeDates[i].Item2)
                    //    {
                    //        unavailabeDates[i] = (unavailabeDates[i].Item1, entry.vacationsEnd);
                            
                    //    }
                    //    else if(entry.vacationsStart > unavailabeDates[i].Item2)
                    //    {
                    //        unavailabeDates.Add((entry.vacationsStart, entry.vacationsEnd));
                    //        count++;
                    //        break;
                    //    }
                        //else
                        //{
                        //    break;
                        //}


                    //}
                }
                
                //foreach (var item in unavailabeDates.ToList())
                //{
                //    if (entry.vacationsStart <= item.Item2 && entry.vacationsEnd > item.Item2)
                //    {
                //        unavailabeDates[unavailabeDates.IndexOf((item.Item1, item.Item2))] = (entry.vacationsStart, item.Item2);
                //    }
                //    else
                //    {
                //        unavailabeDates.Add((entry.vacationsStart, entry.vacationsEnd));
                //    }
                //    break;
                //}
                
            }
            foreach (var item in unavailabeDates.OrderBy(x => x.Item1).ThenBy(x => x.Item2))
            {
                Console.WriteLine($"{item.Item1.ToShortDateString()} - {item.Item2.ToShortDateString()}");
            }
            //allVacationsRecords.ForEach(item => s = item.vacationsStart);
            //for (DateTime dt = start; dt < until; dt = dt.AddDays(1))
            //{
            //    foreach (var item in orderedList)
            //    {
            //        if (true)
            //        {

            //        }
            //    }
            //}
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