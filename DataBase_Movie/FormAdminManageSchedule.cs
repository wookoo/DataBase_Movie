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
    public partial class FormAdminManageSchedule : Form
    {
        public FormAdminManageSchedule()
        {
            InitializeComponent();

            ///schedule_seq
        }

        private void FormAdminManageSchedule_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormAdminAddEditSchedule f = new FormAdminAddEditSchedule();
            f.ShowDialog();
        }
    }
}
