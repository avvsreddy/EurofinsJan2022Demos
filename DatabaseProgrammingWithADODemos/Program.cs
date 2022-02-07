using DatabaseProgrammingWithADODemos.DataAccess;
using DatabaseProgrammingWithADODemos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProgrammingWithADODemos
{
    class Program
    {
        static void Main(string[] args)
        {
            // I want to manage (CRUD) my contacts information

            // Choose / Create Database - SQL Server / SSMS / VS.Net
            // Choose / Create Table - M


            // Want to Add new contact information

            Contact c = new Contact();
            Console.Write("Enter Contact Name: ");
            c.Name = Console.ReadLine();
            Console.Write("Enter Mobile Number: ");
            c.Mobile = Console.ReadLine();
            Console.Write("Enter Email: ");
            c.Email = Console.ReadLine();
            Console.Write("Enter Location: ");
            c.Location = Console.ReadLine();


            IContactsRepository repo = new ContactsRepository();
            repo.SaveContact(c);


            Console.WriteLine("Contact successffully saved");
            Console.ReadLine();

        }
    }
}
