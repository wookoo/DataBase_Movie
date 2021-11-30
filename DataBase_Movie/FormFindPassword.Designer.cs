
namespace DataBase_Movie
{
    partial class FormFindPassword
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
            this.resetBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.send_auth_mail = new System.Windows.Forms.Button();
            this.rePasswordBox = new System.Windows.Forms.TextBox();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.authCodeBox = new System.Windows.Forms.TextBox();
            this.eMailBox = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.resetBtn);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.send_auth_mail);
            this.panel1.Controls.Add(this.rePasswordBox);
            this.panel1.Controls.Add(this.passwordBox);
            this.panel1.Controls.Add(this.authCodeBox);
            this.panel1.Controls.Add(this.eMailBox);
            this.panel1.Location = new System.Drawing.Point(12, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(447, 220);
            this.panel1.TabIndex = 1;
            // 
            // resetBtn
            // 
            this.resetBtn.Location = new System.Drawing.Point(110, 178);
            this.resetBtn.Name = "resetBtn";
            this.resetBtn.Size = new System.Drawing.Size(246, 20);
            this.resetBtn.TabIndex = 14;
            this.resetBtn.Text = "비밀번호 변경";
            this.resetBtn.UseVisualStyleBackColor = true;
            this.resetBtn.Click += new System.EventHandler(this.resetBtn_Click);
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
            this.label3.Location = new System.Drawing.Point(35, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "새 비밀번호";
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
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "이메일";
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
            // 
            // eMailBox
            // 
            this.eMailBox.Location = new System.Drawing.Point(110, 18);
            this.eMailBox.MaxLength = 50;
            this.eMailBox.Name = "eMailBox";
            this.eMailBox.Size = new System.Drawing.Size(246, 21);
            this.eMailBox.TabIndex = 0;
            // 
            // FormFindPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 274);
            this.Controls.Add(this.panel1);
            this.Name = "FormFindPassword";
            this.Text = "FormFindPassword";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button resetBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button send_auth_mail;
        private System.Windows.Forms.TextBox rePasswordBox;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.TextBox authCodeBox;
        private System.Windows.Forms.TextBox eMailBox;
    }
}