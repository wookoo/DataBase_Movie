using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBase_Movie
{
    public partial class FormPayment : Form
    {
        String email, id;
        ArrayList array;
        OleDbConnection conn;
        string connectionString = "Provider=OraOLEDB.Oracle;Password=dohyun;User ID=dohyun"; //oracle 서버 연결
        String movieID = "";
        int price = 0;

        public FormPayment(String email, String id,  ArrayList array)
        {
            this.email = email;
            this.id = id;
            this.array = array;
            InitializeComponent();


            conn = new OleDbConnection(connectionString);
            conn.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = $"select 등급,카드번호 from 회원 where 아이디='{email}'";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;
            OleDbDataReader read = cmd.ExecuteReader();
            Console.WriteLine(email);
            Console.WriteLine(cmd.CommandText);


            payment.Items.Add("현금");
            if (read.Read())
            {
                String data = (String)read.GetValue(0).ToString();
                Console.WriteLine(data);
                prideBox.Text = data;
                payment.Items.Add((String)read.GetValue(1).ToString());

                
            }
            conn.Close();
            conn.Open();
            cmd.CommandText = $"select 영화번호,상영시작시간,상영종료시간,상영관번호,요금 from 상영스케줄 where 상영번호='{id}'";
            read = cmd.ExecuteReader();
            //String movieID = "";
     
           
 
            if (read.Read())
            {
                movieID = read.GetValue(0).ToString();
                start.Text = read.GetValue(1).ToString();
                end.Text = read.GetValue(2).ToString();
                hall.Text = read.GetValue(3).ToString();
                price = Int32.Parse(read.GetValue(4).ToString());
                
            }

            conn.Close();
            conn.Open();
            cmd.CommandText = $"select 할인율 from 할인율 where 등급='{prideBox.Text}'";
            read = cmd.ExecuteReader();
            if (read.Read())
            {
                discount.Text = read.GetValue(0).ToString();
            }


            conn.Close();
            conn.Open();
            cmd.CommandText = $"select 상영관형태 from 상영관 where 상영관번호='{hall.Text}'";
            read = cmd.ExecuteReader();
            if (read.Read())
            {
                type.Text = read.GetValue(0).ToString();
            }
            price = price * array.Count;
            beforeDiscount.Text = price + "원";
            discountPrice.Text = ((100 - Int32.Parse(discount.Text)) * price) / 100+ "원";

            people.Text = array.Count + "명";
            seats.Text = "";
            for(int i = 0; i < array.Count; i++)
            {
                seats.Text += array[i].ToString() + " ";
            }
            //1관 반환


            conn.Close();
            conn.Open();
            cmd.CommandText = $"select 영화제목 from 영화 where 영화번호='{movieID}'";
            read = cmd.ExecuteReader();
            if (read.Read())
            {
                title.Text = read.GetValue(0).ToString();
            }
            payment.SelectedIndex = 0;




        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("해당 정보로 예매를 진행 할까요?","예매 확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
         

                string st = DateTime.Now.ToString("yyyy-MM-dd-HH-mm");


                string now = $"TO_DATE('{st}', 'yyyy-MM-dd-HH24-mi')";

                Console.WriteLine(array[0].ToString());

                

                string sta = DateTime.Parse(start.Text).ToString("yyyy-MM-dd-HH-mm");
                string en = DateTime.Parse(end.Text).ToString("yyyy-MM-dd-HH-mm");
                string startTime = $"TO_DATE('{sta}', 'yyyy-MM-dd-HH24-mi')";
                string endTime = $"TO_DATE('{en}', 'yyyy-MM-dd-HH24-mi')";

      
                int price = Int32.Parse(discountPrice.Text.Replace("원", ""));
                price = price / array.Count;
               

               

                conn = new OleDbConnection(connectionString);
                conn.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = $"SELECT reservation_seq.NEXTVAL FROM DUAL";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                OleDbDataReader read = cmd.ExecuteReader();
                String sequence = "";
                if (read.Read())
                {
                    sequence = read.GetValue(0).ToString();
                }
                conn.Close();
                for(int i = 0; i < array.Count; i++)
                {
                    conn.Open();
                    String r = array[i].ToString()[0].ToString();
                    String c = array[i].ToString();
                    c = c.Replace("A", "");
                    c = c.Replace("B", "");
                    c = c.Replace("C", "");
                    String query = $"insert into 예매좌석 values ( '{sequence}', '{id}','{movieID}',{startTime},{endTime},'{hall.Text}','{r}','{c}','{email}',{now},'{price}','{payment.Text}')";
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                MessageBox.Show("정상적으로 예매 되었습니다!", "예매 종료");
                Close();
                



            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
