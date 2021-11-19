
namespace DataBase_Movie
{
    partial class FormRegister
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.phoneLastBox = new System.Windows.Forms.TextBox();
            this.phoneMiddleBox = new System.Windows.Forms.TextBox();
            this.phoneDrop = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.CardThirdBox = new System.Windows.Forms.TextBox();
            this.CardSecondBox = new System.Windows.Forms.TextBox();
            this.CardFirstBox = new System.Windows.Forms.TextBox();
            this.cardDrop = new System.Windows.Forms.ComboBox();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.registerBtn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.CardFourthBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.send_auth_mail = new System.Windows.Forms.Button();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.rePasswordBox = new System.Windows.Forms.TextBox();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.authCodeBox = new System.Windows.Forms.TextBox();
            this.eMailBox = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.phoneLastBox);
            this.panel1.Controls.Add(this.phoneMiddleBox);
            this.panel1.Controls.Add(this.phoneDrop);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.CardThirdBox);
            this.panel1.Controls.Add(this.CardSecondBox);
            this.panel1.Controls.Add(this.CardFirstBox);
            this.panel1.Controls.Add(this.cardDrop);
            this.panel1.Controls.Add(this.cancelBtn);
            this.panel1.Controls.Add(this.registerBtn);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.CardFourthBox);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.send_auth_mail);
            this.panel1.Controls.Add(this.nameBox);
            this.panel1.Controls.Add(this.rePasswordBox);
            this.panel1.Controls.Add(this.passwordBox);
            this.panel1.Controls.Add(this.authCodeBox);
            this.panel1.Controls.Add(this.eMailBox);
            this.panel1.Location = new System.Drawing.Point(220, 61);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(525, 352);
            this.panel1.TabIndex = 0;
            // 
            // phoneLastBox
            // 
            this.phoneLastBox.Location = new System.Drawing.Point(245, 201);
            this.phoneLastBox.MaxLength = 4;
            this.phoneLastBox.Name = "phoneLastBox";
            this.phoneLastBox.Size = new System.Drawing.Size(57, 21);
            this.phoneLastBox.TabIndex = 24;
            this.phoneLastBox.KeyPress += this.only_digit_Event;
            // 
            // phoneMiddleBox
            // 
            this.phoneMiddleBox.Location = new System.Drawing.Point(182, 201);
            this.phoneMiddleBox.MaxLength = 4;
            this.phoneMiddleBox.Name = "phoneMiddleBox";
            this.phoneMiddleBox.Size = new System.Drawing.Size(57, 21);
            this.phoneMiddleBox.TabIndex = 23;
            this.phoneMiddleBox.KeyPress += this.only_digit_Event;
            // 
            // phoneDrop
            // 
            this.phoneDrop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.phoneDrop.FormattingEnabled = true;
            this.phoneDrop.Items.AddRange(new object[] {
            "010",
            "031",
            "032",
            "033",
            "041",
            "043",
            "054",
            "055",
            "061",
            "063"});
            this.phoneDrop.Location = new System.Drawing.Point(109, 202);
            this.phoneDrop.Name = "phoneDrop";
            this.phoneDrop.Size = new System.Drawing.Size(67, 20);
            this.phoneDrop.TabIndex = 22;
            this.phoneDrop.SelectedIndex = 0;
            this.phoneDrop.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(50, 205);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 21;
            this.label7.Text = "전화번호";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // CardThirdBox
            // 
            this.CardThirdBox.Location = new System.Drawing.Point(308, 232);
            this.CardThirdBox.MaxLength = 4;
            this.CardThirdBox.Name = "CardThirdBox";
            this.CardThirdBox.Size = new System.Drawing.Size(57, 21);
            this.CardThirdBox.TabIndex = 19;
            this.CardThirdBox.KeyPress += this.only_digit_Event;
            // 
            // CardSecondBox
            // 
            this.CardSecondBox.Location = new System.Drawing.Point(245, 233);
            this.CardSecondBox.MaxLength = 4;
            this.CardSecondBox.Name = "CardSecondBox";
            this.CardSecondBox.Size = new System.Drawing.Size(57, 21);
            this.CardSecondBox.TabIndex = 18;
            this.CardSecondBox.KeyPress += this.only_digit_Event;
            // 
            // CardFirstBox
            // 
            this.CardFirstBox.Location = new System.Drawing.Point(182, 233);
            this.CardFirstBox.MaxLength = 4;
            this.CardFirstBox.Name = "CardFirstBox";
            this.CardFirstBox.Size = new System.Drawing.Size(57, 21);
            this.CardFirstBox.TabIndex = 17;
            this.CardFirstBox.KeyPress += this.only_digit_Event;
            // 
            // cardDrop
            // 
            this.cardDrop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cardDrop.FormattingEnabled = true;
            this.cardDrop.Items.AddRange(new object[] {
            "신한",
            "삼성",
            "국민",
            "현대",
            "우리",
            "농협",
            "우체국",
            "기업",
            "카카오"});
            this.cardDrop.Location = new System.Drawing.Point(109, 233);
            this.cardDrop.Name = "cardDrop";
            this.cardDrop.Size = new System.Drawing.Size(67, 20);
            this.cardDrop.TabIndex = 16;
            this.cardDrop.SelectedIndex = 0;
            this.cardDrop.SelectedIndexChanged += new System.EventHandler(this.cardDrop_SelectedIndexChanged);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(110, 303);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(246, 24);
            this.cancelBtn.TabIndex = 15;
            this.cancelBtn.Text = "취소";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancel_Click);
            // 
            // registerBtn
            // 
            this.registerBtn.Location = new System.Drawing.Point(110, 277);
            this.registerBtn.Name = "registerBtn";
            this.registerBtn.Size = new System.Drawing.Size(246, 20);
            this.registerBtn.TabIndex = 14;
            this.registerBtn.Text = "회원가입";
            this.registerBtn.UseVisualStyleBackColor = true;
            this.registerBtn.Click += new System.EventHandler(this.register_btn_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(51, 240);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 13;
            this.label6.Text = "카드번호";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // CardFourthBox
            // 
            this.CardFourthBox.Location = new System.Drawing.Point(371, 231);
            this.CardFourthBox.MaxLength = 4;
            this.CardFourthBox.Name = "CardFourthBox";
            this.CardFourthBox.Size = new System.Drawing.Size(57, 21);
            this.CardFourthBox.TabIndex = 12;
            this.CardFourthBox.TextChanged += new System.EventHandler(this.cardBox_TextChanged);
            this.CardFourthBox.KeyPress += this.only_digit_Event;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(75, 178);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "이름";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "비밀번호 확인";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "비밀번호";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "인증번호";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "이메일";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // send_auth_mail
            // 
            this.send_auth_mail.Location = new System.Drawing.Point(265, 59);
            this.send_auth_mail.Name = "send_auth_mail";
            this.send_auth_mail.Size = new System.Drawing.Size(91, 21);
            this.send_auth_mail.TabIndex = 5;
            this.send_auth_mail.Text = "인증번호 전송";
            this.send_auth_mail.UseVisualStyleBackColor = true;
            this.send_auth_mail.Click += new System.EventHandler(this.send_auth_btn_Click);
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(110, 175);
            this.nameBox.MaxLength = 4;
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(246, 21);
            this.nameBox.TabIndex = 4;
            // 
            // rePasswordBox
            // 
            this.rePasswordBox.Location = new System.Drawing.Point(109, 136);
            this.rePasswordBox.MaxLength = 15;
            this.rePasswordBox.Name = "rePasswordBox";
            this.rePasswordBox.PasswordChar = '*';
            this.rePasswordBox.Size = new System.Drawing.Size(247, 21);
            this.rePasswordBox.TabIndex = 3;
            // 
            // passwordBox
            // 
            this.passwordBox.Location = new System.Drawing.Point(110, 99);
            this.passwordBox.MaxLength = 15;
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.PasswordChar = '*';
            this.passwordBox.Size = new System.Drawing.Size(246, 21);
            this.passwordBox.TabIndex = 2;
            // 
            // authCodeBox
            // 
            this.authCodeBox.CausesValidation = false;
            this.authCodeBox.Enabled = false;
            this.authCodeBox.Location = new System.Drawing.Point(110, 56);
            this.authCodeBox.MaxLength = 6;
            this.authCodeBox.Name = "authCodeBox";
            this.authCodeBox.ReadOnly = true;
            this.authCodeBox.Size = new System.Drawing.Size(149, 21);
            this.authCodeBox.TabIndex = 11;
            this.authCodeBox.KeyPress += this.only_digit_Event;
            // 
            // eMailBox
            // 
            this.eMailBox.Location = new System.Drawing.Point(110, 18);
            this.eMailBox.MaxLength = 50;
            this.eMailBox.Name = "eMailBox";
            this.eMailBox.Size = new System.Drawing.Size(246, 21);
            this.eMailBox.TabIndex = 0;
            this.eMailBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // FormRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Name = "FormRegister";
            this.Text = "FormRegister";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.TextBox rePasswordBox;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.TextBox authCodeBox;
        private System.Windows.Forms.TextBox eMailBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button send_auth_mail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox CardFourthBox;
        private System.Windows.Forms.Button registerBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.ComboBox cardDrop;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox CardThirdBox;
        private System.Windows.Forms.TextBox CardSecondBox;
        private System.Windows.Forms.TextBox CardFirstBox;
        private System.Windows.Forms.ComboBox phoneDrop;
        private System.Windows.Forms.TextBox phoneLastBox;
        private System.Windows.Forms.TextBox phoneMiddleBox;
    }
}