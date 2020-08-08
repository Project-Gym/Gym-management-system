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
    
    public partial class Add_Staff : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\StaffDatabase.mdf;Integrated Security=True;Connect Timeout=30");


        public Add_Staff()
        {
            InitializeComponent();
        }
        
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtSLastName_TextChanged(object sender, EventArgs e)
        {

        }

        private void Add_Staff_Load(object sender, EventArgs e)
        {
            Retrieved();
        }


        private void comboBoxAdd_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 objHome = new Form1();
            objHome.Show();
            this.Hide();
        }

        public void Retrieved()
        {
            try
            {
                string query = "Select StaffID from Staff";
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    int value=int.Parse(reader[0].ToString())+1;
                    txtSID.Text = value.ToString();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("" + ex);
            }
            finally
            {
                if(con.State==ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string FirstName, LastName, email,gender,Joindate,Gymtime;
            string age, ContactNo;

            

            FirstName = txtSFirstname.Text;
            LastName = txtSLastname.Text;
            gender = "";
            bool isChecked = radioButtonAddMale.Checked;
            if(isChecked)
            {
                gender = radioButtonAddMale.Text;
            }
            else
            {
                gender = radioButtonAddFemale.Text;
            }

            Joindate = dateTimePickerAdd.Text;
            email = txtSEmail.Text;
            age = txtSAge.Text;
            
            ContactNo = txtSContact.Text;
            Gymtime = comboBoxAdd.Text;
            
    


            
            String qry = "Insert into Staff(FirstName,LastName,JoinedDate,Age,WorkingTime,Email,ContactNo,Gender) Values('" + FirstName + "','" + LastName + "','" + Joindate + "','" + age + "','" + Gymtime + "','" + email + "','" + ContactNo + "','"+gender+"')";
            SqlCommand cmd = new SqlCommand(qry, con);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record inserted");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }

            finally
            {
                con.Close();
            }

            txtSFirstname.Text = "";
            txtSLastname.Text = "";
            dateTimePickerAdd.Text = "";
            txtSAge.Text = "";
            comboBoxAdd.Text = "";
            txtSEmail.Text = "";
            txtSContact.Text = "";
            radioButtonAddMale.Checked = false;
            radioButtonAddFemale.Checked = false;

            for (int i = 0; i < CheckedListBoxAdd.Items.Count; i++)
            {
                CheckedListBoxAdd.SetItemChecked(i, false);
            }

            try
            {
                string query = "Select StaffID from Staff";
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                SqlCommand cd = new SqlCommand(query, con);
                SqlDataReader reader = cd.ExecuteReader();
                while (reader.Read())
                {
                    int value = int.Parse(reader[0].ToString()) + 1;
                    txtSID.Text = value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }

            
        }


        private void btnClear_Click(object sender, EventArgs e)
        {

            txtSFirstname.Clear();
            txtSLastname.Clear();
            dateTimePickerAdd.ResetText();
            txtSAge.Clear();
            txtSContact.Clear();
            txtSEmail.Clear();
            comboBoxAdd.SelectedIndex = -1;
            radioButtonAddMale.Checked = false;
            radioButtonAddFemale.Checked = false;
           
            for(int i=0;i<CheckedListBoxAdd.Items.Count;i++)
            {
                CheckedListBoxAdd.SetItemChecked(i, false);
            }


        }

        private void txtSAge_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
