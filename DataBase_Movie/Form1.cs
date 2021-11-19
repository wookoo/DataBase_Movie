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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }



        private void loginBTN_Click(object sender, EventArgs e)
        {
            String id = idTextBox.Text;
            String passwd = passwordTextBox.Text;
            id = id.Trim();


            Console.WriteLine("로그인 버튼 눌림" + id + "djawnstlr");
        }
        private void registerBTN_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Register Button Pressed");
            FormRegister f = new FormRegister();
            f.ShowDialog();
        }
        private void changeBTN_Click(object sender, EventArgs e)
        {
            Console.WriteLine("change button pressed");
        }

        private void findPassBTN_Click(object sender, EventArgs e)
        {
            FormFindPassword f = new FormFindPassword();
            f.ShowDialog();


        }

        private void findAccountBTN_Click(object sender, EventArgs e)
        {
            FormFindAccount f = new FormFindAccount();
            f.ShowDialog();
        }

        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}
