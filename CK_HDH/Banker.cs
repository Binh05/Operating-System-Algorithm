using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CK_HDH
{
    public partial class BankerForm : Form
    {
        int processCount = 1;
        int resourceCount = 3;

        public BankerForm()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            var form1 = (Form1)Tag;
            form1.Show();
            Close();
        }

        private void SetupDgvMax(int processCount, int resourceCount)
        {
            dgvMax.AllowUserToAddRows = false;
            dgvMax.Columns.Clear();
            dgvMax.Rows.Clear();

            // Cột đầu tiên là Tiến trình (P0, P1, ...)
            dgvMax.Columns.Add("Process","");
            dgvMax.Columns[0].Width = 40;
            dgvMax.Columns[0].ReadOnly = true; 
            dgvMax.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvMax.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvMax.Columns[0].Frozen = true; 
          
            // Thêm cột tài nguyên: R1, R2, R3, ...
            for (int i = 0; i < resourceCount; i++)
            {
                dgvMax.Columns.Add("R" + (i + 1), "R" + (i + 1));
                dgvMax.Columns[i + 1].Width = 40; 
                dgvMax.Columns[i + 1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; 
                dgvMax.Columns[i + 1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; 
            }

            // Thêm các dòng tương ứng với tiến trình
            for (int i = 0; i < processCount; i++)
            {
                var row = new DataGridViewRow();
                row.CreateCells(dgvMax);
                row.Cells[0].Value = "P" + i;  // Cột Tiến trình
                dgvMax.Rows.Add(row);
            }
        }

        private void SetupDgvAllocation(int processCount, int resourceCount)
        {
            dgvAllocation.AllowUserToAddRows = false;
            dgvAllocation.Columns.Clear();
            dgvAllocation.Rows.Clear();

            // Chỉ có các cột tài nguyên: R1, R2, ...
            for (int i = 0; i < resourceCount; i++)
            {
                dgvAllocation.Columns.Add("R" + (i + 1), "R" + (i + 1));
                dgvAllocation.Columns[i].Width = 40;
                dgvAllocation.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; 
                dgvAllocation.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            // Mỗi dòng là 1 tiến trình
            for (int i = 0; i < processCount; i++)
            {
                dgvAllocation.Rows.Add();
            }
        }

        private void SetupDgvAvailable(int resourceCount)
        {
            dgvAvailable.AllowUserToAddRows = false;
            dgvAvailable.Columns.Clear();
            dgvAvailable.Rows.Clear();

            // Chỉ có 1 dòng với các cột tài nguyên: R1, R2, ...
            for (int i = 0; i < resourceCount; i++)
            {
                dgvAvailable.Columns.Add("R" + (i + 1), "R" + (i + 1));
                dgvAvailable.Columns[i].Width = 40;
                dgvAvailable.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvAvailable.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dgvAvailable.Rows.Add(); 
        }

        private void btnAddRow_Click(object sender, EventArgs e)
        {
            processCount++;
            SetupDgvMax(processCount, resourceCount);
            SetupDgvAllocation(processCount, resourceCount);
        }

        private void btnAddCol_Click(object sender, EventArgs e)
        {
            resourceCount++;
            SetupDgvMax(processCount, resourceCount);
            SetupDgvAllocation(processCount, resourceCount);
            SetupDgvAvailable(resourceCount);
        }

        private void btnRemoveRow_Click(object sender, EventArgs e)
        {
            if (processCount > 1)
            {
                processCount--;
                SetupDgvMax(processCount, resourceCount);
                SetupDgvAllocation(processCount, resourceCount);
            }
        }

        private void btnRemoveCol_Click(object sender, EventArgs e)
        {
            if (resourceCount > 1)
            {
                resourceCount--;
                SetupDgvMax(processCount, resourceCount);
                SetupDgvAllocation(processCount, resourceCount);
                SetupDgvAvailable(resourceCount);
            }
        }

        private int[,] GetMatrixFromDataGridView(DataGridView dgv, bool skipFirstColumn = false)
        {
            int rows = dgv.RowCount;
            int cols = dgv.ColumnCount - (skipFirstColumn ? 1 : 0);
            int[,] matrix = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    int colIndex = j + (skipFirstColumn ? 1 : 0);
                    object cellValue = dgv.Rows[i].Cells[colIndex].Value;
                    string text = cellValue?.ToString().Trim();

                    if (!int.TryParse(text, out matrix[i, j]))
                    {
                        matrix[i, j] = 0;
                    }
                }
            }

            return matrix;
        }

        private int[] GetAvailableArray(DataGridView dgv)
        {
            int cols = dgv.ColumnCount;
            int[] array = new int[cols];

            for (int i = 0; i < cols; i++)
            {
                object cellValue = dgv.Rows[0].Cells[i].Value;
                string text = cellValue?.ToString().Trim();

                if (!int.TryParse(text, out array[i]))
                {
                    array[i] = 0; // gán mặc định nếu lỗi
                }
            }

            return array;
        }

        private void ShowMatrixInDataGridView(DataGridView dgv, int[,] matrix)
        {
            dgv.Rows.Clear();
            dgv.Columns.Clear();

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int j = 0; j < cols; j++)
                dgv.Columns.Add("col" + j, "R" + j);

            for (int i = 0; i < rows; i++)
            {
                object[] row = new object[cols];
                for (int j = 0; j < cols; j++)
                    row[j] = matrix[i, j];

                dgv.Rows.Add(row);
            }
        }

        private void PrintWorkHistory(DataGridView dgv, List<int[]> workHistory, int resourceCount)
        {
            dgv.Rows.Clear();
            dgv.Columns.Clear();
            dgv.AllowUserToAddRows = false;

            // Tạo cột R0, R1, R2, ...
            for (int j = 0; j < resourceCount; j++)
            {
                dgv.Columns.Add("R" + j, "R" + j);
            }

            // Thêm từng trạng thái work vào
            foreach (var work in workHistory)
            {
                dgv.Rows.Add(work.Cast<object>().ToArray());
            }
        }

        // Giải thuật kiểm tra an toàn
        private void btnRun_Click(object sender, EventArgs e)
        {
            int processCount = dgvAllocation.RowCount;
            int resourceCount = dgvAllocation.ColumnCount;

            int[,] allocation = GetMatrixFromDataGridView(dgvAllocation);
            int[,] max = GetMatrixFromDataGridView(dgvMax, true);
            int[,] need = new int[processCount, resourceCount];
            int[] available = GetAvailableArray(dgvAvailable);

            // Tính Need = Max - Allocation
            for (int i = 0; i < processCount; i++)
                for (int j = 0; j < resourceCount; j++)
                    need[i, j] = max[i, j] - allocation[i, j];

            // Hiển thị Need
            ShowMatrixInDataGridView(dgvNeed, need);

            // Giải thuật kiểm tra an toàn
            bool[] finish = new bool[processCount];
            int[] work = (int[])available.Clone();
            List<int[]> workHistory = new List<int[]>();
            List<int> safeSequence = new List<int>();
            workHistory.Add((int[])work.Clone());

            bool found;
            do
            {
                found = false;
                for (int i = 0; i < processCount; i++)
                {
                    if (max.GetLength(1) != resourceCount)
                        throw new InvalidOperationException("Max matrix dimensions do not match resource count.");
                    if (!finish[i])
                    {
                        bool canRun = true;
                        for (int j = 0; j < resourceCount; j++)
                        {
                            if (need[i, j] > work[j])
                            {
                                canRun = false;
                                break;
                            }
                        }

                        if (canRun)
                        {
                            for (int j = 0; j < resourceCount; j++)
                                work[j] += allocation[i, j];
                            finish[i] = true;
                            workHistory.Add((int[])work.Clone());                           
                            safeSequence.Add(i);
                            found = true;
                        }
                    }
                }
            } while (found);

            // Hiển thị Work
            PrintWorkHistory(dgvWork, workHistory, resourceCount);

            // Thông báo kết quả
            if (safeSequence.Count == processCount)
                rtxtSafeStatus.Text = "Hệ thống an toàn.\nChuỗi an toàn: " + string.Join(" -> ", safeSequence.Select(i => "P" + i));
            else
                rtxtSafeStatus.Text = "Hệ thống không an toàn.\nKhông có chuỗi an toàn nào.";
        }

        private void SetupCbbRequest(int processCount)
        {
            cbbRequest.Items.Clear();
            for (int i = 0; i < processCount; i++)
            {
                cbbRequest.Items.Add("P" + i);
            }
        }

        private void SetupDgvRequest(int resourceCount)
        {
            dgvRequestResource.AllowUserToAddRows = false;
            dgvRequestResource.Columns.Clear();
            dgvRequestResource.Rows.Clear();
            // Chỉ có các cột tài nguyên: R1, R2, ...
            for (int i = 0; i < resourceCount; i++)
            {
                dgvRequestResource.Columns.Add("R" + (i + 1), "R" + (i + 1));
                dgvRequestResource.Columns[i].Width = 40;
                dgvRequestResource.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvRequestResource.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            // Thêm một dòng trống để nhập yêu cầu
            dgvRequestResource.Rows.Add();
        }

        private void BankerForm_Load(object sender, EventArgs e)
        {
            // Khởi tạo DataGridView với giá trị mặc định
            SetupDgvMax(processCount, resourceCount);
            SetupDgvAllocation(processCount, resourceCount);
            SetupDgvAvailable(resourceCount);


            // Thiết lập giao diện yêu cầu
            grbRequest.Visible = false;
            btnRequestResource.Visible = false;
            btnMultiRequest.Visible = false;
            btnRunSafe.Visible = true;
            lblMax.Text = "Max";
            rdbNone.Checked = true;
        }

        private void rdbNone_CheckedChanged(object sender, EventArgs e)
        {
            grbRequest.Visible = false;
            lblMax.Text = "Max";

            btnRequestResource.Visible = false;
            btnMultiRequest.Visible = false;
            btnRunSafe.Visible = true;
        }

        private void rdbRequest_CheckedChanged_1(object sender, EventArgs e)
        {
            grbRequest.Visible = true;
            lblMax.Text = "Max";

            SetupCbbRequest(processCount);
            SetupDgvRequest(resourceCount);

            btnRunSafe.Visible = false;
            btnMultiRequest.Visible = false;
            btnRequestResource.Visible = true;
        }

        private void rdbMultiRequest_CheckedChanged(object sender, EventArgs e)
        {
            grbRequest.Visible = false;
            lblMax.Text = "Requests";

            btnRequestResource.Visible = false;
            btnRunSafe.Visible = false;
            btnMultiRequest.Visible = true;
        }

        //Giải thuật cấp phát tài nguyên
        private void btnRequestResource_Click(object sender, EventArgs e)
        {
            if (cbbRequest.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn tiến trình yêu cầu.");
                return;
            }

            int processIndex = cbbRequest.SelectedIndex;

            int[] request = new int[resourceCount];
            for (int i = 0; i < resourceCount; i++)
            {
                object cellValue = dgvRequestResource.Rows[0].Cells[i].Value;
                string text = cellValue?.ToString().Trim();
                if (!int.TryParse(text, out request[i])) request[i] = 0;
            }

            int[,] allocation = GetMatrixFromDataGridView(dgvAllocation);
            int[,] max = GetMatrixFromDataGridView(dgvMax, true);
            int[] available = GetAvailableArray(dgvAvailable);
            int[,] need = new int[processCount, resourceCount];

            for (int i = 0; i < processCount; i++)
                for (int j = 0; j < resourceCount; j++)
                    need[i, j] = max[i, j] - allocation[i, j];

            // Kiểm tra request <= need
            for (int j = 0; j < resourceCount; j++)
            {
                if (request[j] > need[processIndex, j])
                {
                    MessageBox.Show($"Tiến trình yêu cầu vượt quá nhu cầu tối đa tại R{j + 1}.");
                    return;
                }
            }

            // Kiểm tra request <= available
            for (int j = 0; j < resourceCount; j++)
            {
                if (request[j] > available[j])
                {
                    MessageBox.Show("Không đủ tài nguyên khả dụng để cấp phát ngay.");
                    return;
                }
            }

            // Thử cấp phát tạm thời
            for (int j = 0; j < resourceCount; j++)
            {
                available[j] -= request[j];
                allocation[processIndex, j] += request[j];
                need[processIndex, j] -= request[j];
            }

            // Kiểm tra lại an toàn
            bool[] finish = new bool[processCount];
            int[] work = (int[])available.Clone();
            List<int[]> workHistory = new List<int[]>();
            List<int> safeSequence = new List<int>();
            workHistory.Add((int[])work.Clone());
            bool found;
            do
            {
                found = false;
                for (int i = 0; i < processCount; i++)
                {
                    if (!finish[i])
                    {
                        bool canRun = true;
                        for (int j = 0; j < resourceCount; j++)
                        {
                            if (need[i, j] > work[j])
                            {
                                canRun = false;
                                break;
                            }
                        }
                        if (canRun)
                        {
                            for (int j = 0; j < resourceCount; j++)
                                work[j] += allocation[i, j];
                            workHistory.Add((int[])work.Clone());
                            finish[i] = true;
                            safeSequence.Add(i);
                            found = true;
                        }
                    }
                }
            } while (found);

            if (safeSequence.Count == processCount)
            {
                // Cấp phát thực sự
                for (int j = 0; j < resourceCount; j++)
                {
                    dgvAvailable.Rows[0].Cells[j].Value = available[j];
                    dgvAllocation.Rows[processIndex].Cells[j].Value = allocation[processIndex, j];
                    dgvMax.Rows[processIndex].Cells[j + 1].Value = max[processIndex, j]; // offset 1
                }
   
                // Hiển thị chuỗi an toàn
                ShowMatrixInDataGridView(dgvNeed, need);
                PrintWorkHistory(dgvWork, workHistory, resourceCount);
                rtxtSafeStatus.Text = "Hệ thống an toàn.\nChuỗi an toàn: " + string.Join(" -> ", safeSequence.Select(i => "P" + i));
            }
            else
            {
                ShowMatrixInDataGridView(dgvNeed, need);
                PrintWorkHistory(dgvWork, workHistory, resourceCount);
                rtxtSafeStatus.Text = "Hệ thống không an toàn sau khi cấp phát yêu cầu.\nKhông có chuỗi an toàn nào.";
            }
        }

        private void btnMultiRequest_Click(object sender, EventArgs e)
        {
            DetectDeadlock();
        }

        // Phát hiện deadlock
        private void DetectDeadlock()
        {
            int[,] allocation = GetMatrixFromDataGridView(dgvAllocation);
            int[,] request = GetMatrixFromDataGridView(dgvMax); // Lấy trực tiếp từ dgvMax
            int[] available = GetAvailableArray(dgvAvailable);

            bool[] finish = new bool[processCount];
            for (int i = 0; i < processCount; i++)
            {
                for (int j = 0;j < resourceCount; j++)
                {
                    if (allocation[processCount,j] == 0)
                    {
                        finish[i] = true;
                    }
                    else
                    {
                        finish[i] = false;
                    }
                }
            }
            int[] work = (int[])available.Clone();
            List<int[]> workHistory = new List<int[]>();
            workHistory.Add((int[])work.Clone());

            bool found;
            do
            {
                found = false;
                for (int i = 0; i < processCount; i++)
                {
                    if (!finish[i])
                    {
                        bool canRun = true;
                        for (int j = 0; j < resourceCount; j++)
                        {
                            if (request[i, j] > work[j])
                            {
                                canRun = false;
                                break;
                            }
                        }

                        if (canRun)
                        {
                            for (int j = 0; j < resourceCount; j++)
                            {
                                work[j] += allocation[i, j];
                            }
                            workHistory.Add((int[])work.Clone());
                            finish[i] = true;
                            found = true;
                        }
                    }
                }
            } while (found);

            // Hiển thị kết quả
            List<string> deadlockedProcesses = new List<string>();
            PrintWorkHistory(dgvWork, workHistory, resourceCount);
            for (int i = 0; i < processCount; i++)
            {
                if (!finish[i])
                {
                    deadlockedProcesses.Add("P" + i);
                }
            }

            if (deadlockedProcesses.Count == 0)
            {
                rtxtSafeStatus.Text = "Không có deadlock.";
            }
            else
            {
                rtxtSafeStatus.Text = "Deadlock xảy ra với các tiến trình: " + string.Join(", ", deadlockedProcesses);
            }
        }

    }
}
