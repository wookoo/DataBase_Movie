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
    public partial class FormUserProfile : Form
    {

        OleDbConnection conn;
        string connectionString = "Provider=MSDAORA;Password=dohyun;User ID=dohyun"; //oracle 서버 연결

        bool saveMode = false;

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


            String query = $"select 아이디,이름,전화번호,등급,카드번호 from 회원 where 아이디='{email}'";
            conn = new OleDbConnection(connectionString);
            conn.Open();
            OleDbCommand cmd = new OleDbCommand();

            cmd.CommandText = query;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;

            OleDbDataReader read = cmd.ExecuteReader();

            if (read.Read())
            {
                emailBox.Text = read.GetString(0).ToString();
                nameBox.Text = read.GetString(1).ToString();

                String phone = read.GetString(2).ToString();
                String[] p = phone.Split('-');
                phoneDrop.Text = p[0];
                phoneMiddleBox.Text = p[1];
                phoneLastBox.Text = p[2];
                pride.Text = read.GetString(3).ToString();
                String[] cards = read.GetString(4).ToString().Split('-');

                cardDrop.Text = cards[0];
                CardFirstBox.Text = cards[1];
                CardSecondBox.Text = cards[2];
                CardThirdBox.Text = cards[3];
                CardFourthBox.Text = cards[4];

                
                Console.WriteLine(phone);
            }

            cmd.CommandText = $"select 할인율 from 할인율 where 등급 = '{pride.Text}'";
            conn.Close();
            conn.Open();
            read = cmd.ExecuteReader();
            if (read.Read())
            {
                discount.Text = read.GetValue(0).ToString() + "%";
            }
         


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!saveMode)
            {
                button1.Text = "저장하기";
                nameBox.ReadOnly = false;
                phoneDrop.Enabled = true;
                phoneLastBox.ReadOnly = false;
                phoneMiddleBox.ReadOnly = false;
                cardDrop.Enabled = true;
                CardFirstBox.ReadOnly = false;
                CardSecondBox.ReadOnly = false;
                CardThirdBox.ReadOnly = false;
                CardFourthBox.ReadOnly = false;
                saveMode = !saveMode;

                return;
            }

            button1.Text = "수정하기";
            nameBox.ReadOnly = true;
            phoneDrop.Enabled = false;
            phoneLastBox.ReadOnly = true;
            phoneMiddleBox.ReadOnly = true;
            cardDrop.Enabled = false;
            CardFirstBox.ReadOnly = true;
            CardSecondBox.ReadOnly = true;
            CardThirdBox.ReadOnly = true;
            CardFourthBox.ReadOnly = true;
            saveMode = !saveMode;

            //여기서 저장할까 정해야됨
            if (MessageBox.Show("정말로 저장 할까요?", "저장하기", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                conn = new OleDbConnection(connectionString);
                conn.Open();
                OleDbCommand cmd = new OleDbCommand();
                String phone = phoneDrop.Text + "-" + phoneMiddleBox.Text + "-" + phoneLastBox.Text;
                String query = $"select * from 회원 where 이름='{nameBox.Text}' and 전화번호='{phone}' and not 아이디='{emailBox.Text}'";
                
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;

                OleDbDataReader read = cmd.ExecuteReader();

                if (read.Read())
                {
                  
                    MessageBox.Show("이미 해당 이름과 전화번호로 가입된 계정이 있습니다", "수정 실패");
                    
                    return;
                }
                conn.Close();
                conn.Open();
                

                Console.WriteLine(query);
                string card = cardDrop.Text + "-" + CardFirstBox.Text + "-" + CardSecondBox.Text + "-" + CardThirdBox.Text + "-" + CardFourthBox.Text;
                
                query = $"update 회원 set 이름='{nameBox.Text}',전화번호='{phone}',카드번호='{card}' where 아이디='{emailBox.Text}'";
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("정상적으로 수정되었습니다", "수정 성공");

            }





        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("정말로 회원 탈퇴를 할까요?", "회원탈퇴", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (MessageBox.Show("모든 정보가 삭제되며 복구 불가합니다. 탈퇴를 할까요?", "회원탈퇴", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    String query = $"delete from 회원 where 아이디='{email}'";
                    Console.WriteLine(query);
                    conn = new OleDbConnection(connectionString);
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    MessageBox.Show("회원 탈퇴 되었습니다", "탈퇴완료");
                    System.Windows.Forms.Application.Exit();


                }
                else
                {
                    
                }
            }
            else
            {
               
            }
        }
    }
}
