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
        string connectionString = "Provider=MSDAORA;Password=dohyun;User ID=dohyun"; //oracle 서버 연결

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
            String query = $"select r.예매번호, m.영화제목,r.예매일시,r.인원,r.금액 from 영화 m, (select 예매번호,영화번호, count(예매번호) as 인원, sum(금액) as 금액,예매일시 from 예매좌석 where 아이디 = '{email}' group by 예매번호,영화번호,예매일시)" +
                $" r where r.영화번호 = m.영화번호 ";
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

         



        }



    }
}
