using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace DataBase_Movie
{
    public partial class FormFindAccount : Form
    {
        public FormFindAccount()
        {
            InitializeComponent();
        }

        private void only_digit_Event(object sender, KeyPressEventArgs e)
        {
            // 숫자와 백스페이스만 입력가능
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }


        private void findAccountBtn_Click(Object sender, EventArgs e)
        {
            String regName = @"^[가-힣]{2,4}";
            String name = nameBox.Text.Trim();

            bool valid = Regex.IsMatch(name, regName);
            if (!valid)
            {
                MessageBox.Show("정확한 이름을 입력해주세요", "계정찾기 실패");
                return;
            }

            String regExpPhone = @"\d{2,3}-\d{3,4}-\d{4}";
            String phone = phoneDrop.Text.Trim() + "-" + phoneMiddleBox.Text.Trim() + "-" + phoneLastBox.Text.Trim();
            valid = Regex.IsMatch(phone, regExpPhone);
            if (!valid)
            {
                MessageBox.Show("올바른 전화번호를 입력해주세요", "계정찾기 실패");
                return;
            }
        }
    }
}
