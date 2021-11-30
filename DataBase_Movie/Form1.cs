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
using System.Threading;

namespace DataBase_Movie
{
    public partial class Form1 : Form
    {
        OleDbConnection conn;
        string connectionString = "Provider=MSDAORA;Password=dohyun;User ID=dohyun"; //oracle 서버 연결

        public Form1()
        {
            InitializeComponent();

            passwordTextBox.PasswordChar = '*';
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }



        private void loginBTN_Click(object sender, EventArgs e)
        {
            

            /*
            Thread t = new Thread(new ThreadStart(() =>
            {

                


                
            }));

            t.Start();
            Close();*/



            String email = idTextBox.Text;
            String passwd = passwordTextBox.Text;

            email = email.Trim();


            Console.WriteLine("로그인 버튼 눌림" + email + "djawnstlr");

 
            bool valid = Regex.IsMatch(email, @"[a-zA-Z0-9!#$%&'*+/s=?^_`{|}~-]+(?:\.[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?\.)+[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?");
            if(email == "admin")
            {
                valid = true;
            }
            if (!valid)
            {
                MessageBox.Show("올바른 이메일이 아닙니다. 확인해주세요.", "로그인 실패");
                return;
            }

            SHA256 hash1 = new SHA256Managed();
            byte[] bytes1 = hash1.ComputeHash(Encoding.ASCII.GetBytes(passwd));

            // 16진수 형태로 문자열 결합
            StringBuilder sb1 = new StringBuilder();
            foreach (byte b1 in bytes1)
                sb1.AppendFormat("{0:x2}", b1);

            // 입력값의 해시결과
            String crypted_pw = sb1.ToString();
            Console.WriteLine(crypted_pw);
            //admin passwd 8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918

            String query = $"select 이름,등급 from 회원 where 아이디='{email}' and 비밀번호='{crypted_pw}'";

            conn = new OleDbConnection(connectionString);
            conn.Open();
            OleDbCommand cmd = new OleDbCommand();

            cmd.CommandText = query;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;

            OleDbDataReader read = cmd.ExecuteReader();

            if (!read.Read())
            {
                MessageBox.Show("가입 정보가 없습니다.", "로그인실패");
                if(conn != null)
                {
                    conn.Close();
                }
                return;
            }
            
            String name = read.GetString(0);
            String grade = read.GetString(1);
            conn.Close();
            Console.WriteLine(name + grade);
            MessageBox.Show($"{name}님 환영합니다.", "로그인성공");

            
            if (email == "admin")
            {
                //여기서 admin 작업 진행
                this.Hide();

                FormAdminMain f = new FormAdminMain();
                f.Closed += (s, args) => this.Close();
                f.ShowDialog();
                return;

            }
            else
            {

                this.Hide();

                
                FormUserMain f = new FormUserMain(email,name);
                f.Closed += (s, args) => this.Close();
                f.ShowDialog();
            }
            



            
            




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
