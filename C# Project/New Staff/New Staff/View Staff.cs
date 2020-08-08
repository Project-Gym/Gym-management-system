using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace New_Staff
{
    public partial class View_Staff : Form
    {
        string constring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\StaffDatabase.mdf;Integrated Security=True;Connect Timeout=30";
       
       
        public View_Staff()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 objHOME = new Form1();
            objHOME.Show();
            this.Hide();
        }

        private void btnFetch_Click(object sender, EventArgs e)
        {
            
            string qry = "SELECT * from Staff";
            SqlDataAdapter da = new SqlDataAdapter(qry, constring);
            DataSet ds = new DataSet();
            da.Fill(ds, "Staff");
            dataGridView1.DataSource = ds.Tables["Staff"];
        }

        private void btnSSearch_Click(object sender, EventArgs e)
        {
            
           
            string go = "SELECT * FROM Staff where StaffID='" + int.Parse(TxtSIDView.Text) + "'";
            SqlDataAdapter da = new SqlDataAdapter(go, constring);
            DataSet ds = new DataSet();
            da.Fill(ds, "Staff");
            dataGridView1.DataSource = ds.Tables["Staff"];
        }
    }
}
