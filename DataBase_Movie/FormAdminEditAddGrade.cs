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
    public partial class FormAdminEditAddGrade : Form
    {
        String grade;
        String discount;
        bool isEdit;
        OleDbConnection conn;
        string connectionString = "Provider=MSDAORA;Password=dohyun;User ID=dohyun"; //oracle 서버 연결
        public FormAdminEditAddGrade(String grade, String discount)
        {
            this.grade = grade;
            this.discount = discount;
            this.isEdit = true;
            InitializeComponent();
            this.gradeBox.Text = grade;
            this.disCountBox.Text = discount;
            this.disCountBox.KeyPress += only_digit_Event;
        }
        public FormAdminEditAddGrade()
        {
            this.isEdit = false;
            InitializeComponent();
            this.disCountBox.KeyPress += only_digit_Event;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void only_digit_Event(object sender, KeyPressEventArgs e)
        {
            // 숫자와 백스페이스만 입력가능
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }


        private void saveBtn_Click(object sender, EventArgs e)
        {
            String grade = gradeBox.Text.Trim().ToUpper();
            gradeBox.Text = grade;

            bool valid = Regex.IsMatch(grade, @"^[A-Z]+$");
            if (!valid)
            {
                MessageBox.Show("등급은 영어만 가능합니다", "등급 에러");
                return;
            }

            String discount = disCountBox.Text.Trim();
            int result;
            try
            {
                result = Int32.Parse(discount);
                Console.WriteLine(discount);
            }
            catch (FormatException)
            {
                MessageBox.Show("할인율은 숫자만 가능합니다", "할인율 에러");
                return;
            }

            if( ! (result>=0 && result <= 100))
            {
                MessageBox.Show("할인율은 0~100 까지만 가능합니다.", "할인율 에러");
                return;
            }

            Console.WriteLine(grade);
            Console.WriteLine(discount);


            if (MessageBox.Show($"정말로 등급 : {grade} 할인율 : {discount} 를 저장 할까요?", "저장확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                conn = new OleDbConnection(connectionString);
                conn.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;


                if (isEdit)
                {
                    //SQL 에서 삽입, 회원갱신후 delete;


                    if (this.grade != grade)
                    {
                        //SQL 삽입 후 업데이트

                        try
                        {
                            String query = $"insert into 할인율 values ('{grade}','{discount}')";
                            cmd.CommandText = query;
                            cmd.ExecuteNonQuery();

                            query = $"update 회원 set 등급='{grade}' where 등급='{this.grade}'";
                            cmd.CommandText = query;
                            cmd.ExecuteNonQuery();

                            query = $"delete from 할인율 where 등급='{this.grade}'";
                            cmd.CommandText = query;
                            cmd.ExecuteNonQuery();


                            Console.WriteLine(query);
                            this.grade = grade;
                            MessageBox.Show("저장되었습니다", "저장 완료");
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("변경하려는 등급은 이미 존재합니다.", "변경 실패");
                        }


                    }
                    else
                    {
                        String query = $"update 할인율 set 할인율='{discount}' where 등급='{grade}'";
                        Console.WriteLine(query);
                        cmd.CommandText = query;
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("저장되었습니다", "저장 완료");
                    }
                }
                else
                {

                    try
                    {
                        String query = $"insert into 할인율 values ('{grade}','{discount}')";
                        cmd.CommandText = query;
                        cmd.ExecuteNonQuery();
                        this.grade = grade;
                        this.isEdit = true;
                        this.discount = discount;
                        MessageBox.Show("저장되었습니다", "저장 완료");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("저장하려는 등급은 이미 존재합니다.", "변경 실패");
                    }

                }
                conn.Close();
                this.Close();
            }


                
        }
    }
}
