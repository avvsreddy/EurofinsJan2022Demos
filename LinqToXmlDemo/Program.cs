using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LinqToXmlDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            // Get all books which costs more than $5 into another xml doc

            // Load XML file into mem
            XDocument xml = XDocument.Load("XMLFile1.xml");


            XElement doc = new XElement("Books", 
                        from b in xml.Descendants("book")
                            where double.Parse(b.Element("price").Value) <= 5.0
                            select new XElement("Title",  b.Element("title").Value));

            doc.Save("e:\\books.xml");


            // linq to dataset


            // write a ado.net code to load table data into dataset
            // use linq to dataset to extract data from dataset

            // download LinqPad and learn builtin  examples
        }
    }
}
