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
        public FormAdminEditGrade()
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
            String query = "select * from 할인율 order by 할인율 desc";
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

        private void button2_Click(object sender, EventArgs e)
        {
            int selectedCellCount =
        dataGridView.GetCellCount(DataGridViewElementStates.Selected);
            if (selectedCellCount == 0)
            {
                MessageBox.Show("수정할 대상을 선택해주세요", "수정 불가");
                return;
            }
            if (selectedCellCount > 0)
            {
         
                int row = dataGridView.SelectedCells[0].RowIndex;

                for (int i = 0; i < selectedCellCount; i++)
                {

                
                    if(row != dataGridView.SelectedCells[i].RowIndex)
                    {
                        MessageBox.Show("한번에 한개만 수정 가능합니다.", "수정 불가");
                        return;
                    }
                

                }
                String grade = dataGridView.Rows[row].Cells[0].Value.ToString();
                String discount = dataGridView.Rows[row].Cells[1].Value.ToString();
                FormAdminEditAddGrade f = new FormAdminEditAddGrade(grade, discount);
                f.ShowDialog();




                //여기서 dataRefresh
                Console.WriteLine(grade);
                GridViewRefresh();


            }
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void removeBtn_Click(object sender, EventArgs e)
        {

            int selectedCellCount =
        dataGridView.GetCellCount(DataGridViewElementStates.Selected);
            if (selectedCellCount == 0)
            {
                MessageBox.Show("삭제할 대상을 선택해주세요", "삭제 불가");
                return;
            }
            if (selectedCellCount > 0)
            {

                int row = dataGridView.SelectedCells[0].RowIndex;

                for (int i = 0; i < selectedCellCount; i++)
                {


                    if (row != dataGridView.SelectedCells[i].RowIndex)
                    {
                        MessageBox.Show("한번에 한개만 삭제 가능합니다.", "삭제 불가");
                        return;
                    }


                }
                String grade = dataGridView.Rows[row].Cells[0].Value.ToString();
                String discount = dataGridView.Rows[row].Cells[1].Value.ToString();
                if (MessageBox.Show($"정말로 {grade} 등급을 삭제 할까요?", "삭제확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    conn = new OleDbConnection(connectionString);
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand();
                    String query = $"delete  from 할인율 where 등급='{grade}'";
                    cmd.CommandText = query;
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = conn;
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show($"{grade} 등급을 가진 회원이 있기 때문에 삭제 불가합니다.", "삭제 실패");
                        conn.Close();
                        return;
                    }
                    MessageBox.Show($"{grade} 등급이 삭제되었습니다.", "삭제 성공");
                    conn.Close();





                    GridViewRefresh();
                }

                    


            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            FormAdminEditAddGrade f = new FormAdminEditAddGrade();
            f.ShowDialog();
            GridViewRefresh();
        }
    }
}
