
namespace DataBase_Movie
{
    partial class FormUserProfile
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.emailBox = new System.Windows.Forms.Label();
            this.phoneLastBox = new System.Windows.Forms.TextBox();
            this.phoneMiddleBox = new System.Windows.Forms.TextBox();
            this.phoneDrop = new System.Windows.Forms.ComboBox();
            this.CardThirdBox = new System.Windows.Forms.TextBox();
            this.CardSecondBox = new System.Windows.Forms.TextBox();
            this.CardFirstBox = new System.Windows.Forms.TextBox();
            this.cardDrop = new System.Windows.Forms.ComboBox();
            this.CardFourthBox = new System.Windows.Forms.TextBox();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.pride = new System.Windows.Forms.Label();
            this.discount = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.discount);
            this.panel1.Controls.Add(this.pride);
            this.panel1.Controls.Add(this.phoneLastBox);
            this.panel1.Controls.Add(this.phoneMiddleBox);
            this.panel1.Controls.Add(this.phoneDrop);
            this.panel1.Controls.Add(this.CardThirdBox);
            this.panel1.Controls.Add(this.CardSecondBox);
            this.panel1.Controls.Add(this.CardFirstBox);
            this.panel1.Controls.Add(this.cardDrop);
            this.panel1.Controls.Add(this.CardFourthBox);
            this.panel1.Controls.Add(this.nameBox);
            this.panel1.Controls.Add(this.emailBox);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(36, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(446, 278);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "아이디";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "이름";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "전화번호";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "카드번호";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(48, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "등급";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(36, 189);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "할인율";
            // 
            // emailBox
            // 
            this.emailBox.AutoSize = true;
            this.emailBox.Location = new System.Drawing.Point(90, 29);
            this.emailBox.Name = "emailBox";
            this.emailBox.Size = new System.Drawing.Size(38, 12);
            this.emailBox.TabIndex = 9;
            this.emailBox.Text = "label7";
            // 
            // phoneLastBox
            // 
            this.phoneLastBox.Location = new System.Drawing.Point(227, 90);
            this.phoneLastBox.MaxLength = 4;
            this.phoneLastBox.Name = "phoneLastBox";
            this.phoneLastBox.Size = new System.Drawing.Size(57, 21);
            this.phoneLastBox.TabIndex = 33;
            // 
            // phoneMiddleBox
            // 
            this.phoneMiddleBox.Location = new System.Drawing.Point(164, 90);
            this.phoneMiddleBox.MaxLength = 4;
            this.phoneMiddleBox.Name = "phoneMiddleBox";
            this.phoneMiddleBox.Size = new System.Drawing.Size(57, 21);
            this.phoneMiddleBox.TabIndex = 32;
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
            this.phoneDrop.Location = new System.Drawing.Point(91, 91);
            this.phoneDrop.Name = "phoneDrop";
            this.phoneDrop.Size = new System.Drawing.Size(67, 20);
            this.phoneDrop.TabIndex = 31;
            // 
            // CardThirdBox
            // 
            this.CardThirdBox.Location = new System.Drawing.Point(290, 121);
            this.CardThirdBox.MaxLength = 4;
            this.CardThirdBox.Name = "CardThirdBox";
            this.CardThirdBox.Size = new System.Drawing.Size(57, 21);
            this.CardThirdBox.TabIndex = 30;
            // 
            // CardSecondBox
            // 
            this.CardSecondBox.Location = new System.Drawing.Point(227, 122);
            this.CardSecondBox.MaxLength = 4;
            this.CardSecondBox.Name = "CardSecondBox";
            this.CardSecondBox.Size = new System.Drawing.Size(57, 21);
            this.CardSecondBox.TabIndex = 29;
            // 
            // CardFirstBox
            // 
            this.CardFirstBox.Location = new System.Drawing.Point(164, 122);
            this.CardFirstBox.MaxLength = 4;
            this.CardFirstBox.Name = "CardFirstBox";
            this.CardFirstBox.Size = new System.Drawing.Size(57, 21);
            this.CardFirstBox.TabIndex = 28;
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
            this.cardDrop.Location = new System.Drawing.Point(91, 122);
            this.cardDrop.Name = "cardDrop";
            this.cardDrop.Size = new System.Drawing.Size(67, 20);
            this.cardDrop.TabIndex = 27;
            // 
            // CardFourthBox
            // 
            this.CardFourthBox.Location = new System.Drawing.Point(353, 120);
            this.CardFourthBox.MaxLength = 4;
            this.CardFourthBox.Name = "CardFourthBox";
            this.CardFourthBox.Size = new System.Drawing.Size(57, 21);
            this.CardFourthBox.TabIndex = 26;
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(92, 61);
            this.nameBox.MaxLength = 4;
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(246, 21);
            this.nameBox.TabIndex = 25;
            // 
            // pride
            // 
            this.pride.AutoSize = true;
            this.pride.Location = new System.Drawing.Point(90, 160);
            this.pride.Name = "pride";
            this.pride.Size = new System.Drawing.Size(38, 12);
            this.pride.TabIndex = 34;
            this.pride.Text = "label7";
            // 
            // discount
            // 
            this.discount.AutoSize = true;
            this.discount.Location = new System.Drawing.Point(90, 189);
            this.discount.Name = "discount";
            this.discount.Size = new System.Drawing.Size(38, 12);
            this.discount.TabIndex = 35;
            this.discount.Text = "label7";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(91, 214);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(327, 23);
            this.button1.TabIndex = 36;
            this.button1.Text = "수정하기";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(91, 243);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(327, 23);
            this.button2.TabIndex = 37;
            this.button2.Text = "회원탈퇴";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // FormUserProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Name = "FormUserProfile";
            this.Text = "FormUserProfile";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label emailBox;
        private System.Windows.Forms.Label discount;
        private System.Windows.Forms.Label pride;
        private System.Windows.Forms.TextBox phoneLastBox;
        private System.Windows.Forms.TextBox phoneMiddleBox;
        private System.Windows.Forms.ComboBox phoneDrop;
        private System.Windows.Forms.TextBox CardThirdBox;
        private System.Windows.Forms.TextBox CardSecondBox;
        private System.Windows.Forms.TextBox CardFirstBox;
        private System.Windows.Forms.ComboBox cardDrop;
        private System.Windows.Forms.TextBox CardFourthBox;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}