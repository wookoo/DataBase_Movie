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
using System.Net.Mail;


namespace DataBase_Movie
{
    public partial class FormAdminSendEmail : Form
    {
        private ArrayList EmailList;
        public FormAdminSendEmail(ArrayList EmailList)
        {
            InitializeComponent();
            this.EmailList = EmailList;
            String receivers = "";


            for (int i = 0; i < EmailList.Count; i++)
            {
                receivers += EmailList[i] + ", ";
            
            }
            receivers = receivers.Substring(0, receivers.Length - 2);
            this.receiver.Text = receivers;

            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void sendMailBtn_Click(object sender, EventArgs e)
        {

            String title = titleBox.Text.Trim();
            String Body = bodyBox.Text.Trim();
            if(title == "")
            {
                MessageBox.Show("제목을 입력해주세요", "메일 전송 실패");
                return;
            }
            else if(Body == "")
            {
                MessageBox.Show("본문을 입력해주세요", "메일 전송 실패");
                return;
            }
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("nanayagoon@naver.com", "DohyunMovie", System.Text.Encoding.UTF8);
            for(int i = 0; i < EmailList.Count; i++)
            {
                String email = (String)EmailList[i];
                mail.To.Add(email);
            }
          

            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.Subject = title;
            mail.Body = Body;
            SmtpClient smtpServer = new SmtpClient("smtp.naver.com", 587);
            string path = @"d:\IDPW.txt";

            // text file 의 전체 text 를 읽어 옵니다.
            string textValue = System.IO.File.ReadAllText(path);

            string[] MAIL_SENDER_IDPW = textValue.Split('/');
            string MAIL_SENDER_ID = MAIL_SENDER_IDPW[0].Trim();
            string MAIL_SENDER_PW = MAIL_SENDER_IDPW[1].Trim();
            //Console.WriteLine(MAIL_SENDER_ID);
            //Console.WriteLine(MAIL_SENDER_PW);
            smtpServer.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            smtpServer.Credentials = new System.Net.NetworkCredential(MAIL_SENDER_ID, MAIL_SENDER_PW);
            smtpServer.EnableSsl = true;
            smtpServer.Send(mail);
            MessageBox.Show("이메일이 전송되었습니다!", "메일전송 성공");


        }
    }
}
