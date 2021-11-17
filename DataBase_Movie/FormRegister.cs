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
using System.Text.RegularExpressions;


namespace DataBase_Movie
{
    public partial class FormRegister : Form
    {
        int process = 0;
        String code = "";
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
            if (process == 0)
            {
                //이메일 정규식 확인
                String email = eMailBox.Text.Trim();
                bool valid = Regex.IsMatch(email, @"[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?\.)+[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?");
                if (!valid)
                {
                    MessageBox.Show("올바른 이메일을 입력해주세요!");
                    return;
                }
                //try
               // {
                    MailMessage mail = new MailMessage();
                    Console.WriteLine("start");
                    mail.From = new MailAddress("nanayagoon@naver.com", "DohyunMovie", System.Text.Encoding.UTF8);
                    mail.To.Add(email);
                    Random generator = new Random();
                    String r = generator.Next(0, 999999).ToString("D6");
                    code = r;
                    mail.Subject = $"도현 무비 인증번호는 [{r}] 입니다.";
                    mail.Body = $"도현 무비 인증번호는 [{r}] 입니다.";
                    mail.SubjectEncoding = System.Text.Encoding.UTF8;
                    mail.BodyEncoding = System.Text.Encoding.UTF8;
                    Console.WriteLine(mail.Subject);
                    



                    SmtpClient smtpServer = new SmtpClient("smtp.naver.com", 587);

                    smtpServer.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                    smtpServer.Credentials = new System.Net.NetworkCredential("id", "pw");
                    smtpServer.EnableSsl = true;
                    smtpServer.UseDefaultCredentials = false;
                    smtpServer.Send(mail);
                    MessageBox.Show("이메일이 전송되었습니다!");
                    this.send_auth_mail.Text = "인증확인";


                    //전송이 잘 된다면 해당 작업 수행
                    this.authCodeBox.Enabled = true;
                    this.authCodeBox.ReadOnly = false;
                    process = 1;
                    return;


                //}
                //catch (Exception)
               // {
                 //   MessageBox.Show("이메일이 전송에 실패하였습니다.");
                //}
                
               
               

            }
            else if(process == 1)
            {
                Console.WriteLine(code + authCodeBox.Text);
                String inputCode = authCodeBox.Text.Trim();
                if(inputCode == code)
                {
                    Console.WriteLine("인증확인됨");
                    this.authCodeBox.Enabled = false;
                    this.send_auth_mail.Text = "인증완료";
                    this.send_auth_mail.Enabled = false;
                    process = 2;
                }
                else
                {
                    Console.WriteLine("인증번호를 확인해주세요");
                }

            }

        }
    }
}
