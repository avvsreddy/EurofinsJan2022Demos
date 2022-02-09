using ContactsManagementWindowsFormsApp.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactsManagementWindowsFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        DataSet ds = null;
        ContactsRepository repo = new ContactsRepository();
        private void Form1_Load(object sender, EventArgs e)
        {
            
            ds = repo.GetAllContacts();
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "contacts";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            repo.UpdateContacts(ds);
            MessageBox.Show("Contacts updated....");
        }
    }
}
