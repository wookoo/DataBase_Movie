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
    public partial class FormAdminManageSchedule : Form
    {

        OleDbConnection conn;
        string connectionString = "Provider=OraOLEDB.Oracle;Password=dohyun;User ID=dohyun"; //oracle 서버 연결
        // BLOB 를 다루기 위해서는 반드시 Provider=OraOLEDB.Oracle 

        Image image = null;
        Image thumnail_img = null;

        bool show_all = false;


        public FormAdminManageSchedule()
        {
            InitializeComponent();

            ///schedule_seq
            GridViewRefresh(show_all);
        }

        private void FormAdminManageSchedule_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormAdminAddEditSchedule f = new FormAdminAddEditSchedule();
            f.ShowDialog();
            GridViewRefresh(show_all);
        }

        private void GridViewRefresh(bool all)
        {
            startBox.Text = "";
            endBox.Text = "";
            hallBox.Text = "";
            priceBox.Text = "";

            titleBox.Text = "";
            directorBox.Text = "";
            actorBox.Text = "";
            pictureBox1.Image = null;
            thumnail_img = null;

            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            conn = new OleDbConnection(connectionString);
            conn.Open();
            OleDbCommand cmd = new OleDbCommand();



            string st = DateTime.Now.ToString("yyyy-MM-dd-HH-mm");


            string start = $"TO_DATE('{st}', 'yyyy-MM-dd-HH24-mi')";
            string q;

            if (all)
            {
                q = $"select s.상영번호 as 번호, m.영화제목 as 제목,s.상영시작시간 as 시작,s.상영종료시간 as 종료, s.상영관번호 as 상영관,s.요금 from 영화 m, 상영스케줄 s where s.영화번호 = m.영화번호 ";

            }
            else
            {
                q = $"select s.상영번호 as 번호, m.영화제목 as 제목,s.상영시작시간 as 시작,s.상영종료시간 as 종료, s.상영관번호 as 상영관,s.요금 from 영화 m, 상영스케줄 s where s.영화번호 = m.영화번호 and s.상영시작시간 > {start}";

            }

            Console.WriteLine(q);

            cmd.CommandText = q;
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
                    if (i == 2 || i == 3)
                    {
                        obj[i] = ((DateTime)read.GetValue(i)).ToString("yy-MM-dd HH:mm");
                    }

                }


                dataGridView1.Rows.Add(obj); //데이터그리드뷰에 오브젝트 배열 추가
            }


            conn.Close();

            try
            {
                int row = 0;

                start = dataGridView1.Rows[row].Cells[2].Value.ToString();
                string end = dataGridView1.Rows[row].Cells[3].Value.ToString();
                string hall = dataGridView1.Rows[row].Cells[4].Value.ToString();
                string price = dataGridView1.Rows[row].Cells[5].Value.ToString();

                string MovieID = dataGridView1.Rows[row].Cells[1].Value.ToString();
                startBox.Text = start;
                endBox.Text = end;
                hallBox.Text = hall;
                priceBox.Text = price;

                Console.WriteLine(start + end + hall + price);



                String id = (String)dataGridView1.Rows[row].Cells[0].Value;
                Console.WriteLine(id);
                conn = new OleDbConnection(connectionString);
                try
                {
                    conn.Open(); //데이터베이스 연결
                    cmd = new OleDbCommand();
                    cmd.CommandText = $"select * from 영화 where 영화번호 = (select 영화번호 from 상영스케줄 where 상영번호='{id}') ";
                    Console.WriteLine(cmd.CommandText);
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = conn;

                    read = cmd.ExecuteReader(); //select  결과

                    if (read.Read())
                    {
                        titleBox.Text = read.GetValue(1).ToString();
                        directorBox.Text = read.GetValue(2).ToString();
                        actorBox.Text = read.GetValue(3).ToString();


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
            catch (Exception)
            {

            }


            /*
            try
            {
                String id = (String)dataGridView1.Rows[0].Cells[0].Value;
                Console.WriteLine(id);
               // idBox.Text = id;
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

            */


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)

        {
            int row = e.RowIndex;
            if (row == -1)
            {
                return;
            }
            string start = dataGridView1.Rows[row].Cells[2].Value.ToString();
            string end = dataGridView1.Rows[row].Cells[3].Value.ToString();
            string hall = dataGridView1.Rows[row].Cells[4].Value.ToString();
            string price = dataGridView1.Rows[row].Cells[5].Value.ToString();

            string MovieID = dataGridView1.Rows[row].Cells[1].Value.ToString();
            startBox.Text = start;
            endBox.Text = end;
            hallBox.Text = hall;
            priceBox.Text = price;

            Console.WriteLine(start + end + hall + price);



            String id = (String)dataGridView1.Rows[e.RowIndex].Cells[0].Value;
            Console.WriteLine(id);
            conn = new OleDbConnection(connectionString);
            try
            {
                conn.Open(); //데이터베이스 연결
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = $"select * from 영화 where 영화번호 = (select 영화번호 from 상영스케줄 where 상영번호='{id}') ";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;

                OleDbDataReader read = cmd.ExecuteReader(); //select  결과

                if (read.Read())
                {
                    titleBox.Text = read.GetValue(1).ToString();
                    directorBox.Text = read.GetValue(2).ToString();
                    actorBox.Text = read.GetValue(3).ToString();


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


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {




        }

        private void button4_Click(object sender, EventArgs e)
        {
            Console.WriteLine(show_all);
            if (!show_all)
            {
                button4.Text = "현재보기";
            }
            else
            {
                button4.Text = "전체보기";
            }
            show_all = !show_all;
            GridViewRefresh(show_all);


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
                String movie = dataGridView1.Rows[row].Cells[1].Value.ToString();
                if (MessageBox.Show($"정말로 {movie} 를 스케줄에서 삭제 할까요?", "삭제확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    conn = new OleDbConnection(connectionString);
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand();
                    String query = $"delete  from 상영스케줄 where 상영번호='{id}'";
                    cmd.CommandText = query;
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = conn;
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show($"해당 시간에 예매를 한 회원이 있기 때문에 삭제 불가합니다.", "삭제 실패");
                        conn.Close();
                        return;
                    }
                    MessageBox.Show($"스케줄이 삭제  삭제되었습니다.", "삭제 성공");
                    GridViewRefresh(show_all);
                    conn.Close();


                }
            }
        }
    }
}
