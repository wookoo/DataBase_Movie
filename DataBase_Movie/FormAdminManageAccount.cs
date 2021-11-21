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
    public partial class FormAdminManageAccount : Form
    {
        OleDbConnection conn;
        string connectionString = "Provider=MSDAORA;Password=dohyun;User ID=dohyun"; //oracle 서버 연결
        public FormAdminManageAccount()
        {
            InitializeComponent();
            GridViewRefresh();



        }

        private void GridViewRefresh()
        {

            dataGridView.DataSource = null;
            dataGridView.Rows.Clear();
            conn = new OleDbConnection(connectionString);
            conn.Open();
            OleDbCommand cmd = new OleDbCommand();
            String query = "select 아이디,이름,전화번호,등급 from 회원 where not 아이디='admin'";
            cmd.CommandText = query;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;
            OleDbDataReader read = cmd.ExecuteReader();
            int count = read.FieldCount;
            dataGridView.ColumnCount = count;
            for (int i = 0; i < count; i++)
            {
                dataGridView.Columns[i].Name = read.GetName(i);
            }
            while (read.Read())
            {

                object[] obj = new object[count]; // 필드수만큼 오브젝트 배열
                for (int i = 0; i < count; i++) // 필드 수만큼 반복
                {

                    obj[i] = new object();
                    obj[i] = read.GetValue(i);
                }


                dataGridView.Rows.Add(obj); //데이터그리드뷰에 오브젝트 배열 추가
            }
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            int selectedCellCount =
        dataGridView.GetCellCount(DataGridViewElementStates.Selected);
            if(selectedCellCount == 0)
            {
                MessageBox.Show("전송할 사람들을 선택해주세요", "메일전송 불가");
                return;
            }
            if (selectedCellCount > 0)
            {
                ArrayList EmailList = new ArrayList();

                for (int i = 0; i < selectedCellCount; i++)
                {

                    int row = dataGridView.SelectedCells[i].RowIndex;
                    String emil = dataGridView.Rows[row].Cells[0].Value.ToString();
                    if(EmailList.IndexOf(emil) == -1)
                    {
                        EmailList.Add(emil);
                    }
       

                }
                for(int i = 0; i < EmailList.Count; i++)
                {
                    Console.WriteLine((String)EmailList[i]);
                }

                FormAdminSendEmail f = new FormAdminSendEmail(EmailList);
                f.ShowDialog();

                //여기서 dataRefresh
                Console.WriteLine("종료");
                GridViewRefresh();

            }
        }

        private void changeGradeBtn_Click(object sender, EventArgs e)
        {
            
            int selectedCellCount =
        dataGridView.GetCellCount(DataGridViewElementStates.Selected);
            if (selectedCellCount == 0)
            {
                MessageBox.Show("등급을 수정할 사람들을 선택해주세요", "등급수정 불가");
                return;
            }
            if (selectedCellCount > 0)
            {
                ArrayList EmailList = new ArrayList();
                ArrayList GradeList = new ArrayList();

                for (int i = 0; i < selectedCellCount; i++)
                {

                    int row = dataGridView.SelectedCells[i].RowIndex;
                    String emil = dataGridView.Rows[row].Cells[0].Value.ToString();
                    String grade = dataGridView.Rows[row].Cells[3].Value.ToString();
                    if (EmailList.IndexOf(emil) == -1)
                    {
                        EmailList.Add(emil);
                        GradeList.Add(grade);
                    }


                }
                for (int i = 0; i < EmailList.Count; i++)
                {
                    Console.WriteLine((String)EmailList[i]);
                }
                FormAdminEditUserGrade f = new FormAdminEditUserGrade(EmailList,GradeList);
                f.ShowDialog();

                GridViewRefresh();

            }
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
