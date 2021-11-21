
namespace DataBase_Movie
{
    partial class FormFindAccount
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
            this.cancelBtn = new System.Windows.Forms.Button();
            this.findAccountBtn = new System.Windows.Forms.Button();
            this.phoneLastBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.phoneMiddleBox = new System.Windows.Forms.TextBox();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.phoneDrop = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cancelBtn);
            this.panel1.Controls.Add(this.findAccountBtn);
            this.panel1.Controls.Add(this.phoneLastBox);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.phoneMiddleBox);
            this.panel1.Controls.Add(this.nameBox);
            this.panel1.Controls.Add(this.phoneDrop);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Location = new System.Drawing.Point(217, 127);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(343, 188);
            this.panel1.TabIndex = 0;
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(85, 151);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(192, 18);
            this.cancelBtn.TabIndex = 30;
            this.cancelBtn.Text = "취소";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // findAccountBtn
            // 
            this.findAccountBtn.Location = new System.Drawing.Point(84, 120);
            this.findAccountBtn.Name = "findAccountBtn";
            this.findAccountBtn.Size = new System.Drawing.Size(193, 20);
            this.findAccountBtn.TabIndex = 29;
            this.findAccountBtn.Text = "계정찾기";
            this.findAccountBtn.UseVisualStyleBackColor = true;
            this.findAccountBtn.Click += new System.EventHandler(this.findAccountBtn_Click);
            // 
            // phoneLastBox
            // 
            this.phoneLastBox.Location = new System.Drawing.Point(220, 78);
            this.phoneLastBox.MaxLength = 4;
            this.phoneLastBox.Name = "phoneLastBox";
            this.phoneLastBox.Size = new System.Drawing.Size(57, 21);
            this.phoneLastBox.TabIndex = 28;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(49, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "이름";
            // 
            // phoneMiddleBox
            // 
            this.phoneMiddleBox.Location = new System.Drawing.Point(157, 78);
            this.phoneMiddleBox.MaxLength = 4;
            this.phoneMiddleBox.Name = "phoneMiddleBox";
            this.phoneMiddleBox.Size = new System.Drawing.Size(57, 21);
            this.phoneMiddleBox.TabIndex = 27;
            this.phoneMiddleBox.TextChanged += new System.EventHandler(this.phoneMiddleBox_TextChanged);
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(84, 47);
            this.nameBox.MaxLength = 4;
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(193, 21);
            this.nameBox.TabIndex = 11;
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
            this.phoneDrop.Location = new System.Drawing.Point(84, 79);
            this.phoneDrop.Name = "phoneDrop";
            this.phoneDrop.Size = new System.Drawing.Size(67, 20);
            this.phoneDrop.TabIndex = 26;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 82);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 25;
            this.label7.Text = "전화번호";
            // 
            // FormFindAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Name = "FormFindAccount";
            this.Text = "FormFindAccount";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.TextBox phoneLastBox;
        private System.Windows.Forms.TextBox phoneMiddleBox;
        private System.Windows.Forms.ComboBox phoneDrop;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button findAccountBtn;
        private System.Windows.Forms.Button cancelBtn;
    }
}