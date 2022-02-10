using System;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            CompanyVacationInfo info = new CompanyVacationInfo();

            EmployeeVacations m = new EmployeeVacations("Jack", new DateTime(2021, 1, 1), new DateTime(2021, 01, 10));
            EmployeeVacations n = new EmployeeVacations("Sarah", new DateTime(2021, 1, 6), new DateTime(2021, 01, 15));
            EmployeeVacations o = new EmployeeVacations("Sarah", new DateTime(2021, 4, 01), new DateTime(2021, 04, 03));
            EmployeeVacations p = new EmployeeVacations("Shawn", new DateTime(2021, 1, 10), new DateTime(2021, 1, 14));
            EmployeeVacations q = new EmployeeVacations("Ben", new DateTime(2021, 12, 02), new DateTime(2021, 12, 08));
            EmployeeVacations r = new EmployeeVacations("Ben", new DateTime(2021, 11, 10), new DateTime(2021, 11, 12));

            info.AddEmployeeVacations(q);
            //info.AddEmployeeVacations(q);
            info.AddEmployeeVacations(r);
            info.AddEmployeeVacations(m);
            info.AddEmployeeVacations(n);
            info.AddEmployeeVacations(o);
            info.AddEmployeeVacations(p);
            

            Console.WriteLine("avrage vacation length for all company");
            Console.WriteLine(info.AverageVacationLength());

            Console.WriteLine("---------------");
            Console.WriteLine("Average for each employee");
            foreach (var item in info.GetAverageOfEachEmployee())
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("---------------");
            Console.WriteLine("Employees on vacation per month");
            //info.EmployeesPerMonth();
            foreach (var item in info.EmployeesPerMonth())
            {
                Console.WriteLine(item);
            }

            info.DatesWithNoVacations();
        }
    }
}
