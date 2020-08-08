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
    public partial class UpdatetheStaff : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\StaffDatabase.mdf;Integrated Security=True;Connect Timeout=30");
        public UpdatetheStaff()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Form1 objHome = new Form1();
            objHome.Show();
            this.Hide();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string Fname, LName, EMail, GEnder, joindate, time;
            string Sage, mobile,id;

           
            Fname = txtSFirstnameUp.Text;
            LName = txtSLastnameUp.Text;
            GEnder = "";
            bool isChecked = radioButtonUpdateMale.Checked;
            if (isChecked)
            {
                GEnder = radioButtonUpdateMale.Text;
            }
            else
            {
                GEnder = radioButtonUpdateFemale.Text;
            }

            joindate = dateTimePickerUpdate.Text;
            EMail = txtSEmailUp.Text;
            Sage =txtSAgeUp.Text;
            id = txtSIDUp.Text;

            mobile = txtSContactUp.Text;
            time = comboBoxUpdate.Text;

            

            String upd = "Update Staff SET FirstName='"+Fname+"',LastName='"+LName+"',JoinedDate='"+joindate+"',Age='"+Sage+"',WorkingTime='"+time+"',Email='"+EMail+"',ContactNo='"+mobile+"',Gender='"+GEnder+"' where StaffID='"+id+"'";
            SqlCommand cmd = new SqlCommand(upd, con);
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
            txtSIDUp.Text = "";
            txtSFirstnameUp.Text = "";
            txtSLastnameUp.Text = "";
            dateTimePickerUpdate.Text = "";
            txtSAgeUp.Text = "";
            comboBoxUpdate.Text = "";
            txtSEmailUp.Text = "";
            txtSContactUp.Text = "";
            radioButtonUpdateMale.Checked = false;
            radioButtonUpdateFemale.Checked = false;

            for (int i = 0; i < CheckedListBoxUpdate.Items.Count; i++)
            {
                CheckedListBoxUpdate.SetItemChecked(i, false);
            }

        }

        private void txtSIDUp_TextChanged(object sender, EventArgs e)
        {
            con.Open();

            if (txtSIDUp.Text != "")
            {
                
                SqlCommand cmd = new SqlCommand("Select FirstName,LastName,JoinedDate,Age,WorkingTime,Email,ContactNo,Gender,WorkingDays from Staff where StaffID=@StaffID", con);
                cmd.Parameters.AddWithValue("@StaffID", int.Parse(txtSIDUp.Text));
                SqlDataReader da = cmd.ExecuteReader();
                while (da.Read())
                {
                    txtSFirstnameUp.Text = da.GetValue(0).ToString();
                    txtSLastnameUp.Text = da.GetValue(1).ToString();
                    dateTimePickerUpdate.Text = da.GetValue(2).ToString();
                    txtSAgeUp.Text = da.GetValue(3).ToString();
                    comboBoxUpdate.Text = da.GetValue(4).ToString();
                    txtSEmailUp.Text = da.GetValue(5).ToString();
                    txtSContactUp.Text = da.GetValue(6).ToString();
                   
                }
                
            }
            con.Close();


        }

        private void btnClearUP_Click(object sender, EventArgs e)
        {
            txtSFirstnameUp.Clear();
            txtSLastnameUp.Clear();
            dateTimePickerUpdate.ResetText();
            txtSAgeUp.Clear();
            txtSContactUp.Clear();
            txtSEmailUp.Clear();
            comboBoxUpdate.SelectedIndex = -1;
            radioButtonUpdateMale.Checked = false;
            radioButtonUpdateFemale.Checked = false;

            for (int i = 0; i < CheckedListBoxUpdate.Items.Count; i++)
            {
                CheckedListBoxUpdate.SetItemChecked(i, false);
            }

        }
    }
    }


