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
using System.Text.RegularExpressions;

namespace DataBase_Movie
{
    public partial class FormFindAccount : Form
    {

        OleDbConnection conn;
        string connectionString = "Provider=MSDAORA;Password=dohyun;User ID=dohyun"; //oracle 서버 연결
        public FormFindAccount()
        {
            InitializeComponent();
            this.phoneDrop.SelectedIndex = 0;
            this.phoneMiddleBox.KeyPress += this.only_digit_Event;
            this.phoneLastBox.KeyPress += this.only_digit_Event;
            
        }

        private void only_digit_Event(object sender, KeyPressEventArgs e)
        {
            // 숫자와 백스페이스만 입력가능
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }


        private void findAccountBtn_Click(Object sender, EventArgs e)
        {
            String regName = @"^[가-힣]{2,4}";
            String name = nameBox.Text.Trim();

            bool valid = Regex.IsMatch(name, regName);
            if (!valid)
            {
                MessageBox.Show("정확한 이름을 입력해주세요", "계정찾기 실패");
                return;
            }

            String regExpPhone = @"\d{2,3}-\d{3,4}-\d{4}";
            String phone = phoneDrop.Text.Trim() + "-" + phoneMiddleBox.Text.Trim() + "-" + phoneLastBox.Text.Trim();
            valid = Regex.IsMatch(phone, regExpPhone);
            if (!valid)
            {
                MessageBox.Show("올바른 전화번호를 입력해주세요", "계정찾기 실패");
                return;
            }
            //


            conn = new OleDbConnection(connectionString);
            conn.Open(); //데이터베이스 연결

            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = $"select 아이디 from 회원 where 이름='{name}' and 전화번호='{phone}'";
            cmd.CommandType = CommandType.Text; //검색명령을 쿼리 형태로
            cmd.Connection = conn;

            OleDbDataReader read = cmd.ExecuteReader(); //select 회원ID from 회원 결과


            if (!(read.Read()))
            {
                MessageBox.Show("가입된 정보가 없습니다", "계정찾기 실패");
                if(conn != null)
                {
                    conn.Close();
                }
                return;
                
            }
            String email = (String)read.GetValue(0);
        
            conn.Close();
            MessageBox.Show($"가입된 계정은 {email} 입니다.","계정찾기 성공");





        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("정말로 계정찾기를 취소할까요?", "계정찾기 취소", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Close();
            }
        }
    }
}
