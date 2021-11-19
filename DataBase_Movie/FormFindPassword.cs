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
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace DataBase_Movie
{
    public partial class FormFindPassword : Form
    {
        int process = 0;
        String code = "";
        OleDbConnection conn;
        string connectionString = "Provider=MSDAORA;Password=dohyun;User ID=dohyun"; //oracle 서버 연결
        public FormFindPassword()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void resetBtn_Click(object sender, EventArgs e)
        {

        }
        private void send_auth_btn_Click(object sender, EventArgs e)
        {
            String email = eMailBox.Text.Trim();
            bool valid = Regex.IsMatch(email, @"[a-zA-Z0-9!#$%&'*+/s=?^_`{|}~-]+(?:\.[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?\.)+[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?");

            if (!valid)
            {
                MessageBox.Show("올바른 이메일을 입력해주세요!","이메일 오류");
            }
            conn = new OleDbConnection(connectionString);
            conn.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "select * from 회원 where 아이디 = '" + email + "'";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;

            OleDbDataReader read = cmd.ExecuteReader();
            if (!read.Read())
            {
                MessageBox.Show("가입 정보가 없습니다!", "비밀번호 재설정불가");
                if(conn != null)
                {
                    conn.Close();
                }
                return;
            }



        }
    }
}
