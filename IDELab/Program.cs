using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDELab
{
    class Program
    {
        static void Main(string[] args)
        {
            IDE i = new IDE();
            i.Languages.Add(new LangCSharp());
            //i.Languages.Add(new LangJava());
            i.Languages.Add(new LangVBNet());
            i.Languages.Add(new LangC());
            i.WorkWithLanguages();
        }
    }

    class IDE
    {
        public List<ILanguage> Languages { get; set; } = new List<ILanguage>();
        public void WorkWithLanguages()
        {
            foreach (ILanguage lang in Languages)
            {
                Console.WriteLine(lang.GetName());
                Console.WriteLine(lang.GetParadigm());
                Console.WriteLine(lang.GetUnit());
            }
        }
    }


    interface ILanguage
    {
        string GetName();
        string GetParadigm();
        string GetUnit();
    }

    abstract class OOLanguage : ILanguage
    {
        abstract public string GetName();
       
        public string GetParadigm()
        {
            return "OOP";
        }
        public string GetUnit()
        {
            return "Class";
        }
    }
    class LangCSharp : OOLanguage
    {
       
        public override string GetName()
        {
            return "C#";
        }
    }

    class LangJava : OOLanguage
    {
        
        public override string GetName()
        {
            return "Java";
        }
    }

    abstract class ProcLanguage :ILanguage
    {
        abstract public string GetName();
        public string GetParadigm()
        {
            return "Procedural";
        }
        public string GetUnit()
        {
            return "Function";
        }
    }

    class LangC : ProcLanguage
    {
        
        public override string GetName()
        {
            return "C";
        }
    }

    class LangVBNet : OOLanguage
    {
        public override string GetName()
        {
            return "VB.Net";
        }
    }
}
