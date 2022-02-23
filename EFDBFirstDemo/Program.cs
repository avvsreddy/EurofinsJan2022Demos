using EFDBFirstDemo.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDBFirstDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }

        private static void Delete()
        {
            // Delete
            // create an instance of DBContext subclass
            ContactsModel db = new ContactsModel();
            // get the object to delete
            var contactToDelete = db.Contacts.Find(1);
            // remove the object from dbset
            db.Contacts.Remove(contactToDelete);
            // save changes back to db
            db.SaveChanges();
        }

        private static void Edit()
        {
            // Edit
            // create an instance of DBContext subclass
            ContactsModel db = new ContactsModel();
            // get the object to edit
            var contactToEdit = db.Contacts.Find(1);
            // modify the contact
            contactToEdit.Mobile = "999999999";
            // save changes back to db
            db.SaveChanges();
        }

        private static void Read()
        { 
            // Get all contacts
            // create an instance of DBContext
            ContactsModel db = new ContactsModel();

            // ESql/LinqToEntities/Native SQL
            // Linq to Entities

            var contacts = (from c in db.Contacts
                            select c).ToList();

            foreach (var item in contacts)
            {
                Console.WriteLine(item.Name);
            }
        }

        private static void Add()
        {
            // want to add new contact
            // write only OO code

            // create an instance of DBContext
            ContactsModel db = new ContactsModel();

            // create a new contact object
            Contact c = new Contact { Name = "Sachin", Email = "sachin@bcci.org", Mobile = "456456456", Location = "Mumbai" };
            // add contact object into contactsModel
            db.Contacts.Add(c);
            // save changes to database
            db.SaveChanges();
            Console.WriteLine("Contact saved...");
        }
    }
}
