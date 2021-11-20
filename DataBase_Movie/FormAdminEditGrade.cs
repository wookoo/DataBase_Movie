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
    public partial class FormAdminEditGrade : Form
    {
        OleDbConnection conn;
        string connectionString = "Provider=MSDAORA;Password=dohyun;User ID=dohyun"; //oracle 서버 연결

        public int WIDTH = 0;
        public int HEIGHT = 0;
        ArrayList EmailList;
        ArrayList GradeList;
        public FormAdminEditGrade(ArrayList EmailList, ArrayList GradeList)
        {
            this.EmailList = EmailList;
            this.GradeList = GradeList;
          
            

            InitializeComponent();
            
            for (int i = 0; i < EmailList.Count; i++)
            {
                this.emailListBox.Items.Add(EmailList[i]);
                this.gradeListBox.Items.Add(GradeList[i]);
            }
            DynamicButton();
        }

        public void DynamicButton()

        {
            ToolTip toolTip = new ToolTip();

            toolTip.AutoPopDelay = 5000;
            toolTip.InitialDelay = 300;
            toolTip.ReshowDelay = 500;
            toolTip.ShowAlways = true;


            

            conn = new OleDbConnection(connectionString);
            conn.Open();
            OleDbCommand cmd = new OleDbCommand();
            String query = "select * from 할인율 order by 할인율";
            cmd.CommandText = query;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;
            OleDbDataReader read = cmd.ExecuteReader();
    
            ArrayList Grades = new ArrayList();
            ArrayList discount = new ArrayList();
            while (read.Read())
            {
                Grades.Add(read.GetValue(0));
                discount.Add(read.GetValue(1));
            }
            conn.Close();

            for (int i = 0; i <Grades.Count; i++)
            {
                Console.WriteLine(Grades[i]);
            }


            Control[] BTN = new Control[Grades.Count];

            FlowLayoutPanel panel = this.flowLayoutPanel1;
            int width = (panel.Width / Grades.Count) - 10;
            Console.WriteLine(panel.Width);
 



            for (int idx = 0; idx < Grades.Count; idx++)

            {
                Console.WriteLine(idx);

                BTN[idx] = new Button();

                BTN[idx].Name = Grades[idx].ToString();

                BTN[idx].Parent = this;

      


                BTN[idx].Text = Grades[idx].ToString();

                toolTip.SetToolTip(BTN[idx], "할인율 : " + discount[idx] + "%");
  



                WIDTH += 80;

                HEIGHT += 30;
                BTN[idx].Click += new EventHandler(this.ButtonClick);
                // int width = tableLayoutPanel1.GetColumnWidths()[idx];


                BTN[idx].Width = width;




                panel.Controls.Add(BTN[idx]);

            }
            





        }

        private void ButtonClick(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Console.WriteLine(btn.Text);
            //UPDATE [테이블] SET [열] = '변경할값' WHERE [조건]

           
            if(MessageBox.Show($"정말로 {EmailList.Count} 명의 등급을 {btn.Text} 로 설정할까요?","갱신 알림",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                String users = "";
                for (int i = 0; i < EmailList.Count; i++)
                {
                    users += $"'{EmailList[i]}',";

                }
                users = users.Trim(',');
                String query = $"update 회원 set 등급='{btn.Text}' where 아이디 in ({users})";
                Console.WriteLine(query);
                conn = new OleDbConnection(connectionString);
                conn.Open();
                Console.WriteLine("여기");
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = conn;
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;

                Console.WriteLine("여기2");
                cmd.ExecuteNonQuery();

                conn.Close(); //데이터베이스 연결 해제
                MessageBox.Show($"성공적으로 {EmailList.Count}명의 등급을{btn.Text} 로 변경했습니다.", "갱신성공");


                for (int i = 0; i < EmailList.Count; i++)
                {
              
                    this.gradeListBox.Items[i] = btn.Text;
                }

            }




        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void emailListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
