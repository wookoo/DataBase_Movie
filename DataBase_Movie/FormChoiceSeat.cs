using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Data.OleDb;


namespace DataBase_Movie
{
    public partial class FormChoiceSeat : Form
    {

        public ArrayList buttons = new ArrayList();
        String email;
        String id;
        OleDbConnection conn;
        string connectionString = "Provider=OraOLEDB.Oracle;Password=dohyun;User ID=dohyun"; //oracle 서버 연결

        public FormChoiceSeat(String email,String id)
        {
            InitializeComponent();
            this.email = email;
            this.id = id;

            //$"select 상영관번호 from 상영스케줄 where 상영번호='{id}'"; 이걸로 상영관 좌석 가져오고
            //select 행번호,위치번호 from 상영관좌석 d,  (select 상영관번호 from 상영스케줄 where 상영번호=24) e where d.상영관번호 = e.상영관번호;

            //1관

            conn = new OleDbConnection(connectionString);
            conn.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = $"select 상영관번호 from 상영스케줄 where 상영번호='{id}'";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;
            OleDbDataReader read = cmd.ExecuteReader();
            string hall = "";
            if (read.Read())
            {
                hall = read.GetValue(0).ToString();
                Console.WriteLine(hall);
            }
            //1관 반환
            conn.Close();

            
            if(hall == "1관")
            {
                int k = 0;
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        System.Windows.Forms.Button b = new System.Windows.Forms.Button();
                        b.Name = "A" + k;
                        b.Size = new System.Drawing.Size(38, 35);
                        b.Text = "A" + (k++);
                        this.panel1.Controls.Add(b);
                        b.Location = new System.Drawing.Point(200 + (44 * (j % 3)), 70 + (41 * (i % 10)));

                        //23 67 111
                        b.UseVisualStyleBackColor = true;
                        buttons.Add(b);
                    }

                }
                k = 0;
     
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {

                        System.Windows.Forms.Button b = new System.Windows.Forms.Button();
                        b.Name = "B" + k;
                        b.Size = new System.Drawing.Size(38, 35);
                        b.Text = "B" + k++;
                        this.panel1.Controls.Add(b);
                        b.Location = new System.Drawing.Point(400 + (44 * (j % 3)), 70 + (41 * (i % 10)));

                        //23 67 111
                        b.UseVisualStyleBackColor = true;
                        buttons.Add(b);
                    }

                }
            }
            else if(hall == "2관")
            {
                int k = 0;
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        System.Windows.Forms.Button b = new System.Windows.Forms.Button();
                        b.Name = "A" + k;
                        b.Size = new System.Drawing.Size(38, 35);
                        b.Text = "A" + (k++);
                        this.panel1.Controls.Add(b);
                        b.Location = new System.Drawing.Point(23 + (44 * (j % 3)), 70 + (41 * (i % 10)));

                        //23 67 111
                        b.UseVisualStyleBackColor = true;
                        buttons.Add(b);
                    }

                }

                k = 0;
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {

                        System.Windows.Forms.Button b = new System.Windows.Forms.Button();
                        b.Name = "B" + k;
                        b.Size = new System.Drawing.Size(38, 35);
                        b.Text = "B" + k++;
                        this.panel1.Controls.Add(b);
                        b.Location = new System.Drawing.Point(300 + (44 * (j % 3)), 70 + (41 * (i % 10)));

                        //23 67 111
                        b.UseVisualStyleBackColor = true;
                        buttons.Add(b);
                    }

                }
                k = 0;
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {

                        System.Windows.Forms.Button b = new System.Windows.Forms.Button();
                        b.Name = "C" + k;
                        b.Size = new System.Drawing.Size(38, 35);
                        b.Text = "C" + k++;
                        this.panel1.Controls.Add(b);
                        b.Location = new System.Drawing.Point(600 + (44 * (j % 3)), 70 + (41 * (i % 10)));

                        //23 67 111
                        b.UseVisualStyleBackColor = true;
                        buttons.Add(b);
                    }

                }

            }
            else
            {
                int k = 0;
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        System.Windows.Forms.Button b = new System.Windows.Forms.Button();
                        b.Name = "A" + k;
                        b.Size = new System.Drawing.Size(38, 35);
                        b.Text = "A" + (k++);
                        this.panel1.Controls.Add(b);
                        b.Location = new System.Drawing.Point(200 + (44 * (j % 3)), 70 + (41 * (i % 10)));

                        //23 67 111
                        b.UseVisualStyleBackColor = true;
                        buttons.Add(b);
                    }

                }

                k = 0;

                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {

                        System.Windows.Forms.Button b = new System.Windows.Forms.Button();
                        b.Name = "B" + k;
                        b.Size = new System.Drawing.Size(38, 35);
                        b.Text = "B" + k++;
                        this.panel1.Controls.Add(b);
                        b.Location = new System.Drawing.Point(400 + (44 * (j % 3)), 70 + (41 * (i % 10)));

                        //23 67 111
                        b.UseVisualStyleBackColor = true;
                        buttons.Add(b);
                    }

                }
            }

            

            for(int i = 0; i < buttons.Count; i++)
            {
                Button b = (Button)buttons[i];
                b.Click += new System.EventHandler(this.BTN_Click);
            }

            conn.Open();
            cmd.CommandText = $"select 행번호,위치번호 from 예매좌석 where 상영번호='{id}'";

            read = cmd.ExecuteReader();
            while (read.Read())
            {
                String row = read.GetValue(0).ToString();
                int t = (row[0] - 'A')*30;
                int col = Int32.Parse(read.GetValue(1).ToString());
                
                Console.WriteLine(t + col);

                (buttons[t + col] as Button).Enabled = false;
            }


        }


        private void BTN_Click(object sender, EventArgs e)
        {
            Button s = sender as Button;
        
            if(s.BackColor == SystemColors.Control)
            {
                s.BackColor = Color.Blue;
                s.ForeColor = Color.White;
            }
            else
            {
                s.BackColor = SystemColors.Control;
                s.ForeColor = Color.Black;
            }
            Console.WriteLine(s.Text);
            string color = s.BackColor.ToString();
            Console.WriteLine(color);
            


        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            ArrayList Seats = new ArrayList();
            String choice = "";
            
            for(int i = 0; i < buttons.Count; i++)
            {
                Button s = buttons[i] as Button;
                if (s.BackColor == Color.Blue)
                {
                    
                    Seats.Add(s.Text);
                    Console.WriteLine(s.Text);
                    choice += s.Text + " ";

                }
            }
            
            if(Seats.Count == 0)
            {
                MessageBox.Show("적어도 한개 이상 선택해주세요", "예매 불가");
                return;
            }
     
           if( MessageBox.Show(Seats.Count +"개의 좌석" +choice +"를 예매 할까요?","예매확인", MessageBoxButtons.YesNo) == DialogResult.Yes){

                this.Hide();
                FormPayment f = new FormPayment(email,id,Seats);
                f.Closed += (s, args) => this.Close();
            
                f.ShowDialog();
                //결제폼으로 넘어가기
                //
            }
        }
    }
}
