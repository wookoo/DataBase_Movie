
namespace DataBase_Movie
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.findIDBtn = new System.Windows.Forms.Button();
            this.findPasswordBtn = new System.Windows.Forms.Button();
            this.registerBtn = new System.Windows.Forms.Button();
            this.loginBtn = new System.Windows.Forms.Button();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.idTextBox = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.findIDBtn);
            this.panel1.Controls.Add(this.findPasswordBtn);
            this.panel1.Controls.Add(this.registerBtn);
            this.panel1.Controls.Add(this.loginBtn);
            this.panel1.Controls.Add(this.passwordTextBox);
            this.panel1.Controls.Add(this.idTextBox);
            this.panel1.Location = new System.Drawing.Point(152, 78);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(497, 303);
            this.panel1.TabIndex = 0;
            // 
            // findIDBtn
            // 
            this.findIDBtn.Location = new System.Drawing.Point(126, 171);
            this.findIDBtn.Name = "findIDBtn";
            this.findIDBtn.Size = new System.Drawing.Size(86, 33);
            this.findIDBtn.TabIndex = 5;
            this.findIDBtn.Text = "아이디찾기";
            this.findIDBtn.UseVisualStyleBackColor = true;
            // 
            // findPasswordBtn
            // 
            this.findPasswordBtn.Location = new System.Drawing.Point(237, 171);
            this.findPasswordBtn.Name = "findPasswordBtn";
            this.findPasswordBtn.Size = new System.Drawing.Size(88, 32);
            this.findPasswordBtn.TabIndex = 4;
            this.findPasswordBtn.Text = "비밀번호찾기";
            this.findPasswordBtn.UseVisualStyleBackColor = true;
            this.findPasswordBtn.Click += new System.EventHandler(this.findPassBTN_Click);
            // 
            // registerBtn
            // 
            this.registerBtn.Location = new System.Drawing.Point(126, 120);
            this.registerBtn.Name = "registerBtn";
            this.registerBtn.Size = new System.Drawing.Size(199, 33);
            this.registerBtn.TabIndex = 3;
            this.registerBtn.Text = "회원가입";
            this.registerBtn.UseVisualStyleBackColor = true;
            this.registerBtn.Click += new System.EventHandler(this.registerBTN_Click);
            // 
            // loginBtn
            // 
            this.loginBtn.Location = new System.Drawing.Point(345, 54);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(97, 64);
            this.loginBtn.TabIndex = 2;
            this.loginBtn.Text = "로그인";
            this.loginBtn.UseVisualStyleBackColor = true;
            this.loginBtn.Click += new System.EventHandler(this.loginBTN_Click);
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(126, 93);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(199, 21);
            this.passwordTextBox.TabIndex = 1;
            this.passwordTextBox.TextChanged += new System.EventHandler(this.passwordTextBox_TextChanged);
            // 
            // idTextBox
            // 
            this.idTextBox.Location = new System.Drawing.Point(126, 54);
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.Size = new System.Drawing.Size(199, 21);
            this.idTextBox.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button loginBtn;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.TextBox idTextBox;
        private System.Windows.Forms.Button findPasswordBtn;
        private System.Windows.Forms.Button registerBtn;
        private System.Windows.Forms.Button findIDBtn;
    }
}

