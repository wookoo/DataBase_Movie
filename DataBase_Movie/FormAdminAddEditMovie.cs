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
    public partial class FormAdminAddEditMovie : Form
    {
        OleDbConnection conn;
        string connectionString = "Provider=OraOLEDB.Oracle;Password=dohyun;User ID=dohyun"; //oracle 서버 연결
        Image thumnail_img = null;
        String id;
        bool isEdit;
        public FormAdminAddEditMovie()
        {
            InitializeComponent();
            this.isEdit = false;
        }
        public FormAdminAddEditMovie(String id)
        {
            this.isEdit = true;
            this.id = id;
            InitializeComponent();

            conn = new OleDbConnection(connectionString);
            try
            {
                conn.Open(); //데이터베이스 연결
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = "select * from 영화 where 영화번호 = '" + id + "'";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;

                OleDbDataReader read = cmd.ExecuteReader(); //select  결과

                if (read.Read())
                {
                    titleBox.Text = read.GetValue(1).ToString();
                    directorBox.Text = read.GetValue(2).ToString();
                    actorBox.Text = read.GetValue(3).ToString();
                    timeBox.Text = read.GetValue(5).ToString();

                    if (read.GetValue(4).ToString() != "")  //이미지가 없으면
                    {
                        Image image = ByteArrayToImage((byte[])read.GetValue(4));
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
        private Image ByteArrayToImage(byte[] bytes)
        {
            ImageConverter imageConverter = new ImageConverter();
            Image img = (Image)imageConverter.ConvertFrom(bytes);
            return img;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = @"C:\Users\user\Pictures";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string image_file = string.Empty;
                image_file = dialog.FileName;
            
                Image image = Bitmap.FromFile(image_file);
                Image.GetThumbnailImageAbort callback = new Image.GetThumbnailImageAbort(ThumbnailCallback);//썸네일 만들기
                thumnail_img = null;
                thumnail_img = image.GetThumbnailImage(400, 400, callback, new IntPtr()); //썸네일 만들기
                pictureBox1.Image = thumnail_img;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            }
            else return;

        }
        private bool ThumbnailCallback()
        {
            return true;
        }

        private byte[] imageToByteArray(Image img)
        {
            ImageConverter imageConverter = new ImageConverter();
            byte[] b = (byte[])imageConverter.ConvertTo(img, typeof(byte[]));
            return b;
        }


        private void saveBtn_Click(object sender, EventArgs e)
        {
            conn = new OleDbConnection(connectionString);
       
            conn.Open(); //데이터베이스 연결
            OleDbCommand cmd = new OleDbCommand();
            if (!isEdit)
            {
                if (thumnail_img == null)
                {
                    String query = $"insert into 영화 values (movie_seq.NEXTVAL,'{titleBox.Text.Trim()}'," +
                        $"'{directorBox.Text.Trim()}','{actorBox.Text.Trim()}',NULL,'{timeBox.Text.Trim()}')";
                    cmd.CommandText = query;
                    Console.WriteLine(query);


                }
                else
                {
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


                    /*
                        cmd.CommandText = "INSERT INTO product VALUES('" + txtCode.Text + "','" +
                            txtName.Text + "', " + txtPrice.Text + ", :image_var)";

                        byte[] bytes = imageToByteArray(image);
                        OleDbParameter para = new OleDbParameter();
                        para.OleDbType = OleDbType.LongVarBinary;
                        para.ParameterName = ":image_var";
                        para.Direction = ParameterDirection.Input;
                        para.SourceColumn = "product_image";
                        para.Size = bytes.Length;
                        para.Value = bytes;
                        cmd.Parameters.Add(para);*/
                }
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                cmd.ExecuteNonQuery(); //쿼리문을 실행하고 영향받는 행의 수를 반환.
                cmd.Parameters.Clear();
                conn.Close();
            }
            else
            {
                if (thumnail_img == null)
                {
                    String query = $"update 영화 set 영화제목= '{titleBox.Text.Trim()}'" +
                        $" , 영화감독='{directorBox.Text.Trim()}', 주연배우='{actorBox.Text.Trim()}',포스터=NULL , " +
                        $"상영시간='{timeBox.Text.Trim()}' where 영화번호='{id}'";
                    Console.WriteLine(query);
                    cmd.CommandText = query;

                }
                else
                {
                    String query = $"update 영화 set 영화제목= '{titleBox.Text.Trim()}'" +
                        $" , 영화감독='{directorBox.Text.Trim()}', 주연배우='{actorBox.Text.Trim()}',포스터=:image_var , " +
                        $"상영시간='{timeBox.Text.Trim()}' where 영화번호='{id}'";
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
                }
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                cmd.ExecuteNonQuery(); //쿼리문을 실행하고 영향받는 행의 수를 반환.
                cmd.Parameters.Clear();
                conn.Close();

            }
              
        }
    }
}
