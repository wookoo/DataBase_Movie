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
using System.Data.OleDb;
using System.Security.Cryptography;


namespace DataBase_Movie
{
    public partial class FormRegister : Form
    {
        int process = 0;
        String code = "";
        OleDbConnection conn;
        string connectionString = "Provider=MSDAORA;Password=dohyun;User ID=dohyun"; //oracle 서버 연결
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

        private void only_digit_Event(object sender, KeyPressEventArgs e)
        {
            // 숫자와 백스페이스만 입력가능
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }

        private void send_auth_btn_Click(object sender, EventArgs e)
        {
            if (process == 0)
            {

                //이메일 정규식 확인
                String email = eMailBox.Text.Trim();
                bool valid = Regex.IsMatch(email, @"[a-zA-Z0-9!#$%&'*+/s=?^_`{|}~-]+(?:\.[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?\.)+[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?");
                //valid = true;
                

     
                if (!valid)
                {
                    MessageBox.Show("올바른 이메일을 입력해주세요!");
                    return;
                }
                conn = new OleDbConnection(connectionString);
                conn.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = "select * from 회원 where 아이디 = '" + email + "'";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;

                OleDbDataReader read = cmd.ExecuteReader();
                
                if (read.Read())
                {
                    MessageBox.Show("이미 사용중인 이메일입니다!","이메일 사용불가");
                    if(conn != null)
                    {
                        conn.Close(); //데이터베이스 연결 해제
                    }
                    return;
                }
                try
                {
                    conn.Close(); //데이터베이스 연결 해제
                }
                catch
                {

                }
              
                //try
               // {
                    MailMessage mail = new MailMessage();
                    Console.WriteLine("start");
                String now = DateTime.Now.ToString("MM월dd일HH시mm분ss초");

                mail.From = new MailAddress("nanayagoon@naver.com", "DohyunMovie", System.Text.Encoding.UTF8);
                    mail.To.Add(email);
                    Random generator = new Random();
                    String r = generator.Next(0, 999999).ToString("D6");
                    code = r;
                    mail.SubjectEncoding = System.Text.Encoding.UTF8;
                    mail.BodyEncoding = System.Text.Encoding.UTF8;
                    mail.Subject = $"도현 무비 인증번호는 [{r}] 입니다. 전송시각 : " + now;
                mail.Body = mail.Subject;






                SmtpClient smtpServer = new SmtpClient("smtp.naver.com", 587);
                string path = @"d:\IDPW.txt";

                // text file 의 전체 text 를 읽어 옵니다.
                string textValue = System.IO.File.ReadAllText(path);

                string[] MAIL_SENDER_IDPW = textValue.Split('/');
                string MAIL_SENDER_ID = MAIL_SENDER_IDPW[0].Trim();
                string MAIL_SENDER_PW = MAIL_SENDER_IDPW[1].Trim();
                Console.WriteLine(MAIL_SENDER_ID);
                Console.WriteLine(MAIL_SENDER_PW);
                smtpServer.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                smtpServer.Credentials = new System.Net.NetworkCredential(MAIL_SENDER_ID, MAIL_SENDER_PW);
                smtpServer.EnableSsl = true;
                smtpServer.Send(mail);
                MessageBox.Show("이메일이 전송되었습니다!","메일전송 성공");
                    this.send_auth_mail.Text = "인증확인";


                    //전송이 잘 된다면 해당 작업 수행
                    this.authCodeBox.Enabled = true;
                    this.authCodeBox.ReadOnly = false;
                this.eMailBox.Enabled = false;
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
                    
                    MessageBox.Show("인증되었습니다!");
                    process = 2;
                }
                else
                {
                    Console.WriteLine("인증번호를 확인해주세요");
                }

            }

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void cancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("정말로 회원가입을 취소할까요?", "회원가입 취소", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Close();
            }
      
        }

        private void cardBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cardDrop_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void register_btn_Click(Object sender, EventArgs e)
        {
  

            if (MessageBox.Show("정말로 회원가입을 할까요?", "회원가입", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //여기서 검사 실행
                if(process != 2)
                 {
                     MessageBox.Show("이메일 인증을 해주세요", "회원가입 실패");
                     return;
                 }

                String passWord = passwordBox.Text;
                String repassWord = rePasswordBox.Text;
                if(passWord != repassWord)
                {
                    MessageBox.Show("두 비밀번호가 일치하지 않습니다.", "회원가입 실패");
                    return;
                }

                String regExpPw = @"(?=.*[a-zA-Z])(?=.*[0-9])(?=.*[^\w\s]).{8,}";
                bool valid = Regex.IsMatch(passWord, regExpPw);

                
                if (!valid )
                {
                    MessageBox.Show("비밀번호는 숫자, 특수문자, 영문 각 1회 이상 " +
                        "사용하여 8자리 이상으로 설정해주세요",
                        "회원가입 실패");
                    return;
                }

                String regName = @"^[가-힣]{2,4}";
                String name = nameBox.Text.Trim();

                valid = Regex.IsMatch(name, regName);
                if (!valid)
                {
                    MessageBox.Show("정확한 이름을 입력해주세요", "회원가입 실패");
                    return;
                }

                String regExpPhone = @"\d{2,3}-\d{3,4}-\d{4}";
                String phone = phoneDrop.Text.Trim() +"-"+ phoneMiddleBox.Text.Trim() + "-" + phoneLastBox.Text.Trim();
                valid = Regex.IsMatch(phone, regExpPhone);
       
                if (!valid)
                {
                    MessageBox.Show("올바른전화번호를 입력해주세요",
                        "회원가입 실패");
                    return;
                }
           
                String regExpCard = @"\d{4}-\d{4}-\d{4}-\d{4}";
                String card = $"{CardFirstBox.Text.Trim()}-{CardSecondBox.Text.Trim()}-" +
                    $"{CardThirdBox.Text.Trim()}-{CardFourthBox.Text.Trim()}";
                valid = Regex.IsMatch(card, regExpCard);
                if (!valid)
                {
                    MessageBox.Show("올바른카드번호를 입력해주세요",
                        "회원가입 실패");
                    return;
                }

                card = cardDrop.Text.Trim() +" " + card;

          

                SHA256 hash1 = new SHA256Managed();
                byte[] bytes1 = hash1.ComputeHash(Encoding.ASCII.GetBytes(passWord));

                // 16진수 형태로 문자열 결합
                StringBuilder sb1 = new StringBuilder();
                foreach (byte b1 in bytes1)
                    sb1.AppendFormat("{0:x2}", b1);

                // 입력값의 해시결과
                String crypted_pw = sb1.ToString();
                String email = eMailBox.Text.Trim();
                String query = $"insert into 회원 values ('{email}','{crypted_pw}','{name}','{phone}','SILVER','{card}')";
                Console.WriteLine(query);
                //이름 휴대전화 등급 카드번호

                try
                {
                    conn = new OleDbConnection(connectionString);
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.CommandText = query;
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = conn;

                    cmd.ExecuteNonQuery();
                    conn.Close(); //데이터베이스 연결 해제
                    MessageBox.Show("회원가입되었습니다.", "회원가입 성공");
                    Close();
                }
                catch
                {
                    MessageBox.Show("알수없는 오류로 회원가입에 실패했습니다", "회원가입 실패");
                }
                

                








            }
        }
        //private void 
    }
}
