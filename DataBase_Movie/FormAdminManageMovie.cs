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
    public partial class FormAdminManageMovie : Form
    {
        OleDbConnection conn;
        string connectionString = "Provider=OraOLEDB.Oracle;Password=dohyun;User ID=dohyun"; //oracle 서버 연결
        // BLOB 를 다루기 위해서는 반드시 Provider=OraOLEDB.Oracle 
        Image image = null;
        Image thumnail_img = null;

        public FormAdminManageMovie()
        {
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
            time.Text = "";
            title.Text = "";
            actor.Text = "";
            director.Text = "";
            pictureBox1.Image = null;
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
                    title.Text = read.GetValue(1).ToString();
                    director.Text = read.GetValue(2).ToString();
                    actor.Text = read.GetValue(3).ToString();
                    time.Text = read.GetValue(5).ToString() + "분";

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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            //movie_seq.nextVar;

            /*영화번호                                                          NOT NULL VARCHAR2(10)
 영화제목                                                          NOT NULL VARCHAR2(30)
 영화감독                                                          NOT NULL VARCHAR2(20)
 주연배우                                                          NOT NULL VARCHAR2(20)
 포스터                                                                     BLOB
 상영시간
            */
        }

        private void label7_Click(object sender, EventArgs e)
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
                cmd.CommandText = "select * from 영화 where 영화번호 = '" + id + "'";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;

                OleDbDataReader read = cmd.ExecuteReader(); //select  결과

                if (read.Read())
                {
                    title.Text = read.GetValue(1).ToString();
                    director.Text = read.GetValue(2).ToString();
                    actor.Text = read.GetValue(3).ToString();
                    time.Text = read.GetValue(5).ToString() + "분";

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

        private void button3_Click(object sender, EventArgs e)
        {

            int selectedCellCount =
        dataGridView1.GetCellCount(DataGridViewElementStates.Selected);
            if (selectedCellCount == 0)
            {
                MessageBox.Show("삭제할 대상을 선택해주세요", "삭제 불가");
                return;
            }
            if (selectedCellCount > 0)
            {

                int row = dataGridView1.SelectedCells[0].RowIndex;

                for (int i = 0; i < selectedCellCount; i++)
                {


                    if (row != dataGridView1.SelectedCells[i].RowIndex)
                    {
                        MessageBox.Show("한번에 한개만 삭제 가능합니다.", "삭제 불가");
                        return;
                    }


                }
                String id = dataGridView1.Rows[row].Cells[0].Value.ToString();
                String name = dataGridView1.Rows[row].Cells[1].Value.ToString();
                if (MessageBox.Show($"정말로 {name} 을 삭제 할까요?", "삭제확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    conn = new OleDbConnection(connectionString);
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand();
                    String query = $"delete  from 영화 where 영화번호='{id}'";
                    cmd.CommandText = query;
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = conn;
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show($"해당 데이터를 사용중이기 때문에 삭제 불가합니다.", "삭제 실패");
                        conn.Close();
                        return;
                    }
                    MessageBox.Show($"영화가 삭제되었습니다.", "삭제 성공");
                    conn.Close();





                    GridViewRefresh();
                }




            }


        }

        private void director_Click(object sender, EventArgs e)
        {

        }

        private void time_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormAdminAddEditMovie f = new FormAdminAddEditMovie();
            f.ShowDialog();
            GridViewRefresh();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int selectedCellCount =
       dataGridView1.GetCellCount(DataGridViewElementStates.Selected);
            if (selectedCellCount == 0)
            {
                MessageBox.Show("수정할 대상을 선택해주세요", "수정 불가");
                return;
            }
            if (selectedCellCount > 0)
            {

                int row = dataGridView1.SelectedCells[0].RowIndex;

                for (int i = 0; i < selectedCellCount; i++)
                {


                    if (row != dataGridView1.SelectedCells[i].RowIndex)
                    {
                        MessageBox.Show("한번에 한개만 수정 가능합니다.", "수정 불가");
                        return;
                    }


                }
                String id = dataGridView1.Rows[row].Cells[0].Value.ToString();
                String name = dataGridView1.Rows[row].Cells[1].Value.ToString();
                FormAdminAddEditMovie f = new FormAdminAddEditMovie(id);
                f.ShowDialog();
                GridViewRefresh();

            }            
        }
    }
}
