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
          
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=Contacts2022DB;Integrated Security=True";
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
    }
}
