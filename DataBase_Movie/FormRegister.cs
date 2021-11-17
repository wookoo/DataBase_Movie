using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;

namespace DataBase_Movie
{
    public partial class FormRegister : Form
    {
        public FormRegister()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void send_auth_btn_Click(object sender, EventArgs e)
        {
            MailMessage mail = new MailMessage();
            Console.WriteLine("start");
            mail.From = new MailAddress("nanayagoon@naver.com", "DohyunMovie", System.Text.Encoding.UTF8);
            mail.To.Add("nanayagoon@daum.net");
            mail.Subject = "도현 무비 인증번호는 [1234] 입니다";
            mail.Body = "도현 무비 인증번호는 [1234] 입니다";
            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            mail.BodyEncoding = System.Text.Encoding.UTF8;



            SmtpClient smtpServer = new SmtpClient("smtp.naver.com",587);
          
            smtpServer.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            smtpServer.Credentials = new System.Net.NetworkCredential("네이버 아이디", "비밀번호");
            smtpServer.EnableSsl = true;
            smtpServer.Send(mail);
            Console.WriteLine("end");

        }
    }
}
