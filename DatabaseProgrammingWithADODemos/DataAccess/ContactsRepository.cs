using DatabaseProgrammingWithADODemos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

namespace DatabaseProgrammingWithADODemos.DataAccess
{
    public class ContactsRepository : IContactsRepository
    {
        public bool DeleteContact(int contactId)
        {
            SqlConnection conn = GetConnection();
            string sqlDelete = $"delete contacts where contactid = {contactId}";
            SqlCommand cmd = new SqlCommand(sqlDelete, conn);
            int c = 0;
            using (conn)
            {
                conn.Open();
                c = cmd.ExecuteNonQuery();
                //conn.Close();
            }
            return c > 0;
        }

        public Contact GetContactById(int contactId)
        {
            SqlConnection conn = GetConnection();
            string selectSql = $"select * from contacts where contactid = {contactId}";
            SqlCommand cmd = new SqlCommand(selectSql, conn);
            Contact c = new Contact();
            using (conn)
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                
                c.ContactID = (int)reader[0];
                c.Name = reader[1].ToString();
                c.Mobile = reader.GetString(2);
                c.Email = reader["email"].ToString();
                c.Location = reader.GetString(4);
                reader.Close();
            }
            return c;
        }

        public List<Contact> GetContacts()
        {
            SqlConnection conn = GetConnection();
            string selectSql = $"select * from contacts";
            SqlCommand cmd = new SqlCommand(selectSql, conn);
           
            List<Contact> contacts = new List<Contact>();
            using (conn)
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Contact c = new Contact();
                    c.ContactID = (int)reader[0];
                    c.Name = reader[1].ToString();
                    c.Mobile = reader.GetString(2);
                    c.Email = reader["email"].ToString();
                    c.Location = reader.GetString(4);
                    contacts.Add(c);
                }
                reader.Close();
            }
            return contacts;
        }

        public List<Contact> GetContactsByLocation(string location)
        {
            SqlConnection conn = GetConnection();
            string selectSql = $"select * from contacts where location = {location}";
            SqlCommand cmd = new SqlCommand(selectSql, conn);

            List<Contact> contacts = new List<Contact>();
            using (conn)
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Contact c = new Contact();
                    c.ContactID = (int)reader[0];
                    c.Name = reader[1].ToString();
                    c.Mobile = reader.GetString(2);
                    c.Email = reader["email"].ToString();
                    c.Location = reader.GetString(4);
                    contacts.Add(c);
                }
                reader.Close();
            }
            return contacts;
        }

        public bool SaveContact(Contact contact)
        {
            SqlConnection sqlConnection = GetConnection();
            string sqlInsert = $"insert into contacts values('{contact.Name}','{contact.Mobile}','{contact.Email}','{contact.Location}')";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sqlInsert;
            cmd.Connection = sqlConnection;
            int count = 0;
            try
            {
                sqlConnection.Open();
                count = cmd.ExecuteNonQuery();
            }
            finally
            {
                sqlConnection.Close();
            }
            return count > 0;
        }

       

        public bool UpdateContact(Contact contact)
        {
            SqlConnection conn = GetConnection();
            string updateSql = $"update contacts set name = {contact.Name}, mobile = {contact.Mobile}, email={contact.Email}, location ={contact.Location} where contactid={contact.ContactID}";
            SqlCommand cmd = new SqlCommand(updateSql, conn);
            int count = 0;
            using (conn)
            {
                conn.Open();
                count = cmd.ExecuteNonQuery();
            }
            return count > 0;
        }



        private static SqlConnection GetConnection()
        {
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=Contacts2022DB;Integrated Security=True";
            return sqlConnection;
        }
    }
}
