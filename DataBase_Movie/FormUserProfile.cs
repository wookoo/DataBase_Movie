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
    public partial class FormUserProfile : Form
    {
        String email;
        public FormUserProfile(String email)
        {
            InitializeComponent();
            this.email = email;

            nameBox.ReadOnly = true;
            phoneDrop.Enabled = false;
            phoneLastBox.ReadOnly = true;
            phoneMiddleBox.ReadOnly = true;
            cardDrop.Enabled = false;
            CardFirstBox.ReadOnly = true;
            CardSecondBox.ReadOnly = true;
            CardThirdBox.ReadOnly = true;
            CardFourthBox.ReadOnly = true;


            String query = $"select 아이디,이름,전화번호,등급,카드번호 from 회원 where 아이디={email}";


        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
