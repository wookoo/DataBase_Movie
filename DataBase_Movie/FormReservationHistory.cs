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
    public partial class FormReservationHistory : Form
    {
        string email;

        OleDbConnection conn;
        string connectionString = "Provider=OraOLEDB.Oracle;Password=dohyun;User ID=dohyun"; //oracle 서버 연결
        // BLOB 를 다루기 위해서는 반드시 Provider=OraOLEDB.Oracle 

        Image image = null;
        Image thumnail_img = null;

        bool show_all = false;

        public FormReservationHistory(string email)
        {
            this.email = email;
            InitializeComponent();
            GridViewRefresh();
        }

        private void GridViewRefresh()
        {

            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            conn = new OleDbConnection(connectionString);
            conn.Open();
            OleDbCommand cmd = new OleDbCommand();

            string st = DateTime.Now.ToString("yyyy-MM-dd-HH-mm");


            string start = $"TO_DATE('{st}', 'yyyy-MM-dd-HH24-mi')";

            String query = $"select r.예매번호, m.영화제목,r.예매일시,r.인원,r.금액 from 영화 m, (select 예매번호,영화번호, count(예매번호) as 인원, sum(금액) as 금액,예매일시 from 예매좌석 where 아이디 = '{email}' and 시작시간 >{start} group by 예매번호,영화번호,예매일시)" +
                                $" r where r.영화번호 = m.영화번호 ";
            if (show_all)
            {
                query = $"select r.예매번호, m.영화제목,r.예매일시,r.인원,r.금액 from 영화 m, (select 예매번호,영화번호, count(예매번호) as 인원, sum(금액) as 금액,예매일시 from 예매좌석 where 아이디 = '{email}'  group by 예매번호,영화번호,예매일시)" +
                                $" r where r.영화번호 = m.영화번호 ";
            }
            
            
            Console.WriteLine(query);
            cmd.CommandText = query;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;
            OleDbDataReader read = cmd.ExecuteReader();
            int count = read.FieldCount;
            dataGridView1.ColumnCount = count;
            for (int i = 0; i < count; i++)
            {
                dataGridView1.Columns[i].Name = read.GetName(i);
            }
            while (read.Read())
            {

                object[] obj = new object[count]; // 필드수만큼 오브젝트 배열
                for (int i = 0; i < count; i++) // 필드 수만큼 반복
                {

                    obj[i] = new object();
                    obj[i] = read.GetValue(i);
                }


                dataGridView1.Rows.Add(obj); //데이터그리드뷰에 오브젝트 배열 추가
            }
            try
            {
                reservationID.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();
                title.Text = dataGridView1.Rows[0].Cells[1].Value.ToString();
                price.Text = dataGridView1.Rows[0].Cells[4].Value.ToString();
                people.Text = dataGridView1.Rows[0].Cells[3].Value.ToString();

                conn.Close();
                conn.Open();
                query = $"select * from 예매좌석 where 예매번호='{reservationID.Text}'";
                cmd.CommandText = query;
                read = cmd.ExecuteReader();
                String MovieID = "";
                String sea = "";
                while (read.Read())
                {
                    MovieID = read.GetValue(2).ToString();
                    this.start.Text = read.GetValue(3).ToString();
                    this.end.Text = read.GetValue(4).ToString();
                    this.hall.Text = read.GetValue(5).ToString();
                    sea += read.GetValue(6).ToString() + read.GetValue(7).ToString() + " ";
                    payment.Text = read.GetValue(11).ToString();
                }
                seats.Text = sea;

                conn.Close();
                conn.Open();
                cmd.CommandText = $"select 상영관형태 from 상영관 where 상영관번호 ='{this.hall.Text}' ";
                read = cmd.ExecuteReader();
                if (read.Read())
                {
                    this.type.Text = read.GetValue(0).ToString();
                }
                conn.Close();

                conn.Open(); //데이터베이스 연결
                cmd = new OleDbCommand();
                cmd.CommandText = $"select * from 영화 where 영화번호 = '{MovieID}' ";
                Console.WriteLine(cmd.CommandText);
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;

                read = cmd.ExecuteReader(); //select  결과

                if (read.Read())
                {



                    if (read.GetValue(4).ToString() != "")  //이미지가 없으면
                    {
                        image = ByteArrayToImage((byte[])read.GetValue(4));
                        Image.GetThumbnailImageAbort callback = new Image.GetThumbnailImageAbort(ThumbnailCallback);
                        thumnail_img = image.GetThumbnailImage(400, 400, callback, new IntPtr()); //썸네일 만들기
                        pictureBox1.Image = thumnail_img;
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    else
                    {
                        pictureBox1.Image = null;
                    }
                }
                DateTime now = DateTime.Now;
                DateTime startTime = DateTime.Parse(this.start.Text);
                if (now < startTime)
                {
                    button2.Enabled = true;
                }
                else
                {
                    button2.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                reservationID.Text = "";
                title.Text = "";
                price.Text = "";
                people.Text = "";
                hall.Text = "";
                type.Text = "";
                this.start.Text = "";
                this.end.Text = "";
                seats.Text = "";
                payment.Text = "";
                pictureBox1.Image = null;
                button2.Enabled = false;
            }

            











        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex == -1)
            {
                return;
            }
            int row = e.RowIndex;

            reservationID.Text = dataGridView1.Rows[row].Cells[0].Value.ToString();
            title.Text = dataGridView1.Rows[row].Cells[1].Value.ToString();
            price.Text = dataGridView1.Rows[row].Cells[4].Value.ToString();
            people.Text = dataGridView1.Rows[row].Cells[3].Value.ToString();

            conn = new OleDbConnection(connectionString);
            
            String query = $"select * from 예매좌석 where 예매번호='{reservationID.Text}'";
            OleDbCommand cmd = new OleDbCommand();

            cmd.CommandText = query;
            cmd.Connection = conn;
            conn.Open();
            OleDbDataReader read = cmd.ExecuteReader();

          
            String MovieID = "";
            String sea = "";
            while (read.Read())
            {
                MovieID = read.GetValue(2).ToString();
                this.start.Text = read.GetValue(3).ToString();
                this.end.Text = read.GetValue(4).ToString();
                this.hall.Text = read.GetValue(5).ToString();
                sea += read.GetValue(6).ToString() + read.GetValue(7).ToString() + " ";
                payment.Text = read.GetValue(11).ToString();
            }
            seats.Text = sea;

            conn.Close();
            conn.Open();
            cmd.CommandText = $"select 상영관형태 from 상영관 where 상영관번호 ='{this.hall.Text}' ";
            read = cmd.ExecuteReader();
            if (read.Read())
            {
                this.type.Text = read.GetValue(0).ToString();
            }
            conn.Close();

            conn.Open(); //데이터베이스 연결
            cmd = new OleDbCommand();
            cmd.CommandText = $"select * from 영화 where 영화번호 = '{MovieID}' ";
            Console.WriteLine(cmd.CommandText);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;

            read = cmd.ExecuteReader(); //select  결과

            if (read.Read())
            {



                if (read.GetValue(4).ToString() != "")  //이미지가 없으면
                {
                    image = ByteArrayToImage((byte[])read.GetValue(4));
                    Image.GetThumbnailImageAbort callback = new Image.GetThumbnailImageAbort(ThumbnailCallback);
                    thumnail_img = image.GetThumbnailImage(400, 400, callback, new IntPtr()); //썸네일 만들기
                    pictureBox1.Image = thumnail_img;
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else
                {
                    pictureBox1.Image = null;
                }
            }

            DateTime now = DateTime.Now;
            DateTime startTime = DateTime.Parse(this.start.Text);
            if(now < startTime)
            {
                button2.Enabled = true;
            }
            else
            {
                button2.Enabled = false;
            }



        }

        private Image ByteArrayToImage(byte[] bytes)
        {
            ImageConverter imageConverter = new ImageConverter();
            Image img = (Image)imageConverter.ConvertFrom(bytes);
            return img;
        }
        public bool ThumbnailCallback()
        {
            return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("정말로 예매를 취소할까요?", "예매 취소 확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                conn = new OleDbConnection(connectionString);

                String query = $"delete from 예매좌석 where 예매번호='{reservationID.Text}'";
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = conn;
                cmd.CommandText = query;
                conn.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine(reservationID.Text);
                GridViewRefresh();
                MessageBox.Show("예매 취소 되었습니다");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.show_all)
            {
                button1.Text = "전체 보기";
            }
            else
            {
                button1.Text = "취소 가능 보기";
            }
            GridViewRefresh();

            this.show_all = !this.show_all;
        }
    }
}
