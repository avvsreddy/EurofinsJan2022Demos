using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageEnhancementDemo
{
    internal class Program
    {

        static void Main(string[] args)
        {

            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            int sum = 0;
            foreach (var n in numbers)
            {
                if( n % 2 == 0)
                sum += n;
            }

            //Func<int, bool> filter = new Func<int, bool>(IsEven);
            //var s = numbers.Where(IsEven).Sum();

            var s = numbers.Where(delegate (int n)
                {
                    return n % 2 == 0;
                }).Sum();

             s = numbers.Where((int n) =>
            {
                return n % 2 == 0;
            }).Sum();


            s = numbers.Where((int n) =>
            {
                return n % 2 == 0;
            }).Sum();


            s = numbers.Where((int n) =>
           
                 n % 2 == 0
            ).Sum();

            s = numbers.Where(n => n % 2 == 0).Sum();

            // Lambda - Light weight syntax for anymous delegates
            // Lambda Statements
            // Lambda Expressions
            // if(a > 10) return a else return 0 // statemetn
            // a+b+10-40  // expression


            var ss = (from n in numbers
                      where n % 2 == 0
                      select n).Sum();

            // SQL => select sum(number) where number mod 2 = 0 from numbers;

            Console.WriteLine(sum);


            int? x = null;
            int? xx = 10;
            Nullable<int> sal = null;
            int? salary = null;
            double? d = null;
            bool? b = null;
            string str = null;

            // 1. Local Veriable Type Inference
            var a =10;
            //a = "10";
            var code = "abc";
            var rate = 56.78;
            var dict = new Dictionary<string, int>();
            //var n = int.Parse(Console.ReadLine());

            // 2. object initialization syntax
            var i1 = new Item();
            i1.Id = 111;
            i1.Name = "Pen";
            i1.Cost = 150;
            Console.WriteLine(i1.Cost);

            // Object Initialization Syntax
            //Item i2 = new Item(222,"Book", 250);
            __anoymous34234234234 i2 = new __anoymous34234234234 { Id= 222, Name ="Book", Cost=250 };
            
            var i3 = new  { Id=333 };
            //i3.Id = 444;
            var i4 = new  { Name="Pencil" };

            var i5 = new  { Id=555, Name="Note Book" };

            // 3: Anonymous Types

            // 4: Extension Methods

            string data = "some data";
            data = data.ToUpper();
            data = data.ToLower();
            data = data.Substring(1, 2);
            data = data.Encrypt("MD5");
            data = DataUtil.Encrypt(data,"SHA256");


        }

        //public static bool IsEven(int n)
        //{
        //    return n % 2 == 0;
        //}
    }

    static class DataUtil
    {
        public static string Encrypt(this string data, string type)
        {
            return "#$%#$%#FEGDFGDFG%#$^#$^#%^#TRDGERGET#$%#$%";
        }
    }

    class __anoymous34234234234
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
    }


    class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
    }
}
