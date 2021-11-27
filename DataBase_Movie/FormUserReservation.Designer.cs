
namespace DataBase_Movie
{
    partial class FormUserReservation
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.titleBox = new System.Windows.Forms.Label();
            this.timeBox = new System.Windows.Forms.Label();
            this.actorBox = new System.Windows.Forms.Label();
            this.directorBox = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.titleBox);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.timeBox);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.actorBox);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.directorBox);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Location = new System.Drawing.Point(32, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(570, 376);
            this.panel1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(354, 261);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // titleBox
            // 
            this.titleBox.AutoSize = true;
            this.titleBox.Location = new System.Drawing.Point(445, 228);
            this.titleBox.Name = "titleBox";
            this.titleBox.Size = new System.Drawing.Size(44, 12);
            this.titleBox.TabIndex = 29;
            this.titleBox.Text = "label12";
            // 
            // timeBox
            // 
            this.timeBox.AutoSize = true;
            this.timeBox.Location = new System.Drawing.Point(445, 307);
            this.timeBox.Name = "timeBox";
            this.timeBox.Size = new System.Drawing.Size(44, 12);
            this.timeBox.TabIndex = 28;
            this.timeBox.Text = "label11";
            // 
            // actorBox
            // 
            this.actorBox.AutoSize = true;
            this.actorBox.Location = new System.Drawing.Point(445, 282);
            this.actorBox.Name = "actorBox";
            this.actorBox.Size = new System.Drawing.Size(44, 12);
            this.actorBox.TabIndex = 27;
            this.actorBox.Text = "label10";
            // 
            // directorBox
            // 
            this.directorBox.AutoSize = true;
            this.directorBox.Location = new System.Drawing.Point(445, 256);
            this.directorBox.Name = "directorBox";
            this.directorBox.Size = new System.Drawing.Size(38, 12);
            this.directorBox.TabIndex = 26;
            this.directorBox.Text = "label9";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(377, 282);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 25;
            this.label5.Text = "주연배우";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(377, 307);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 24;
            this.label8.Text = "상영시간";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(377, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(181, 196);
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(377, 256);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 23;
            this.label7.Text = "감독";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(377, 228);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 22;
            this.label6.Text = "제목";
            // 
            // FormUserReservation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 443);
            this.Controls.Add(this.panel1);
            this.Name = "FormUserReservation";
            this.Text = "FormUserReservation";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label titleBox;
        private System.Windows.Forms.Label timeBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label actorBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label directorBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
    }
}