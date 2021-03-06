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
using System.Threading;

namespace DataBase_Movie
{
    public partial class FormUserMain : Form
    {
        String email;
  
        public FormUserMain(String email, String name)
        {
            this.email = email;
            InitializeComponent();

            label1.Text = $"{name} 님 안녕하세요."; 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormUserReservation f = new FormUserReservation(email);
            Thread.Sleep(1000);
            f.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormUserProfile f = new FormUserProfile(email);

            f.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormReservationHistory f = new FormReservationHistory(email);
            f.ShowDialog();
        }
    }
}
