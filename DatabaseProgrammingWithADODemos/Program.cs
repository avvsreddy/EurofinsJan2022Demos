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

           

            IContactsRepository repo = new ContactsRepository();
            int count = repo.GetContactsCount();
            Console.WriteLine(count);
           

          

        }
    }
}
