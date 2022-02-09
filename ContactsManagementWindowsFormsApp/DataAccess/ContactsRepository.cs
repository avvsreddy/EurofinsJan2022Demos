using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsManagementWindowsFormsApp.DataAccess
{
    public class ContactsRepository
    {
        SqlDataAdapter da = null;
        public DataSet   GetAllContacts()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=Contacts2022DB;Integrated Security=True;Pooling=False";

            string sqlSelect = "select * from contacts";
            da = new SqlDataAdapter(sqlSelect,conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "contacts");
            return ds;
        }

        public void UpdateContacts(DataSet ds)
        {
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            da.Update(ds, "contacts");
        }
    }
}
