using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODemo1
{
    class Program // A
    {

        private static Person p = new Person();

        static void Main(string[] args)
        {
            Console.WriteLine("I am in Program Main");
            Console.WriteLine( p.GetName());
            p = new Customer();
            Console.WriteLine(p.GetName());

        }
    }

    class Person  // B
    {
        public virtual string GetName()
        {
            return "I am a person called Ramesh";
        }
    }

    class Customer : Person  // B1
    {
        public override string GetName()
        {
            return "I am a Customer called Ravi";
        }
    }
}
