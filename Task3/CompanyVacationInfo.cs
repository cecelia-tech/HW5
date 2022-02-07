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
            AllVacationsRecords.Add(x);
        }

        public double AverageVacationLength()
        {
            return AllVacationsRecords.Select(x => x.VacationsTaken.TotalDays).Average();
        }

        public IEnumerable<(string, double)> GetAverageOfEachEmployee()
        {
            return AllVacationsRecords.GroupBy(x => x.Name).Select(x => ( x.Key, x.Select(c => c.VacationsTaken.TotalDays).Average())).ToList();

            //return AllVacationsRecords.Where((x,y) => x.Name.Equals(x.Name)).Select(x => (x.Name, x.VacationsTaken.TotalDays));
            //return a;
        }

        public IEnumerable<(int, int)> EmployeesPerMonth()
        {
            var groupByStart = AllVacationsRecords.GroupBy(x => x.vacationsStart.Month).ToList();
            var groupByEnd = AllVacationsRecords.GroupBy(x => x.vacationsEnd.Month).ToList();
            //AllVacationsRecords.GroupBy(x => (x.vacationsStart.Month, x.vacationsEnd.Month)).ToList().ForEach(item => item);
            //AllVacationsRecords.;
            //return AllVacationsRecords.Where(x => (x.vacationsStart.Month.Equals(x.vacationsEnd.Month))).Select(x => x.vacationsStart.Month);
            return AllVacationsRecords.(x => (x.vacationsStart.Month, x.vacationsEnd.Month));

            //return AllVacationsRecords.Select(x => new { jan = (x.vacationsStart.Month == 1 || x.vacationsEnd.Month == 1)? 1: 0,
            //                                      feb = (x.vacationsStart.Month == 2 || x.vacationsEnd.Month == 2) ? 1 : 0,
            //                                      march = (x.vacationsStart.Month == 3 || x.vacationsEnd.Month == 3) ? 1 : 0,
            //                                      apr = (x.vacationsStart.Month == 4 || x.vacationsEnd.Month == 4) ? 1 : 0,
            //                                      may = (x.vacationsStart.Month == 5 || x.vacationsEnd.Month == 5) ? 1 : 0,
            //                                      june = (x.vacationsStart.Month == 6 || x.vacationsEnd.Month == 6) ? 1 : 0,
            //                                      dec = (x.vacationsStart.Month == 12 || x.vacationsEnd.Month == 12) ? 1 : 0,
            //}).ToList();

            //return AllVacationsRecords.GroupBy(x => x.vacationsStart.Month switch
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

            //return AllVacationsRecords.Where(x => switch
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
    }
}
