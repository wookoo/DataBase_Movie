﻿
namespace DataBase_Movie
{
    partial class FormAdminMain
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
            this.editAccount = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // editAccount
            // 
            this.editAccount.Location = new System.Drawing.Point(71, 149);
            this.editAccount.Name = "editAccount";
            this.editAccount.Size = new System.Drawing.Size(125, 96);
            this.editAccount.TabIndex = 0;
            this.editAccount.Text = "회원 관리";
            this.editAccount.UseVisualStyleBackColor = true;
            this.editAccount.Click += new System.EventHandler(this.editAccount_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(240, 149);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(135, 95);
            this.button2.TabIndex = 1;
            this.button2.Text = "등급 관리";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(421, 151);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(122, 93);
            this.button3.TabIndex = 2;
            this.button3.Text = "영화 관리";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(583, 152);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(122, 93);
            this.button4.TabIndex = 3;
            this.button4.Text = "상영스케줄 관리";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // FormAdminMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.editAccount);
            this.Name = "FormAdminMain";
            this.Text = "FormAdminMain";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button editAccount;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}