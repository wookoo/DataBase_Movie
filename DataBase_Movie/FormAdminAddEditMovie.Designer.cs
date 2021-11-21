
namespace DataBase_Movie
{
    partial class FormAdminAddEditMovie
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.titleBox = new System.Windows.Forms.TextBox();
            this.directorBox = new System.Windows.Forms.TextBox();
            this.actorBox = new System.Windows.Forms.TextBox();
            this.timeBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.saveBtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.saveBtn);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.timeBox);
            this.panel1.Controls.Add(this.actorBox);
            this.panel1.Controls.Add(this.directorBox);
            this.panel1.Controls.Add(this.titleBox);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(23, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(303, 372);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(172, 195);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(191, 174);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 24);
            this.button1.TabIndex = 1;
            this.button1.Text = "이미지 불러오기";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // titleBox
            // 
            this.titleBox.Location = new System.Drawing.Point(79, 214);
            this.titleBox.Name = "titleBox";
            this.titleBox.Size = new System.Drawing.Size(213, 21);
            this.titleBox.TabIndex = 2;
            // 
            // directorBox
            // 
            this.directorBox.Location = new System.Drawing.Point(79, 241);
            this.directorBox.Name = "directorBox";
            this.directorBox.Size = new System.Drawing.Size(213, 21);
            this.directorBox.TabIndex = 3;
            // 
            // actorBox
            // 
            this.actorBox.Location = new System.Drawing.Point(79, 268);
            this.actorBox.Name = "actorBox";
            this.actorBox.Size = new System.Drawing.Size(213, 21);
            this.actorBox.TabIndex = 4;
            // 
            // timeBox
            // 
            this.timeBox.Location = new System.Drawing.Point(79, 295);
            this.timeBox.Name = "timeBox";
            this.timeBox.Size = new System.Drawing.Size(213, 21);
            this.timeBox.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 217);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "제목";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 244);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "감독";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 271);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "주연배우";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 298);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "상영시간";
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(15, 334);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(277, 23);
            this.saveBtn.TabIndex = 10;
            this.saveBtn.Text = "저장하기";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // FormAdminAddEditMovie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 417);
            this.Controls.Add(this.panel1);
            this.Name = "FormAdminAddEditMovie";
            this.Text = "FormAdminAddEditMovie";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox timeBox;
        private System.Windows.Forms.TextBox actorBox;
        private System.Windows.Forms.TextBox directorBox;
        private System.Windows.Forms.TextBox titleBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}