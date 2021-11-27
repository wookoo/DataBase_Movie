﻿using System;
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
    public partial class FormUserReservation : Form
    {
        Image thumnail_img = null;
        OleDbConnection conn;
        string connectionString = "Provider=OraOLEDB.Oracle;Password=dohyun;User ID=dohyun"; //oracle 서버 연결
        // BLOB 를 다루기 위해서는 반드시 Provider=OraOLEDB.Oracle 
        Image image = null;
  

        public FormUserReservation()
        {
            InitializeComponent();
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
           
            titleBox.Text = "";
            directorBox.Text = "";
            actorBox.Text = "";
            timeBox.Text = "";
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            conn = new OleDbConnection(connectionString);
            conn.Open();
            OleDbCommand cmd = new OleDbCommand();

           

            string st = DateTime.Now.ToString("yyyy-MM-dd-HH-mm");
           

            string start = $"TO_DATE('{st}', 'yyyy-MM-dd-HH24-mi')";


            String query = $"select 영화번호,영화제목 from 영화 where 영화번호 in (select 영화번호 from 상영스케줄 where 상영시작시간 > {start} group by 영화번호) order by 영화번호";
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

            thumnail_img = null;
            conn.Close();



            try
            {
                String id = (String)dataGridView1.Rows[0].Cells[0].Value;
                Console.WriteLine(id);
          
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

                    String text = this.timeBox.Text.Replace("분", "");


                    int result = Int32.Parse(text);


                    //int result = Int32.Parse(this.timeBox.Text.ToString().Substring(0, this.timeBox.Text.LastIndexOf(this.timeBox.Text)));
  


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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                String id = (String)dataGridView1.Rows[e.RowIndex].Cells[0].Value;
                Console.WriteLine(id);

                conn = new OleDbConnection(connectionString);
                conn.Open(); //데이터베이스 연결
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = "select * from 영화 where 영화번호 = '" + id + "'";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                OleDbDataReader read = cmd.ExecuteReader();
               

                if (read.Read())
                {

                    titleBox.Text = read.GetValue(1).ToString();
                    directorBox.Text = read.GetValue(2).ToString();
                    actorBox.Text = read.GetValue(3).ToString();
                    timeBox.Text = read.GetValue(5).ToString() + "분";

                    String text = this.timeBox.Text.Replace("분", "");


                    int result = Int32.Parse(text);


                    //int result = Int32.Parse(this.timeBox.Text.ToString().Substring(0, this.timeBox.Text.LastIndexOf(this.timeBox.Text)));



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
    }

    
}
