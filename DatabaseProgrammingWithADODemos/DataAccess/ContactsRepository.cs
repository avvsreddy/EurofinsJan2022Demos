using DatabaseProgrammingWithADODemos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//using System.Data.SqlClient;
using System.Configuration;
//using System.Data.OleDb;
using System.Data;
using System.Data.Common;

namespace DatabaseProgrammingWithADODemos.DataAccess
{
    public class ContactsRepository : IContactsRepository
    {
        public bool DeleteContact(int contactId)
        {
            IDbConnection conn = GetConnection();
            string sqlDelete = "delete contacts where contactid = @cid";
            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = sqlDelete;
            cmd.Connection = conn;

            IDbDataParameter p1 = cmd.CreateParameter();
            p1.ParameterName = "@cid";
            p1.Value = contactId;
            cmd.Parameters.Add(p1);

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
            
            //SqlConnection conn = GetConnection();
            //string selectSql = $"select * from contacts where contactid = {contactId}";
            //SqlCommand cmd = new SqlCommand(selectSql, conn);
            Contact c = new Contact();
            //using (conn)
            //{
            //    conn.Open();
            //    SqlDataReader reader = cmd.ExecuteReader();
            //    reader.Read();
                
            //    c.ContactID = (int)reader[0];
            //    c.Name = reader[1].ToString();
            //    c.Mobile = reader.GetString(2);
            //    c.Email = reader["email"].ToString();
            //    c.Location = reader.GetString(4);
            //    reader.Close();
            //}
            return c;
        }

        public List<Contact> GetContacts()
        {
            //SqlConnection conn = GetConnection();
            //string selectSql = $"select * from contacts";
            //SqlCommand cmd = new SqlCommand(selectSql, conn);
           
            List<Contact> contacts = new List<Contact>();
            //using (conn)
            //{
            //    conn.Open();
            //    SqlDataReader reader = cmd.ExecuteReader();
            //    while (reader.Read())
            //    {
            //        Contact c = new Contact();
            //        c.ContactID = (int)reader[0];
            //        c.Name = reader[1].ToString();
            //        c.Mobile = reader.GetString(2);
            //        c.Email = reader["email"].ToString();
            //        c.Location = reader.GetString(4);
            //        contacts.Add(c);
            //    }
            //    reader.Close();
            //}
            return contacts;
        }

        public List<Contact> GetContactsByLocation(string location)
        {
            //SqlConnection conn = GetConnection();

            ////location = "bangalore';delete contacts";

            //// string selectSql = $"select * from contacts where location = '{location}'";
            //string selectSql = "select * from contacts where location = @loc";
            ////string selectSql = $"select * from contacts where location = 'bangalore';delete contacts'"; // SQL Injection attack
            //SqlCommand cmd = new SqlCommand(selectSql, conn);
            ////cmd.Parameters.AddWithValue("@loc", location);

            //SqlParameter p1 = new SqlParameter();
            //p1.ParameterName = "@loc";
            //p1.Value = location;
            //cmd.Parameters.Add(p1);

            List<Contact> contacts = new List<Contact>();
            //using (conn)
            //{
            //    conn.Open();
            //    SqlDataReader reader = cmd.ExecuteReader();
            //    while (reader.Read())
            //    {
            //        Contact c = new Contact();
            //        c.ContactID = (int)reader[0];
            //        c.Name = reader[1].ToString();
            //        c.Mobile = reader.GetString(2);
            //        c.Email = reader["email"].ToString();
            //        c.Location = reader.GetString(4);
            //        contacts.Add(c);
            //    }
            //    reader.Close();
            //}
            return contacts;
        }

        public bool SaveContact(Contact contact)
        {
            //SqlConnection sqlConnection = GetConnection();
            //string sqlInsert = $"insert into contacts values('{contact.Name}','{contact.Mobile}','{contact.Email}','{contact.Location}')";
            //SqlCommand cmd = new SqlCommand();
            //cmd.CommandText = sqlInsert;
            //cmd.Connection = sqlConnection;
            int count = 0;
            //try
            //{
            //    sqlConnection.Open();
            //    count = cmd.ExecuteNonQuery();
            //}
            //finally
            //{
            //    sqlConnection.Close();
            //}
            return count > 0;
        }
        public bool UpdateContact(Contact contact)
        {
            //SqlConnection conn = GetConnection();
            //string updateSql = $"update contacts set name = {contact.Name}, mobile = {contact.Mobile}, email={contact.Email}, location ={contact.Location} where contactid={contact.ContactID}";
            //SqlCommand cmd = new SqlCommand(updateSql, conn);
            int count = 0;
            //using (conn)
            //{
            //    conn.Open();
            //    count = cmd.ExecuteNonQuery();
            //}
            return count > 0;
        }
        private static IDbConnection GetConnection()
        {
            string provider = ConfigurationManager.ConnectionStrings["default"].ProviderName;
            DbProviderFactory factory =  DbProviderFactories.GetFactory(provider);
            string connStr = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
            IDbConnection conn =  factory.CreateConnection();
            conn.ConnectionString = connStr;
            return conn;
        }

        public int GetContactsCount()
        {
            IDbConnection conn = GetConnection();
            string sqlCount = "select count(*) from contacts";
            IDbCommand cmd = conn.CreateCommand();
            int count = 0;
            using (conn) 
            {
                conn.Open();
                cmd.CommandText = sqlCount;
                cmd.Connection = conn;
                count = (int) cmd.ExecuteScalar();
            }
            return count;
           

        }

        public int GetContactsCountByLocation(string location)
        {
            IDbConnection conn = GetConnection();
            string sqlCount = "sp_get_contacts_countby_location";
            IDbCommand cmd = conn.CreateCommand();
            IDataParameter p = cmd.CreateParameter();
            p.ParameterName = "@loc";
            p.Value = location;
            cmd.Parameters.Add(p);
            
            int count = 0;
            using (conn)
            {
                conn.Open();
                cmd.CommandText = sqlCount;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;
                count = (int)cmd.ExecuteScalar();
            }
            return count;
        }

        public bool FundTransfer(int fromAccNo, int toAccNo, int amount)
        {
            IDbConnection conn = GetConnection();
            string update1 = $"update accounts set balance = balance - {amount} where accno = {fromAccNo}";
            string update2 = $"update accounts set balance = balance + {amount} where accno = {toAccNo}";
            
            IDbCommand cmd1 = conn.CreateCommand();
            cmd1.CommandText = update1;
            cmd1.Connection = conn;

            IDbCommand cmd2 = conn.CreateCommand();
            cmd2.CommandText = update2;
            cmd2.Connection = conn;
            int count = 0;
            IDbTransaction tx = null;
            try
            {
                conn.Open();
                tx = conn.BeginTransaction();
                cmd1.Transaction = tx;
                cmd2.Transaction = tx;

                count += cmd1.ExecuteNonQuery();
                // sdfsdsdf
                // asdfsdfsdf/
                //throw new Exception("Server error... try later");
                // sdfsdfsdf
                count += cmd2.ExecuteNonQuery();
                tx.Commit();
            }
            catch(Exception ex)
            {
                tx.Rollback();
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return count == 2;
        }
    }
}
