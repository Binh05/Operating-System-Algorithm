namespace CK_HDH
{
    partial class Dish_SchedulingForm
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
            this.Exit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbRR = new System.Windows.Forms.RadioButton();
            this.rdbSRT = new System.Windows.Forms.RadioButton();
            this.rdbSJF = new System.Windows.Forms.RadioButton();
            this.rdbFCFS = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvInput = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvOutput = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnRunFCFS = new System.Windows.Forms.Button();
            this.btnAddProcess = new System.Windows.Forms.Button();
            this.btnRemoveProcess = new System.Windows.Forms.Button();
            this.pnGantt = new System.Windows.Forms.FlowLayoutPanel();
            this.dgvAVG = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInput)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOutput)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAVG)).BeginInit();
            this.SuspendLayout();
            // 
            // Exit
            // 
            this.Exit.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Exit.Location = new System.Drawing.Point(771, 14);
            this.Exit.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(108, 48);
            this.Exit.TabIndex = 1;
            this.Exit.Text = "Thoát";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbRR);
            this.groupBox1.Controls.Add(this.rdbSRT);
            this.groupBox1.Controls.Add(this.rdbSJF);
            this.groupBox1.Controls.Add(this.rdbFCFS);
            this.groupBox1.Location = new System.Drawing.Point(27, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(340, 49);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Giải thuật định thời";
            // 
            // rdbRR
            // 
            this.rdbRR.AutoSize = true;
            this.rdbRR.Location = new System.Drawing.Point(267, 19);
            this.rdbRR.Name = "rdbRR";
            this.rdbRR.Size = new System.Drawing.Size(43, 20);
            this.rdbRR.TabIndex = 3;
            this.rdbRR.TabStop = true;
            this.rdbRR.Text = "RR";
            this.rdbRR.UseVisualStyleBackColor = true;
            this.rdbRR.CheckedChanged += new System.EventHandler(this.rdbRR_CheckedChanged);
            // 
            // rdbSRT
            // 
            this.rdbSRT.AutoSize = true;
            this.rdbSRT.Location = new System.Drawing.Point(184, 19);
            this.rdbSRT.Name = "rdbSRT";
            this.rdbSRT.Size = new System.Drawing.Size(50, 20);
            this.rdbSRT.TabIndex = 2;
            this.rdbSRT.TabStop = true;
            this.rdbSRT.Text = "SRT";
            this.rdbSRT.UseVisualStyleBackColor = true;
            this.rdbSRT.CheckedChanged += new System.EventHandler(this.rdbSRT_CheckedChanged);
            // 
            // rdbSJF
            // 
            this.rdbSJF.AutoSize = true;
            this.rdbSJF.Location = new System.Drawing.Point(108, 19);
            this.rdbSJF.Name = "rdbSJF";
            this.rdbSJF.Size = new System.Drawing.Size(47, 20);
            this.rdbSJF.TabIndex = 1;
            this.rdbSJF.TabStop = true;
            this.rdbSJF.Text = "SJF";
            this.rdbSJF.UseVisualStyleBackColor = true;
            this.rdbSJF.CheckedChanged += new System.EventHandler(this.rdbSJF_CheckedChanged);
            // 
            // rdbFCFS
            // 
            this.rdbFCFS.AutoSize = true;
            this.rdbFCFS.Location = new System.Drawing.Point(23, 19);
            this.rdbFCFS.Name = "rdbFCFS";
            this.rdbFCFS.Size = new System.Drawing.Size(58, 20);
            this.rdbFCFS.TabIndex = 0;
            this.rdbFCFS.TabStop = true;
            this.rdbFCFS.Text = "FCFS";
            this.rdbFCFS.UseVisualStyleBackColor = true;
            this.rdbFCFS.CheckedChanged += new System.EventHandler(this.rdbFCFS_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvInput);
            this.groupBox2.Location = new System.Drawing.Point(32, 84);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(499, 318);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Input";
            // 
            // dgvInput
            // 
            this.dgvInput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInput.Location = new System.Drawing.Point(6, 61);
            this.dgvInput.Name = "dgvInput";
            this.dgvInput.Size = new System.Drawing.Size(489, 251);
            this.dgvInput.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvAVG);
            this.groupBox3.Controls.Add(this.dgvOutput);
            this.groupBox3.Location = new System.Drawing.Point(537, 84);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(350, 317);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Result";
            // 
            // dgvOutput
            // 
            this.dgvOutput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOutput.Location = new System.Drawing.Point(6, 60);
            this.dgvOutput.Name = "dgvOutput";
            this.dgvOutput.Size = new System.Drawing.Size(336, 178);
            this.dgvOutput.TabIndex = 1;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.pnGantt);
            this.groupBox4.Location = new System.Drawing.Point(32, 421);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(854, 94);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Gantt";
            // 
            // btnRunFCFS
            // 
            this.btnRunFCFS.Location = new System.Drawing.Point(648, 14);
            this.btnRunFCFS.Name = "btnRunFCFS";
            this.btnRunFCFS.Size = new System.Drawing.Size(108, 48);
            this.btnRunFCFS.TabIndex = 6;
            this.btnRunFCFS.Text = "Chạy";
            this.btnRunFCFS.UseVisualStyleBackColor = true;
            this.btnRunFCFS.Click += new System.EventHandler(this.btnRunFCFS_Click);
            // 
            // btnAddProcess
            // 
            this.btnAddProcess.Location = new System.Drawing.Point(402, 14);
            this.btnAddProcess.Name = "btnAddProcess";
            this.btnAddProcess.Size = new System.Drawing.Size(108, 48);
            this.btnAddProcess.TabIndex = 7;
            this.btnAddProcess.Text = "Thêm tiến trình";
            this.btnAddProcess.UseVisualStyleBackColor = true;
            this.btnAddProcess.Click += new System.EventHandler(this.btnAddProcess_Click);
            // 
            // btnRemoveProcess
            // 
            this.btnRemoveProcess.Location = new System.Drawing.Point(525, 14);
            this.btnRemoveProcess.Name = "btnRemoveProcess";
            this.btnRemoveProcess.Size = new System.Drawing.Size(108, 48);
            this.btnRemoveProcess.TabIndex = 8;
            this.btnRemoveProcess.Text = "Xóa tiến trình";
            this.btnRemoveProcess.UseVisualStyleBackColor = true;
            this.btnRemoveProcess.Click += new System.EventHandler(this.btnRemoveProcess_Click);
            // 
            // pnGantt
            // 
            this.pnGantt.Location = new System.Drawing.Point(6, 22);
            this.pnGantt.Name = "pnGantt";
            this.pnGantt.Size = new System.Drawing.Size(841, 53);
            this.pnGantt.TabIndex = 1;
            // 
            // dgvAVG
            // 
            this.dgvAVG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAVG.Location = new System.Drawing.Point(6, 244);
            this.dgvAVG.Name = "dgvAVG";
            this.dgvAVG.Size = new System.Drawing.Size(336, 68);
            this.dgvAVG.TabIndex = 2;
            // 
            // Dish_SchedulingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 534);
            this.Controls.Add(this.btnRemoveProcess);
            this.Controls.Add(this.btnAddProcess);
            this.Controls.Add(this.btnRunFCFS);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Exit);
            this.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Dish_SchedulingForm";
            this.Text = "Dish Scheduling";
            this.Load += new System.EventHandler(this.Dish_SchedulingForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInput)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOutput)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAVG)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbSRT;
        private System.Windows.Forms.RadioButton rdbSJF;
        private System.Windows.Forms.RadioButton rdbFCFS;
        private System.Windows.Forms.RadioButton rdbRR;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvInput;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dgvOutput;
        private System.Windows.Forms.Button btnRunFCFS;
        private System.Windows.Forms.Button btnAddProcess;
        private System.Windows.Forms.Button btnRemoveProcess;
        private System.Windows.Forms.FlowLayoutPanel pnGantt;
        private System.Windows.Forms.DataGridView dgvAVG;
    }
}