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
using System.Collections;

namespace DataBase_Movie
{
    public partial class FormAdminAddEditSchedule : Form
    {
        OleDbConnection conn;
        string connectionString = "Provider=OraOLEDB.Oracle;Password=dohyun;User ID=dohyun"; //oracle 서버 연결
        // BLOB 를 다루기 위해서는 반드시 Provider=OraOLEDB.Oracle 
        Image image = null;
        Image thumnail_img = null;

        public FormAdminAddEditSchedule()
        {
            InitializeComponent();


            idBox.ForeColor = Color.Transparent;



            /*
            this.comboBox1.Items.AddRange(new object[] {
            "신한",
            "삼성",
            "국민",
            "현대",
            "우리",
            "농협",
            "우체국",
            "기업",
            "카카오"});*/


            conn = new OleDbConnection(connectionString);
            conn.Open();
            OleDbCommand cmd = new OleDbCommand();
            String query = "select 상영관번호 from 상영관";
            cmd.CommandText = query;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;
            OleDbDataReader read = cmd.ExecuteReader();
            ArrayList array = new ArrayList();

            while (read.Read())
            {

                array.Add(read.GetValue(0).ToString());

            }
            object[] obj = new object[array.Count];
            for(int i = 0; i < array.Count; i++)
            {
                obj[i] = array[i];
            }

            conn.Close();
            this.comboBox1.Items.AddRange(obj);
            this.comboBox1.SelectedIndex = 0;

            GridViewRefresh();


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

        private void GridViewRefresh()
        {
            priceBox.Text = "";
            titleBox.Text = "";
            directorBox.Text = "";
            actorBox.Text = "";
            timeBox.Text = "";
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            conn = new OleDbConnection(connectionString);
            conn.Open();
            OleDbCommand cmd = new OleDbCommand();
            String query = "select 영화번호,영화제목,상영시간 from 영화";
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

            thumnail_img = null;
            conn.Close();



            try
            {
                String id = (String)dataGridView1.Rows[0].Cells[0].Value;
                Console.WriteLine(id);
                idBox.Text = id;
                conn = new OleDbConnection(connectionString);
                conn.Open(); //데이터베이스 연결
                cmd.CommandText = "select * from 영화 where 영화번호 = '" + id + "'";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;

                read = cmd.ExecuteReader(); //select  결과

                if (read.Read())
                {
                    
                    titleBox.Text = read.GetValue(1).ToString();
                    directorBox.Text = read.GetValue(2).ToString();
                    actorBox.Text = read.GetValue(3).ToString();
                    timeBox.Text = read.GetValue(5).ToString() + "분";

                    DateTime d1 = this.dateTimePicker1.Value;
                    String text = this.timeBox.Text.Replace("분", "");
                    

                    int result = Int32.Parse(text);


                    //int result = Int32.Parse(this.timeBox.Text.ToString().Substring(0, this.timeBox.Text.LastIndexOf(this.timeBox.Text)));
                    DateTime d2 = d1.AddMinutes(result);
                    this.dateTimePicker2.Value = d2;


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

            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error: " + ex.Message); //에러 메세지 
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close(); //데이터베이스 연결 해제
                }
            }



        }


        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime d1 = this.dateTimePicker1.Value;
                String text = this.timeBox.Text.Replace("분", "");
        

                int result = Int32.Parse(text);


                //int result = Int32.Parse(this.timeBox.Text.ToString().Substring(0, this.timeBox.Text.LastIndexOf(this.timeBox.Text)));
                DateTime d2 = d1.AddMinutes(result);
                this.dateTimePicker2.Value = d2;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Console.WriteLine(e.RowIndex);

            String id = (String)dataGridView1.Rows[e.RowIndex].Cells[0].Value;
            Console.WriteLine(id);
            conn = new OleDbConnection(connectionString);
            try
            {
                conn.Open(); //데이터베이스 연결
                OleDbCommand cmd = new OleDbCommand();
                idBox.Text = id;
                cmd.CommandText = "select * from 영화 where 영화번호 = '" + id + "'";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;

                OleDbDataReader read = cmd.ExecuteReader(); //select  결과

                if (read.Read())
                {
                    titleBox.Text = read.GetValue(1).ToString();
                    directorBox.Text = read.GetValue(2).ToString();
                    actorBox.Text = read.GetValue(3).ToString();
                    timeBox.Text = read.GetValue(5).ToString() + "분";
                    DateTime d1 = this.dateTimePicker1.Value;
                    String text = this.timeBox.Text.Replace("분", "");
                    Console.WriteLine(text);

                    int result = Int32.Parse(text);


                    //int result = Int32.Parse(this.timeBox.Text.ToString().Substring(0, this.timeBox.Text.LastIndexOf(this.timeBox.Text)));
                    DateTime d2 = d1.AddMinutes(result);
                    this.dateTimePicker2.Value = d2;


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

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message); //에러 메세지 
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close(); //데이터베이스 연결 해제
                }
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {

            DateTime startTime = this.dateTimePicker1.Value;
            DateTime endTime = this.dateTimePicker2.Value;

            //if(startTime < DateTime.Now.AddMinutes(30))
            //{
             //   MessageBox.Show("영화시작 최소 30분 전에 등록해주세요");
              //  return;
            //}

            Random generator = new Random();
            String r = generator.Next(0, 999999).ToString("D6");

            string st = startTime.ToString("yyyy-MM-dd-HH-mm");
            string en = endTime.ToString("yyyy-MM-dd-HH-mm");

            string start = $"TO_DATE('{st}', 'yyyy-MM-dd-HH24-mi')";
            string end = $"TO_DATE('{en}', 'yyyy-MM-dd-HH24-mi')";

            string q = $"select TO_CHAR(상영시작시간,'YYYY/MM/DD/hh24/mi'),TO_CHAR(상영종료시간,'YYYY/MM-DD-hh24-mi') from 상영스케줄 where ( (상영시작시간 between {start} and {end}) or (상영종료시간 between {start} and {end}) ) and  상영관번호 = '{comboBox1.Text}'";
            Console.WriteLine(q);

            conn = new OleDbConnection(connectionString);
            conn.Open(); //데이터베이스 연결
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = q;


            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
       
            OleDbDataReader read = cmd.ExecuteReader();
            if (read.Read())
            {
                MessageBox.Show("해당 시간에 스케줄이 존재합니다.");
                conn.Close();
                return;
            }
            conn.Close();
            conn.Open();




            //여기에서 상영관 시간으로 조회


            

            string query = $"insert into 상영스케줄 values(schedule_seq.NEXTVAL, '{idBox.Text}'," +
                $"{ start},{ end},'{comboBox1.Text}','{priceBox.Text}')";
            Console.WriteLine(query);
        

        
            cmd.CommandText = query;
           

        
            Console.WriteLine(query);
            try
            {
                int price = Int32.Parse(priceBox.Text);

            }
            catch(Exception ex)
            {
                MessageBox.Show("요금은 숫자만 가능합니다");
                conn.Close();
                return;
            }

            cmd.ExecuteNonQuery();
            
            conn.Close();
            MessageBox.Show("해당시간에 정상적으로 스케쥴이 추가되었습니다");
            priceBox.Text = "";


            /*

            String query = $"insert into 영화 values (movie_seq.NEXTVAL,'{titleBox.Text.Trim()}'," +
                        $"'{directorBox.Text.Trim()}','{actorBox.Text.Trim()}',:image_var,'{timeBox.Text.Trim()}')";

            cmd.CommandText = query;
            byte[] bytes = imageToByteArray(thumnail_img);
            OleDbParameter para = new OleDbParameter();
            para.OleDbType = OleDbType.LongVarBinary;
            para.ParameterName = ":image_var";
            para.Direction = ParameterDirection.Input;
            para.SourceColumn = "포스터";
            para.Size = bytes.Length;
            para.Value = bytes;
            cmd.Parameters.Add(para);
            */

            //Console.WriteLine(query);
        }
    }
}
