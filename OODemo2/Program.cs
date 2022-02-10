using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODemo2
{
    class Program
    {
        static void Main(string[] args)
        {
            string doc = "good";
            HybridParser hp = new HybridParser();
            hp.SetParser(new ExcellentParser());
            hp.Parse(doc);
           
        }
    }

    abstract class GenericXMLParser
    {
        public abstract void Parse(string doc);
    }
    class DOMParser : GenericXMLParser
    {
        public override void Parse(string doc)
        {
            Console.WriteLine("Parsing using DOM Parser");
        }
    }
    class SAXParser : GenericXMLParser
    {
        public override void Parse(string doc)
        {
            Console.WriteLine("Parsing using SAX Parser");
        }
    }
    class GoodParser : GenericXMLParser
    {
        public override void Parse(string doc)
        {
            Console.WriteLine("Parsing using Good Parser");
        }
    }
    class HybridParser : GenericXMLParser
    {
        private GenericXMLParser parser;

        public void SetParser(GenericXMLParser p)
        {
            parser = p;
        }
        public override void Parse(string doc)
        {
            parser.Parse(doc);
        }
    }
    class ExcellentParser : GenericXMLParser
    {
        public override void Parse(string doc)
        {
            Console.WriteLine("Using Excellent Parser");
        }
    }
}
