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
        }
    }
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
