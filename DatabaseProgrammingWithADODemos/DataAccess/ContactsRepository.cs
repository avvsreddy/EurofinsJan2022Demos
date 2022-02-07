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
        public bool SaveContact(Contact contact)
        {
            // write ado.net DAL code to save contact info

            // Step 1: Approach - Connected
            // Step 2: Connect to DB Server
            SqlConnection sqlConnection = new SqlConnection();
            // configure the conn object
            // location of db;database name;userid;password;
            sqlConnection.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=Contacts2022DB;Integrated Security=True";
            sqlConnection.Open();


            // Step 3: Prepare SQL Insert statement and send to DB Server
            string sqlInsert = $"insert into contacts values('{contact.Name}','{contact.Mobile}','{contact.Email}','{contact.Location}')";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sqlInsert;
            cmd.Connection = sqlConnection;
            int count = cmd.ExecuteNonQuery();
            // Step 4: Close the DB Connection
            sqlConnection.Close();
            return count > 0;
        }
    }
}
