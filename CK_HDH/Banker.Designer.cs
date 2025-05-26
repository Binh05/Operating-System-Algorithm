namespace CK_HDH
{
    partial class BankerForm
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
            this.btnAddCol = new System.Windows.Forms.Button();
            this.btnAddRow = new System.Windows.Forms.Button();
            this.btnRemoveRow = new System.Windows.Forms.Button();
            this.btnRemoveCol = new System.Windows.Forms.Button();
            this.btnRunSafe = new System.Windows.Forms.Button();
            this.grbProcessSafe = new System.Windows.Forms.GroupBox();
            this.lblAvailable = new System.Windows.Forms.Label();
            this.lblAllocation = new System.Windows.Forms.Label();
            this.lblMax = new System.Windows.Forms.Label();
            this.dgvAvailable = new System.Windows.Forms.DataGridView();
            this.dgvAllocation = new System.Windows.Forms.DataGridView();
            this.dgvMax = new System.Windows.Forms.DataGridView();
            this.grbSafe = new System.Windows.Forms.GroupBox();
            this.rtxtSafeStatus = new System.Windows.Forms.RichTextBox();
            this.lblWork = new System.Windows.Forms.Label();
            this.lblNeed = new System.Windows.Forms.Label();
            this.dgvWork = new System.Windows.Forms.DataGridView();
            this.dgvNeed = new System.Windows.Forms.DataGridView();
            this.grbAlgoChoose = new System.Windows.Forms.GroupBox();
            this.rdbNone = new System.Windows.Forms.RadioButton();
            this.rdbMultiRequest = new System.Windows.Forms.RadioButton();
            this.rdbRequest = new System.Windows.Forms.RadioButton();
            this.grbRequest = new System.Windows.Forms.GroupBox();
            this.dgvRequestResource = new System.Windows.Forms.DataGridView();
            this.cbbRequest = new System.Windows.Forms.ComboBox();
            this.btnRequestResource = new System.Windows.Forms.Button();
            this.btnMultiRequest = new System.Windows.Forms.Button();
            this.grbProcessSafe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvailable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllocation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMax)).BeginInit();
            this.grbSafe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWork)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNeed)).BeginInit();
            this.grbAlgoChoose.SuspendLayout();
            this.grbRequest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequestResource)).BeginInit();
            this.SuspendLayout();
            // 
            // Exit
            // 
            this.Exit.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Exit.Location = new System.Drawing.Point(748, 13);
            this.Exit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(140, 38);
            this.Exit.TabIndex = 0;
            this.Exit.Text = "Thoát";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // btnAddCol
            // 
            this.btnAddCol.Location = new System.Drawing.Point(166, 13);
            this.btnAddCol.Name = "btnAddCol";
            this.btnAddCol.Size = new System.Drawing.Size(126, 38);
            this.btnAddCol.TabIndex = 1;
            this.btnAddCol.Text = "Thêm tài nguyên";
            this.btnAddCol.UseVisualStyleBackColor = true;
            this.btnAddCol.Click += new System.EventHandler(this.btnAddCol_Click);
            // 
            // btnAddRow
            // 
            this.btnAddRow.Location = new System.Drawing.Point(20, 13);
            this.btnAddRow.Name = "btnAddRow";
            this.btnAddRow.Size = new System.Drawing.Size(126, 38);
            this.btnAddRow.TabIndex = 2;
            this.btnAddRow.Text = "Thêm tiến trình";
            this.btnAddRow.UseVisualStyleBackColor = true;
            this.btnAddRow.Click += new System.EventHandler(this.btnAddRow_Click);
            // 
            // btnRemoveRow
            // 
            this.btnRemoveRow.Location = new System.Drawing.Point(318, 13);
            this.btnRemoveRow.Name = "btnRemoveRow";
            this.btnRemoveRow.Size = new System.Drawing.Size(126, 38);
            this.btnRemoveRow.TabIndex = 3;
            this.btnRemoveRow.Text = "Xóa tiến trình";
            this.btnRemoveRow.UseVisualStyleBackColor = true;
            this.btnRemoveRow.Click += new System.EventHandler(this.btnRemoveRow_Click);
            // 
            // btnRemoveCol
            // 
            this.btnRemoveCol.Location = new System.Drawing.Point(466, 13);
            this.btnRemoveCol.Name = "btnRemoveCol";
            this.btnRemoveCol.Size = new System.Drawing.Size(126, 38);
            this.btnRemoveCol.TabIndex = 4;
            this.btnRemoveCol.Text = "Xóa tài nguyên";
            this.btnRemoveCol.UseVisualStyleBackColor = true;
            this.btnRemoveCol.Click += new System.EventHandler(this.btnRemoveCol_Click);
            // 
            // btnRunSafe
            // 
            this.btnRunSafe.Location = new System.Drawing.Point(619, 13);
            this.btnRunSafe.Name = "btnRunSafe";
            this.btnRunSafe.Size = new System.Drawing.Size(105, 38);
            this.btnRunSafe.TabIndex = 5;
            this.btnRunSafe.Text = "Chạy";
            this.btnRunSafe.UseVisualStyleBackColor = true;
            this.btnRunSafe.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // grbProcessSafe
            // 
            this.grbProcessSafe.Controls.Add(this.lblAvailable);
            this.grbProcessSafe.Controls.Add(this.lblAllocation);
            this.grbProcessSafe.Controls.Add(this.lblMax);
            this.grbProcessSafe.Controls.Add(this.dgvAvailable);
            this.grbProcessSafe.Controls.Add(this.dgvAllocation);
            this.grbProcessSafe.Controls.Add(this.dgvMax);
            this.grbProcessSafe.Location = new System.Drawing.Point(12, 57);
            this.grbProcessSafe.Name = "grbProcessSafe";
            this.grbProcessSafe.Size = new System.Drawing.Size(601, 414);
            this.grbProcessSafe.TabIndex = 6;
            this.grbProcessSafe.TabStop = false;
            this.grbProcessSafe.Text = "Tiến trình";
            // 
            // lblAvailable
            // 
            this.lblAvailable.AutoSize = true;
            this.lblAvailable.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvailable.Location = new System.Drawing.Point(469, 14);
            this.lblAvailable.Name = "lblAvailable";
            this.lblAvailable.Size = new System.Drawing.Size(71, 19);
            this.lblAvailable.TabIndex = 5;
            this.lblAvailable.Text = "Available";
            // 
            // lblAllocation
            // 
            this.lblAllocation.AutoSize = true;
            this.lblAllocation.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAllocation.Location = new System.Drawing.Point(296, 14);
            this.lblAllocation.Name = "lblAllocation";
            this.lblAllocation.Size = new System.Drawing.Size(76, 19);
            this.lblAllocation.TabIndex = 4;
            this.lblAllocation.Text = "Allocation";
            // 
            // lblMax
            // 
            this.lblMax.AutoSize = true;
            this.lblMax.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMax.Location = new System.Drawing.Point(95, 14);
            this.lblMax.Name = "lblMax";
            this.lblMax.Size = new System.Drawing.Size(41, 19);
            this.lblMax.TabIndex = 3;
            this.lblMax.Text = "Max";
            // 
            // dgvAvailable
            // 
            this.dgvAvailable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAvailable.Location = new System.Drawing.Point(421, 36);
            this.dgvAvailable.Name = "dgvAvailable";
            this.dgvAvailable.Size = new System.Drawing.Size(168, 366);
            this.dgvAvailable.TabIndex = 2;
            // 
            // dgvAllocation
            // 
            this.dgvAllocation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllocation.Location = new System.Drawing.Point(253, 36);
            this.dgvAllocation.Name = "dgvAllocation";
            this.dgvAllocation.Size = new System.Drawing.Size(169, 366);
            this.dgvAllocation.TabIndex = 1;
            // 
            // dgvMax
            // 
            this.dgvMax.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMax.Location = new System.Drawing.Point(8, 36);
            this.dgvMax.Name = "dgvMax";
            this.dgvMax.Size = new System.Drawing.Size(247, 366);
            this.dgvMax.TabIndex = 0;
            // 
            // grbSafe
            // 
            this.grbSafe.Controls.Add(this.rtxtSafeStatus);
            this.grbSafe.Controls.Add(this.lblWork);
            this.grbSafe.Controls.Add(this.lblNeed);
            this.grbSafe.Controls.Add(this.dgvWork);
            this.grbSafe.Controls.Add(this.dgvNeed);
            this.grbSafe.Location = new System.Drawing.Point(619, 58);
            this.grbSafe.Name = "grbSafe";
            this.grbSafe.Size = new System.Drawing.Size(327, 492);
            this.grbSafe.TabIndex = 7;
            this.grbSafe.TabStop = false;
            this.grbSafe.Text = "Kết quả";
            // 
            // rtxtSafeStatus
            // 
            this.rtxtSafeStatus.Location = new System.Drawing.Point(11, 396);
            this.rtxtSafeStatus.Name = "rtxtSafeStatus";
            this.rtxtSafeStatus.Size = new System.Drawing.Size(310, 74);
            this.rtxtSafeStatus.TabIndex = 8;
            this.rtxtSafeStatus.Text = "";
            // 
            // lblWork
            // 
            this.lblWork.AutoSize = true;
            this.lblWork.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWork.Location = new System.Drawing.Point(138, 203);
            this.lblWork.Name = "lblWork";
            this.lblWork.Size = new System.Drawing.Size(46, 19);
            this.lblWork.TabIndex = 7;
            this.lblWork.Text = "Work";
            // 
            // lblNeed
            // 
            this.lblNeed.AutoSize = true;
            this.lblNeed.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNeed.Location = new System.Drawing.Point(139, 14);
            this.lblNeed.Name = "lblNeed";
            this.lblNeed.Size = new System.Drawing.Size(45, 19);
            this.lblNeed.TabIndex = 6;
            this.lblNeed.Text = "Need";
            // 
            // dgvWork
            // 
            this.dgvWork.AllowUserToAddRows = false;
            this.dgvWork.AllowUserToDeleteRows = false;
            this.dgvWork.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWork.Location = new System.Drawing.Point(11, 225);
            this.dgvWork.Name = "dgvWork";
            this.dgvWork.ReadOnly = true;
            this.dgvWork.Size = new System.Drawing.Size(310, 158);
            this.dgvWork.TabIndex = 1;
            // 
            // dgvNeed
            // 
            this.dgvNeed.AllowUserToAddRows = false;
            this.dgvNeed.AllowUserToDeleteRows = false;
            this.dgvNeed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNeed.Location = new System.Drawing.Point(11, 36);
            this.dgvNeed.Name = "dgvNeed";
            this.dgvNeed.ReadOnly = true;
            this.dgvNeed.Size = new System.Drawing.Size(310, 164);
            this.dgvNeed.TabIndex = 0;
            // 
            // grbAlgoChoose
            // 
            this.grbAlgoChoose.Controls.Add(this.rdbNone);
            this.grbAlgoChoose.Controls.Add(this.rdbMultiRequest);
            this.grbAlgoChoose.Controls.Add(this.rdbRequest);
            this.grbAlgoChoose.Location = new System.Drawing.Point(20, 501);
            this.grbAlgoChoose.Name = "grbAlgoChoose";
            this.grbAlgoChoose.Size = new System.Drawing.Size(272, 49);
            this.grbAlgoChoose.TabIndex = 8;
            this.grbAlgoChoose.TabStop = false;
            this.grbAlgoChoose.Text = "Request";
            // 
            // rdbNone
            // 
            this.rdbNone.AutoSize = true;
            this.rdbNone.Location = new System.Drawing.Point(6, 22);
            this.rdbNone.Name = "rdbNone";
            this.rdbNone.Size = new System.Drawing.Size(55, 20);
            this.rdbNone.TabIndex = 3;
            this.rdbNone.TabStop = true;
            this.rdbNone.Text = "None";
            this.rdbNone.UseVisualStyleBackColor = true;
            this.rdbNone.CheckedChanged += new System.EventHandler(this.rdbNone_CheckedChanged);
            // 
            // rdbMultiRequest
            // 
            this.rdbMultiRequest.AutoSize = true;
            this.rdbMultiRequest.Location = new System.Drawing.Point(167, 22);
            this.rdbMultiRequest.Name = "rdbMultiRequest";
            this.rdbMultiRequest.Size = new System.Drawing.Size(99, 20);
            this.rdbMultiRequest.TabIndex = 2;
            this.rdbMultiRequest.TabStop = true;
            this.rdbMultiRequest.Text = "MultiRequest";
            this.rdbMultiRequest.UseVisualStyleBackColor = true;
            this.rdbMultiRequest.CheckedChanged += new System.EventHandler(this.rdbMultiRequest_CheckedChanged);
            // 
            // rdbRequest
            // 
            this.rdbRequest.AutoSize = true;
            this.rdbRequest.Location = new System.Drawing.Point(80, 22);
            this.rdbRequest.Name = "rdbRequest";
            this.rdbRequest.Size = new System.Drawing.Size(70, 20);
            this.rdbRequest.TabIndex = 0;
            this.rdbRequest.TabStop = true;
            this.rdbRequest.Text = "Request";
            this.rdbRequest.UseVisualStyleBackColor = true;
            this.rdbRequest.CheckedChanged += new System.EventHandler(this.rdbRequest_CheckedChanged_1);
            // 
            // grbRequest
            // 
            this.grbRequest.Controls.Add(this.dgvRequestResource);
            this.grbRequest.Controls.Add(this.cbbRequest);
            this.grbRequest.Location = new System.Drawing.Point(298, 488);
            this.grbRequest.Name = "grbRequest";
            this.grbRequest.Size = new System.Drawing.Size(303, 72);
            this.grbRequest.TabIndex = 9;
            this.grbRequest.TabStop = false;
            this.grbRequest.Text = "Request";
            this.grbRequest.Visible = false;
            // 
            // dgvRequestResource
            // 
            this.dgvRequestResource.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRequestResource.Location = new System.Drawing.Point(75, 13);
            this.dgvRequestResource.Name = "dgvRequestResource";
            this.dgvRequestResource.Size = new System.Drawing.Size(219, 53);
            this.dgvRequestResource.TabIndex = 1;
            // 
            // cbbRequest
            // 
            this.cbbRequest.FormattingEnabled = true;
            this.cbbRequest.Location = new System.Drawing.Point(20, 27);
            this.cbbRequest.Name = "cbbRequest";
            this.cbbRequest.Size = new System.Drawing.Size(38, 24);
            this.cbbRequest.TabIndex = 0;
            // 
            // btnRequestResource
            // 
            this.btnRequestResource.Location = new System.Drawing.Point(619, 14);
            this.btnRequestResource.Name = "btnRequestResource";
            this.btnRequestResource.Size = new System.Drawing.Size(105, 38);
            this.btnRequestResource.TabIndex = 10;
            this.btnRequestResource.Text = "Chạy";
            this.btnRequestResource.UseVisualStyleBackColor = true;
            this.btnRequestResource.Visible = false;
            this.btnRequestResource.Click += new System.EventHandler(this.btnRequestResource_Click);
            // 
            // btnMultiRequest
            // 
            this.btnMultiRequest.Location = new System.Drawing.Point(619, 14);
            this.btnMultiRequest.Name = "btnMultiRequest";
            this.btnMultiRequest.Size = new System.Drawing.Size(105, 38);
            this.btnMultiRequest.TabIndex = 11;
            this.btnMultiRequest.Text = "Chạy";
            this.btnMultiRequest.UseVisualStyleBackColor = true;
            this.btnMultiRequest.Visible = false;
            this.btnMultiRequest.Click += new System.EventHandler(this.btnMultiRequest_Click);
            // 
            // BankerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 572);
            this.Controls.Add(this.btnMultiRequest);
            this.Controls.Add(this.btnRequestResource);
            this.Controls.Add(this.grbRequest);
            this.Controls.Add(this.grbAlgoChoose);
            this.Controls.Add(this.grbSafe);
            this.Controls.Add(this.grbProcessSafe);
            this.Controls.Add(this.btnRunSafe);
            this.Controls.Add(this.btnRemoveCol);
            this.Controls.Add(this.btnRemoveRow);
            this.Controls.Add(this.btnAddRow);
            this.Controls.Add(this.btnAddCol);
            this.Controls.Add(this.Exit);
            this.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "BankerForm";
            this.Text = "Banker and Deadlock";
            this.Load += new System.EventHandler(this.BankerForm_Load);
            this.grbProcessSafe.ResumeLayout(false);
            this.grbProcessSafe.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvailable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllocation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMax)).EndInit();
            this.grbSafe.ResumeLayout(false);
            this.grbSafe.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWork)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNeed)).EndInit();
            this.grbAlgoChoose.ResumeLayout(false);
            this.grbAlgoChoose.PerformLayout();
            this.grbRequest.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequestResource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.Button btnAddCol;
        private System.Windows.Forms.Button btnAddRow;
        private System.Windows.Forms.Button btnRemoveRow;
        private System.Windows.Forms.Button btnRemoveCol;
        private System.Windows.Forms.Button btnRunSafe;
        private System.Windows.Forms.GroupBox grbProcessSafe;
        private System.Windows.Forms.GroupBox grbSafe;
        private System.Windows.Forms.DataGridView dgvMax;
        private System.Windows.Forms.DataGridView dgvAvailable;
        private System.Windows.Forms.DataGridView dgvAllocation;
        private System.Windows.Forms.Label lblMax;
        private System.Windows.Forms.DataGridView dgvWork;
        private System.Windows.Forms.DataGridView dgvNeed;
        private System.Windows.Forms.Label lblAllocation;
        private System.Windows.Forms.Label lblAvailable;
        private System.Windows.Forms.Label lblWork;
        private System.Windows.Forms.Label lblNeed;
        private System.Windows.Forms.RichTextBox rtxtSafeStatus;
        private System.Windows.Forms.GroupBox grbAlgoChoose;
        private System.Windows.Forms.RadioButton rdbMultiRequest;
        private System.Windows.Forms.RadioButton rdbRequest;
        private System.Windows.Forms.GroupBox grbRequest;
        private System.Windows.Forms.DataGridView dgvRequestResource;
        private System.Windows.Forms.ComboBox cbbRequest;
        private System.Windows.Forms.Button btnRequestResource;
        private System.Windows.Forms.RadioButton rdbNone;
        private System.Windows.Forms.Button btnMultiRequest;
    }
}