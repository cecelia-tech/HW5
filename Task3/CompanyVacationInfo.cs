using System;
using System.Collections.Generic;
using System.Linq;

namespace Task3
{
    public class CompanyVacationInfo
    {
        //vardai gali kartotis

        public List<EmployeeVacations> AllVacationsRecords { get; set; } = new List<EmployeeVacations>();

        public CompanyVacationInfo()
        {
        }

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

            AllVacationsRecords.Add(x);
        }

        public double AverageVacationLength()
        {
            return AllVacationsRecords.Distinct().Select(x => x.VacationsTaken.TotalDays).Average();
        }

        public IEnumerable<(string, double)> GetAverageOfEachEmployee()
        {
            return AllVacationsRecords.Distinct().GroupBy(x => x.Name)
                .Select(x => ( x.Key, x.Select(c => c.VacationsTaken.TotalDays).Average()))
                .ToList();
        }

        public IEnumerable<(int, int)> EmployeesPerMonth()
        {
            Dictionary<int, int> a = new Dictionary<int, int>();

            for (int i = 1; i < 13; i++)
            {
                a.Add(i, 0);
            }

            foreach (var item in AllVacationsRecords.Distinct())
            {
                if (item.vacationsStart.Month == item.vacationsEnd.Month)
                {
                    a[item.vacationsStart.Month] += 1;
                }
                else
                {
                    a[item.vacationsStart.Month] += 1;
                    a[item.vacationsEnd.Month] += 1;
                }
            }
            return a.Select(x => (x.Key, x.Value));

            
            //List<DateTime> year = new List<DateTime>() {
            //    new DateTime(2021, 01, 01),
            //    new DateTime(2021, 02, 01)
            //};
            //var groupByStart = AllVacationsRecords.GroupBy(x => x.vacationsStart.Month).ToList();
            //var groupByEnd = AllVacationsRecords.GroupBy(x => x.vacationsEnd.Month).ToList();

            //AllVacationsRecords.Select(x => (x.));
            //AllVacationsRecords.GroupBy(x => (x.vacationsStart.Month, x.vacationsEnd.Month)).ToList().ForEach(item => item);
            //AllVacationsRecords.;
            //return AllVacationsRecords.Where(x => (x.vacationsStart.Month.Equals(x.vacationsEnd.Month))).Select(x => x.vacationsStart.Month);
            //return AllVacationsRecords.(x => (x.vacationsStart.Month, x.vacationsEnd.Month));

            //return AllVacationsRecords.Select(x => new { jan = (x.vacationsStart.Month == 1 || x.vacationsEnd.Month == 1)? 1: 0,
            //                                      feb = (x.vacationsStart.Month == 2 || x.vacationsEnd.Month == 2) ? 1 : 0,
            //                                      march = (x.vacationsStart.Month == 3 || x.vacationsEnd.Month == 3) ? 1 : 0,
            //                                      apr = (x.vacationsStart.Month == 4 || x.vacationsEnd.Month == 4) ? 1 : 0,
            //                                      may = (x.vacationsStart.Month == 5 || x.vacationsEnd.Month == 5) ? 1 : 0,
            //                                      june = (x.vacationsStart.Month == 6 || x.vacationsEnd.Month == 6) ? 1 : 0,
            //                                      dec = (x.vacationsStart.Month == 12 || x.vacationsEnd.Month == 12) ? 1 : 0,
            //}).ToList();

            //return AllVacationsRecords.GroupBy(x => (x.vacationsStart.Month ) switch
            //{
            //    int n when n == 1 => "January",
            //    int n when n == 2 => "February",
            //    int n when n == 3 => "March",
            //    int n when n == 4 => "April",
            //    int n when n == 5 => "May",
            //    int n when n == 6 => "June",
            //    int n when n == 7 => "July",
            //    int n when n == 8 => "August",
            //    int n when n == 9 => "September",
            //    int n when n == 10 => "October",
            //    int n when n == 11 => "November",
            //    _ => "December"
            //}).Select(x => (x.Key, x.Count())).ToList();

        }

        
        public bool AlreadyOnVacation(EmployeeVacations a)
        {
            foreach (var item in AllVacationsRecords)
            {
                if (a.Name.Equals(item.Name))
                {
                        //atostogos baigiasi per kitu pradzia
                    if ((a.vacationsStart.CompareTo(item.vacationsStart) == -1 && 
                        a.vacationsEnd.CompareTo(item.vacationsStart) == 1) ||
                        //atostogos prasideda nepasibaigus
                        (a.vacationsStart.CompareTo(item.vacationsEnd) == -1 &&
                        a.vacationsEnd.CompareTo(item.vacationsEnd) == 1) ||
                        //ta pati diena
                        (a.vacationsStart.Equals(item.vacationsStart) &&
                        a.vacationsEnd.Equals(item.vacationsEnd))
                        )
                    {
                        return true;
                    }
                }
            }
            return false;
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
