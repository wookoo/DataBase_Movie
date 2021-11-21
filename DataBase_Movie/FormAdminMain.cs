using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBase_Movie
{
    public partial class FormAdminMain : Form
    {
        public FormAdminMain()
        {
            InitializeComponent();
        }

        private void editAccount_Click(object sender, EventArgs e)
        {
            FormAdminManageAccount f = new FormAdminManageAccount();
            f.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormAdminEditGrade f = new FormAdminEditGrade();
            f.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormAdminManageMovie f = new FormAdminManageMovie();
            f.ShowDialog();
        }
    }
}
