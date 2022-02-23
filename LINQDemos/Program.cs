using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQDemos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //LINQ To Objects

            // 1. Get all employee names and display
            var r1 = from e in Emp.GetEmps()
                     select e.Name;
            var r11 = Emp.GetEmps().Select(e => e.Name);

            foreach (var item in r1)
            {
                Console.WriteLine(item);
            }

            // 2. Get all employee names and salaries then display
            var r2 = from e2 in Emp.GetEmps()
                     select new  {e2.Name,e2.Salary };

            // 3. Get all emp names from HR dept
            var r3 = from e3 in Emp.GetEmps()
                     where e3.Dept == "HR"
                     select e3.Name;
            // 4. Get Total Salary of all emps
            var r4 = Emp.GetEmps().Sum(e => e.Salary);

            var r44 = (from e4 in Emp.GetEmps()
                       select e4.Salary).Sum();

            // 5. Get Total Salary of emps working in IT dept
            var r5 = (from e5 in Emp.GetEmps()
                      where e5.Dept == "IT"
                      select e5.Salary).Sum();
            var r55 = Emp.GetEmps().Where(e => e.Dept == "IT").Sum(e => e.Salary);
            // 6. Get Total count of all emps working in SW dept
            var r6 = (from e6 in Emp.GetEmps()
                      where e6.Dept.Equals("SW") select e6).Count();

            // 7. Get the Avg salary of all emp
            var r7 = Emp.GetEmps().Average(e => e.Salary);

            // 8. Get the name of the emp who is getting highest salary
            var r8 = (from e8 in Emp.GetEmps()
                     where e8.Salary == Emp.GetEmps().Max(e => e.Salary)
                     select e8.Name).FirstOrDefault();

            // 9. Get the name of the emp who is getting lowest salary
            var r9 = Emp.GetEmps().Where(e9 => e9.Salary == Emp.GetEmps().Min(e => e.Salary)).Select(e => e.Name);

            var r99 = (from e9 in Emp.GetEmps()
                       orderby e9.Salary 
                       select e9.Name).FirstOrDefault();

            // 10. Get all employees name and salary who is getting salary more than 75k
            var r10 = from e10 in Emp.GetEmps()
                      where e10.Salary >= 75000
                      select new { e10.Name, e10.Salary };


        }
    }
    //class EmpNameSal
    //{
    //    public string Name { get; set; }
    //    public int Salary { get; set; }
    //}
    class Emp
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public string Dept { get; set; }

        public static List<Emp> GetEmps()
        {
            List<Emp> emps = new List<Emp> 
            {
                new Emp{Id=111, Name="Ramesh", Salary=67000, Dept="HR"},
                new Emp{Id=345, Name="Girish", Salary=57000, Dept="HR"},
                new Emp{Id=222, Name="Suresh", Salary=27000, Dept="IT"},
                new Emp{Id=112, Name="Mahesh", Salary=57000, Dept="HR"},
                new Emp{Id=211, Name="Kamesh", Salary=67000, Dept="IT"},
                new Emp{Id=456, Name="Lokesh", Salary=67000, Dept="IT"},
                new Emp{Id=234, Name="Ravi", Salary=67000, Dept="ACC"},
                new Emp{Id=678, Name="Suri", Salary=50000, Dept="ACC"},
                new Emp{Id=178, Name="Sita", Salary=25000, Dept="HR"},
                new Emp{Id=367, Name="Kamala", Salary=64000, Dept="SW"},
                new Emp{Id=784, Name="Shreya", Salary=62000, Dept="HR"},
                new Emp{Id=231, Name="Anitha", Salary=67000, Dept="SW"},
            };
            return emps;
        }
    }
}
