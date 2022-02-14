using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSWithDesignPatternsDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {

            ITaxCalculator tax = new APTaxCalculator();
            BillingSystem billing = new BillingSystem();
            billing.GenerateBill();

            //TaxCalculatorFactory f1 = TaxCalculatorFactory.Instance;
            //TaxCalculatorFactory f2 = TaxCalculatorFactory.Instance; ;

            //Console.WriteLine(f1.GetHashCode());
            //Console.WriteLine(f2.GetHashCode()); ;

            Console.ReadLine();
        }
    }
    class BillingSystem
    {

        // constructor
        // method
        // property

        //public BillingSystem(ITaxCalculator tax)
        //{
        //    taxCalculator = tax;
        //}

        //TaxCalculatorFactory factory = null;// new TaxCalculatorFactory();

        private ITaxCalculator taxCalculator = null;
        public void GenerateBill()
        {
            // calculate items amount
            // calculate discounts
            // coupons 
            // calculate the tax
            double amount = 5000;
            taxCalculator = TaxCalculatorFactory.Instance.CreateTaxCalculator();
            double tax = taxCalculator.CalculateTax(amount);
            // calculate the bill amount
            double totBillAmount = tax + 4000 - 1200;
            // print the bill
        }

       
    }

    class TaxCalculatorFactory
    {

        private TaxCalculatorFactory()
        {
        }
        public static readonly TaxCalculatorFactory Instance = new TaxCalculatorFactory();

        //private static TaxCalculatorFactory instance = null;
        //public static TaxCalculatorFactory GetInstance()
        //{
        //    object obj1 = new object();
        //    lock (obj1)
        //    {
        //        if (instance == null)
        //        {
        //            object obj2 = new object();
        //            lock (obj2)
        //            {
        //                instance = new TaxCalculatorFactory();
        //            }
        //        }
        //    }
        //    return instance;
        //}
        public virtual  ITaxCalculator CreateTaxCalculator()
        {
            // read the calc name from config file
            string calc = ConfigurationManager.AppSettings["CALC"];
            // use reflextion
            Type theType = Type.GetType(calc);
            return (ITaxCalculator)Activator.CreateInstance(theType);

        }
    }

    interface ITaxCalculator // Strategy
    {
        double CalculateTax(double amount); // algo
    }

    class KATaxCalculator : ITaxCalculator // Concrete Strategy
    {
        public double CalculateTax(double amount)
        {
            int cst = 100;
            int st = 30;
            int es = 60;
            int sbt = 50;
            Console.WriteLine("Using KA Tax Calculator");
            return cst + st + es + sbt;
        }
    }

    class TNTaxCalculator : ITaxCalculator
    {
        public double CalculateTax(double amount)
        {
            int cst = 100;
            int st = 35;
            int abc = 20;
            int xyz = 70;
            Console.WriteLine("Using TN Tax Calculator");
            return cst + st + abc + xyz;
        }
    }

    class APTaxCalculator : ITaxCalculator
    {
        public double CalculateTax(double amount)
        {
            Console.WriteLine("Using AP Tax Calculator");
            return 450;
        }
    }
}
