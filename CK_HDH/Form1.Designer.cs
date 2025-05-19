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
            this.Dish_Scheduling = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Banker
            // 
            this.Banker.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Banker.Location = new System.Drawing.Point(51, 107);
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
            this.CPU_Distribution.Location = new System.Drawing.Point(272, 107);
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
            this.Page_Replacement.Location = new System.Drawing.Point(469, 107);
            this.Page_Replacement.Margin = new System.Windows.Forms.Padding(4);
            this.Page_Replacement.Name = "Page_Replacement";
            this.Page_Replacement.Size = new System.Drawing.Size(177, 51);
            this.Page_Replacement.TabIndex = 2;
            this.Page_Replacement.Text = "Page Replacement";
            this.Page_Replacement.UseVisualStyleBackColor = true;
            this.Page_Replacement.Click += new System.EventHandler(this.button3_Click);
            // 
            // Dish_Scheduling
            // 
            this.Dish_Scheduling.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Dish_Scheduling.Location = new System.Drawing.Point(679, 107);
            this.Dish_Scheduling.Margin = new System.Windows.Forms.Padding(4);
            this.Dish_Scheduling.Name = "Dish_Scheduling";
            this.Dish_Scheduling.Size = new System.Drawing.Size(166, 51);
            this.Dish_Scheduling.TabIndex = 3;
            this.Dish_Scheduling.Text = "Dish Scheduling";
            this.Dish_Scheduling.UseVisualStyleBackColor = true;
            this.Dish_Scheduling.Click += new System.EventHandler(this.Dish_Scheduling_Click);
            // 
            // Exit
            // 
            this.Exit.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Exit.Location = new System.Drawing.Point(623, 398);
            this.Exit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(165, 53);
            this.Exit.TabIndex = 4;
            this.Exit.Text = "Thoát";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 535);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.Dish_Scheduling);
            this.Controls.Add(this.Page_Replacement);
            this.Controls.Add(this.CPU_Distribution);
            this.Controls.Add(this.Banker);
            this.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button Banker;
        private System.Windows.Forms.Button CPU_Distribution;
        private System.Windows.Forms.Button Page_Replacement;
        private System.Windows.Forms.Button Dish_Scheduling;
        private System.Windows.Forms.Button Exit;
    }
}

