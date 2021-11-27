using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace DataBase_Movie
{
    public partial class FormUserMain : Form
    {
        String email;
  
        public FormUserMain(String email)
        {
            this.email = email;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormUserReservation f = new FormUserReservation();
            f.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormUserProfile f = new FormUserProfile(email);

            f.ShowDialog();
        }
    }
}
