using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODemo3
{
    class Program
    {
        static void Main(string[] args)
        {
            B b = new B();
            b.B1();
        }
    }

    class A
    {
        public void A1() { }
        public void A2() { }
    }

    class B //  :  A // IS-A
    {

        private A a = new A(); // HAS-A
        public void B1() {

            A aa = new A(); // Uses

            a.A1(); }
        public void B2() { a.A2(); }
    }
}
