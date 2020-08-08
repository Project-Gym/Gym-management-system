using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace New_Staff
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Add_Staff objAdd = new Add_Staff();
            objAdd.Show();
            this.Hide();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdatetheStaff objUp = new UpdatetheStaff();
            objUp.Show();
            this.Hide();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete_Staff objDelete = new Delete_Staff();
            objDelete.Show();
            this.Hide();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            View_Staff objView = new View_Staff();
            objView.Show();
            this.Hide();
        }
    }
}
