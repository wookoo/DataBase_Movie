
namespace DataBase_Movie
{
    partial class FormAdminEditGrade
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
            this.label2 = new System.Windows.Forms.Label();
            this.gradeListBox = new System.Windows.Forms.ListBox();
            this.emailListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.gradeListBox);
            this.panel1.Controls.Add(this.emailListBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(2, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(414, 330);
            this.panel1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(204, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "변경전 등급";
            this.label2.Click += new System.EventHandler(this.label2_Click_1);
            // 
            // gradeListBox
            // 
            this.gradeListBox.FormattingEnabled = true;
            this.gradeListBox.ItemHeight = 12;
            this.gradeListBox.Location = new System.Drawing.Point(206, 68);
            this.gradeListBox.Name = "gradeListBox";
            this.gradeListBox.Size = new System.Drawing.Size(174, 136);
            this.gradeListBox.TabIndex = 2;
            this.gradeListBox.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
            // 
            // emailListBox
            // 
            this.emailListBox.FormattingEnabled = true;
            this.emailListBox.ItemHeight = 12;
            this.emailListBox.Location = new System.Drawing.Point(26, 68);
            this.emailListBox.Name = "emailListBox";
            this.emailListBox.Size = new System.Drawing.Size(174, 136);
            this.emailListBox.TabIndex = 1;
            this.emailListBox.SelectedIndexChanged += new System.EventHandler(this.emailListBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "계정";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(34, 241);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(345, 36);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // FormAdminEditGrade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 375);
            this.Controls.Add(this.panel1);
            this.Name = "FormAdminEditGrade";
            this.Text = "FormAdminEditGrade";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox gradeListBox;
        private System.Windows.Forms.ListBox emailListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}