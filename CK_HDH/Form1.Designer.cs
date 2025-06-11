namespace CK_HDH
{
    partial class Form1
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.Banker = new System.Windows.Forms.Button();
            this.CPU_Distribution = new System.Windows.Forms.Button();
            this.Page_Replacement = new System.Windows.Forms.Button();
            this.Disk_Scheduling = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Banker
            // 
            this.Banker.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Banker.Location = new System.Drawing.Point(35, 56);
            this.Banker.Margin = new System.Windows.Forms.Padding(4);
            this.Banker.Name = "Banker";
            this.Banker.Size = new System.Drawing.Size(190, 51);
            this.Banker.TabIndex = 0;
            this.Banker.Text = "Banker and Deadlock";
            this.Banker.UseVisualStyleBackColor = true;
            this.Banker.Click += new System.EventHandler(this.button1_Click);
            // 
            // CPU_Distribution
            // 
            this.CPU_Distribution.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CPU_Distribution.Location = new System.Drawing.Point(233, 56);
            this.CPU_Distribution.Margin = new System.Windows.Forms.Padding(4);
            this.CPU_Distribution.Name = "CPU_Distribution";
            this.CPU_Distribution.Size = new System.Drawing.Size(166, 51);
            this.CPU_Distribution.TabIndex = 1;
            this.CPU_Distribution.Text = "CPU Distribution";
            this.CPU_Distribution.UseVisualStyleBackColor = true;
            this.CPU_Distribution.Click += new System.EventHandler(this.CPU_Distribution_Click);
            // 
            // Page_Replacement
            // 
            this.Page_Replacement.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Page_Replacement.Location = new System.Drawing.Point(407, 56);
            this.Page_Replacement.Margin = new System.Windows.Forms.Padding(4);
            this.Page_Replacement.Name = "Page_Replacement";
            this.Page_Replacement.Size = new System.Drawing.Size(177, 51);
            this.Page_Replacement.TabIndex = 2;
            this.Page_Replacement.Text = "Page Replacement";
            this.Page_Replacement.UseVisualStyleBackColor = true;
            this.Page_Replacement.Click += new System.EventHandler(this.button3_Click);
            // 
            // Disk_Scheduling
            // 
            this.Disk_Scheduling.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Disk_Scheduling.Location = new System.Drawing.Point(592, 56);
            this.Disk_Scheduling.Margin = new System.Windows.Forms.Padding(4);
            this.Disk_Scheduling.Name = "Disk_Scheduling";
            this.Disk_Scheduling.Size = new System.Drawing.Size(166, 51);
            this.Disk_Scheduling.TabIndex = 3;
            this.Disk_Scheduling.Text = "Disk Scheduling";
            this.Disk_Scheduling.UseVisualStyleBackColor = true;
            this.Disk_Scheduling.Click += new System.EventHandler(this.Dish_Scheduling_Click);
            // 
            // Exit
            // 
            this.Exit.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Exit.Location = new System.Drawing.Point(658, 369);
            this.Exit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(165, 53);
            this.Exit.TabIndex = 4;
            this.Exit.Text = "Thoát";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Navy;
            this.label4.Location = new System.Drawing.Point(233, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(613, 42);
            this.label4.TabIndex = 5;
            this.label4.Text = "Các Thuật Toán Trong Hệ Điều Hành";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Page_Replacement);
            this.groupBox1.Controls.Add(this.Banker);
            this.groupBox1.Controls.Add(this.Disk_Scheduling);
            this.groupBox1.Controls.Add(this.CPU_Distribution);
            this.groupBox1.Location = new System.Drawing.Point(65, 151);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(793, 153);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 535);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Exit);
            this.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button Banker;
        private System.Windows.Forms.Button CPU_Distribution;
        private System.Windows.Forms.Button Page_Replacement;
        private System.Windows.Forms.Button Disk_Scheduling;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

