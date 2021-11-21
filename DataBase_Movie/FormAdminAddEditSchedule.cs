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
        string connectionString = "Provider=MSDAORA;Password=dohyun;User ID=dohyun"; //oracle 서버 연결

        public FormAdminAddEditSchedule()
        {
            InitializeComponent();

            DateTime d1 = this.dateTimePicker1.Value;


            //DateTime d2 = d1.AddMinutes(25);
            //this.dateTimePicker2.Value = d2;
            
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


        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
