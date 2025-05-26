using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CK_HDH
{
    public partial class CPU_DistributionForm : Form
    {
        public CPU_DistributionForm()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            var form1 = (Form1)Tag;
            form1.Show();
            Close();
        }


        private void CPU_DistributionForm_Load(object sender, EventArgs e)
        {
            cbThuatToan.Items.Add("FCFS");
            cbThuatToan.Items.Add("SJF (Non-Preemptive)");
            cbThuatToan.Items.Add("SJF (Preemptive)");
            cbThuatToan.Items.Add("SRTF (Non-Preemptive)");
            cbThuatToan.Items.Add("SRTF (Preemptive)");
            cbThuatToan.Items.Add("Round Robin");
            cbThuatToan.Items.Add("Priority (Non-Preemptive)");
            cbThuatToan.Items.Add("Priority (Preemptive)");

            cbThuatToan.SelectedIndex = 0; // Mặc định chọn FCFS
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            dgvTienTrinh.Rows.Clear();
            panelGanttChart.Controls.Clear();

            int soTienTrinh;
            if (!int.TryParse(txtP.Text, out soTienTrinh) || soTienTrinh <= 0)
            {
                MessageBox.Show("Vui lòng nhập số nguyên dương.");
                return;
            }

            // PID không cho sửa
            dgvTienTrinh.Columns["PID"].ReadOnly = true;

            // Tạo dòng
            for (int i = 0; i < soTienTrinh; i++)
            {
                int index = dgvTienTrinh.Rows.Add();
                dgvTienTrinh.Rows[index].Cells["PID"].Value = (i + 1).ToString();
            }
        }

        public class Process
        {
            public int PID { get; set; }
            public int ArrivalTime { get; set; }
            public int BurstTime { get; set; }
            public int Priority { get; set; }

            public int StartTime { get; set; }
            public int CompleteTime { get; set; }
            public int TurnaroundTime { get; set; }
            public int WaitingTime { get; set; }
        }

        private List<Process> DocDanhSachTienTrinh()
        {
            List<Process> ds = new List<Process>();

            foreach (DataGridViewRow row in dgvTienTrinh.Rows)
            {
                if (row.IsNewRow) continue;

                try
                {
                    int pid = Convert.ToInt32(row.Cells["PID"].Value);
                    int arrival = Convert.ToInt32(row.Cells["ArrivalTime"].Value);
                    int burst = Convert.ToInt32(row.Cells["BurstTime"].Value);
                    int priority = Convert.ToInt32(row.Cells["Priority"].Value);

                    ds.Add(new Process
                    {
                        PID = pid,
                        ArrivalTime = arrival,
                        BurstTime = burst,
                        Priority = priority
                    });
                }
                catch
                {
                    MessageBox.Show("Dữ liệu không hợp lệ. Hãy kiểm tra các ô nhập.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }

            return ds;
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            // Kiểm tra có chọn thuật toán không
            if (cbThuatToan.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn một thuật toán.");
                return;
            }

            string thuatToan = cbThuatToan.SelectedItem.ToString();

            // Đọc dữ liệu từ DataGridView
            List<Process> processes = DocDanhSachTienTrinh();
            if (processes == null || processes.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu tiến trình.");
                return;
            }

            // Gọi hàm tương ứng với thuật toán
            switch (thuatToan)
            {
                case "FCFS":
                    MoPhongFCFS(processes);
                    break;
                case "SJF (Non-Preemptive)":
                    MoPhongSJF_NonPreemptive(processes);
                    break;
                case "SJF (Preemptive)":
                    MoPhongSJF_Preemptive(processes);
                    break;
                case "Priority (Non-Preemptive)":
                    MoPhongPriority_NonPreemptive(processes);
                    break;
                case "Priority (Preemptive)":
                    MoPhongPriority_Preemptive(processes);
                    break;
                case "Round Robin":
                    int quantum = 2;
                    MoPhongRoundRobin(processes, quantum);
                    break;
                default:
                    MessageBox.Show("Thuật toán chưa được hỗ trợ.");
                    break;
            }
        }

        private void MoPhongFCFS(List<Process> processes)
        {
            MessageBox.Show("Cài đặt mô phỏng FCFS");
        }

        private void MoPhongSJF_NonPreemptive(List<Process> processes)
        {
            MessageBox.Show("Cài đặt mô phỏng SJF không ưu tiên");
        }

        private void MoPhongSJF_Preemptive(List<Process> processes)
        {
            MessageBox.Show("Cài đặt mô phỏng SJF có ưu tiên");
        }

        private void MoPhongPriority_NonPreemptive(List<Process> processes)
        {
            //MessageBox.Show("Cài đặt mô phỏng Priority không ưu tiên");
            // Sắp xếp tiến trình theo thời gian đến (ArrivalTime) ban đầu
            processes = processes.OrderBy(p => p.ArrivalTime).ToList();

            List<Process> result = new List<Process>();
            int currentTime = 0;

            List<Process> readyQueue = new List<Process>();

            while (processes.Count > 0 || readyQueue.Count > 0)
            {
                // Thêm tiến trình đến vào hàng đợi
                readyQueue.AddRange(processes.Where(p => p.ArrivalTime <= currentTime));
                processes.RemoveAll(p => p.ArrivalTime <= currentTime);

                if (readyQueue.Count == 0)
                {
                    currentTime++; // Nếu chưa có tiến trình nào đến, tăng thời gian
                    continue;
                }

                // Chọn tiến trình có độ ưu tiên cao nhất (số nhỏ nhất)
                Process selected = readyQueue.OrderBy(p => p.Priority).ThenBy(p => p.ArrivalTime).First();
                readyQueue.Remove(selected);

                // Ghi nhận thời gian bắt đầu & kết thúc
                selected.StartTime = currentTime;
                selected.CompleteTime = currentTime + selected.BurstTime;
                selected.TurnaroundTime = selected.CompleteTime - selected.ArrivalTime;
                selected.WaitingTime = selected.StartTime - selected.ArrivalTime;

                currentTime += selected.BurstTime;
                result.Add(selected);
            }

            VeBieuDoGantt(result);
        }

        private void MoPhongPriority_Preemptive(List<Process> processes)
        {
            // Gán thêm thời gian còn lại (RemainingTime) vào mỗi process
            foreach (var p in processes)
            {
                p.StartTime = -1;
                p.CompleteTime = 0;
                p.WaitingTime = 0;
                p.TurnaroundTime = 0;
            }

            int n = processes.Count;
            int time = 0;
            int completed = 0;

            var remainingTime = processes.ToDictionary(p => p.PID, p => p.BurstTime);

            List<(int time, int pid)> gantt = new List<(int time, int pid)>();

            while (completed < n)
            {
                var available = processes.Where(p => p.ArrivalTime <= time && remainingTime[p.PID] > 0);

                Process current = null;
                if (available.Any())
                {
                    int minPriority = available.Min(p => p.Priority);
                    current = available.Where(p => p.Priority == minPriority).OrderBy(p => p.ArrivalTime).First();
                }

                if (current != null)
                {
                    if (current.StartTime == -1)
                        current.StartTime = time;

                    remainingTime[current.PID]--;
                    gantt.Add((time, current.PID));

                    if (remainingTime[current.PID] == 0)
                    {
                        current.CompleteTime = time + 1;
                        current.TurnaroundTime = current.CompleteTime - current.ArrivalTime;
                        current.WaitingTime = current.TurnaroundTime - current.BurstTime;
                        completed++;
                    }
                }
                else
                {
                    gantt.Add((time, -1)); // idle
                }

                time++;
            }

            // Gộp các block liên tiếp cùng PID lại để tạo tiến trình liên tục cho Gantt Chart
            List<Process> ganttProcesses = new List<Process>();
            int i = 0;
            while (i < gantt.Count)
            {
                int start = gantt[i].time;
                int pid = gantt[i].pid;
                int length = 1;
                i++;

                while (i < gantt.Count && gantt[i].pid == pid)
                {
                    length++;
                    i++;
                }

                if (pid != -1)
                {
                    var original = processes.First(p => p.PID == pid);
                    ganttProcesses.Add(new Process
                    {
                        PID = pid,
                        StartTime = start,
                        BurstTime = length,
                        CompleteTime = start + length
                    });
                }
            }

            VeBieuDoGantt(ganttProcesses);
        }

        private void MoPhongRoundRobin(List<Process> processes, int quantum)
        {
            MessageBox.Show("Cài đặt mô phỏng Round Robin");
        }

        private void cbThuatToan_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void VeBieuDoGantt(List<Process> processes)
        {
            panelGanttChart.Controls.Clear(); // Xoá biểu đồ cũ
            panelGanttChart.AutoScroll = true;

            int pixelPerUnit = 30; // Mỗi đơn vị thời gian = 30px
            int currentLeft = 0; // Vị trí bắt đầu
            int margin = 2;
            int timeLabelTop = 0; // Biến để lưu chiều cao dòng thời gian

            foreach (var p in processes)
            {
                // Tạo label đại diện tiến trình
                Label lbl = new Label();
                lbl.Text = "P" + p.PID;
                lbl.TextAlign = ContentAlignment.MiddleCenter;
                lbl.BorderStyle = BorderStyle.FixedSingle;
                lbl.BackColor = Color.LightBlue;
                lbl.Width = p.BurstTime * pixelPerUnit;
                lbl.Height = 40;
                lbl.Left = currentLeft;
                lbl.Top = 10;

                panelGanttChart.Controls.Add(lbl);

                // Thêm thời gian dưới mỗi tiến trình
                Label timeLabel = new Label();
                timeLabel.Text = p.StartTime.ToString();
                timeLabel.Left = currentLeft;
                timeLabel.Top = lbl.Bottom + margin;
                timeLabelTop = timeLabel.Top; // Lưu lại chiều cao của timeLabel
                timeLabel.Width = 20;
                timeLabel.Font = new Font(timeLabel.Font.FontFamily, 8);
                panelGanttChart.Controls.Add(timeLabel);

                currentLeft += lbl.Width;
            }

            // Thêm mốc thời gian kết thúc
            var endTimeLabel = new Label();
            endTimeLabel.Text = processes.Last().CompleteTime.ToString();
            endTimeLabel.Left = currentLeft;
            endTimeLabel.Top = timeLabelTop; // Đồng bộ vị trí với các timeLabel
            endTimeLabel.Width = 20;
            endTimeLabel.Font = new Font(endTimeLabel.Font.FontFamily, 8);
            endTimeLabel.ForeColor = Color.Black;
            panelGanttChart.Controls.Add(endTimeLabel);

            // Căn giữa panelGanttChart theo chiều ngang trong Form
            panelGanttChart.Width = currentLeft + 20;
            panelGanttChart.Left = (this.ClientSize.Width - panelGanttChart.Width) / 2;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            var form1 = (Form1)Tag;
            form1.Show();
            Close();
        }
    }
}
